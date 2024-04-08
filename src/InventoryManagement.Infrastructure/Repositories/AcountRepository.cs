using ExampleProject.Core.Entities;
using InventoryManagement.Application.Dto.Identity;
using InventoryManagement.Application.IRepository;
using InventoryManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class AcountRepository : IAcountRepository
    {
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;
        private readonly ILogger<AcountRepository> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
       

        public AcountRepository(
            UserManager<Employee> userManager,
            ILogger<AcountRepository> logger,
            SignInManager<Employee> signInManager,
            RoleManager<IdentityRole> roleManager
            
        ) {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            
        }

        public async Task<IReadOnlyList<Employee>> CreateAsync(IQueryable<Employee> source, int pageIndex, int pageSize)
        {
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return items;
        }

        public async Task<bool> CreateUser(CreateEmployeeDto employee, string Path)
        {
            
            var existingUser = await _userManager.FindByNameAsync(employee.UserName);
            if (existingUser != null)
            {
                _logger.LogError($"Username '{employee.UserName}' already exists.");
                throw new Exception($"Username '{employee.UserName}' already exists.");
            }

            
            var existingEmail = await _userManager.FindByEmailAsync(employee.Email);
            if (existingEmail != null)
            {
                _logger.LogError($"Email '{employee.Email}' already exists.");
                throw new Exception($"Email '{employee.Email}' already exists.");
            }

            
            var user = new Employee
            {
                EmployeeCode = employee.EmployeeCode,
                Email = employee.Email,
                EmployeeName = employee.EmployeeName,
                UserName = employee.UserName,
                PhoneNumber = employee.PhoneNumber,
                CCCD = employee.CCCD,
                Image = Path,
                Position = employee.Position,
                EmailConfirmed = true
            };

            
            var result = await _userManager.CreateAsync(user, employee.Password);
            var role = _roleManager.FindByIdAsync(employee.RoleId).Result;
            if (result.Succeeded)
            {
                
                await _userManager.AddToRoleAsync(user, role.NormalizedName);
                return true;
            }
            else
            {
                
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                _logger.LogError($"User creation failed: {errors}");
                throw new Exception($"User creation failed: {errors}");
            }
        }

        public async Task<Employee> GetById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }

        public IQueryable<Employee> getListByCondition()
        {
            return _userManager.Users;
        }

        public async Task<List<IdentityRole>> ListRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }


        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await FindByEmailOrUsernameAsync(request.UsernameOrEmail); 
            if (user is null)
            {
                return null;
            }

            var result = await _signInManager
                .PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return null;
            }

            AuthResponse response = new AuthResponse
            {
                Id = user.Id,
                Name=user.EmployeeName,
                Email = user.Email,
                UserName = user.UserName
            };

            return response;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            try
            {
                var existingUser = await _userManager.FindByNameAsync(request.UserName);

                if (existingUser != null)
                {
                    throw new Exception($"Username '{request.UserName}' already exists.");
                    
                }

                var user = new Employee
                {
                    Email = request.Email,
                    EmployeeName = request.Name,
                    UserName = request.UserName,
                    EmailConfirmed = true
                };

                var existingEmail = await _userManager.FindByEmailAsync(request.Email);

                if (existingEmail == null)
                {
                    var result = await _userManager.CreateAsync(user, request.Password);

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "EMPLOYEE");
                        return new RegistrationResponse() { UserId = user.Id };
                    }
                    else
                    {
                        var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                        _logger.LogError($"Registration failed: {errors}");
                        throw new Exception($"Registration failed: {errors}");
                    }
                }
                else
                {
                    throw new Exception($"Email {request.Email} already exists.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred during registration: {ex.Message}");
                throw; 
            }
        }

        

        public async Task<bool> UpdateUser(Employee employee)
        {
            
            var result = await _userManager.UpdateAsync(employee);
            return result.Succeeded;
        }

        private async Task<Employee> FindByEmailOrUsernameAsync(string identifier)
        {
            var userByEmail = await _userManager.FindByEmailAsync(identifier);
            if (userByEmail != null)
            {
                return userByEmail;
            }

            var userByUsername = await _userManager.FindByNameAsync(identifier);
            return userByUsername;
        }



    }
}




//private async Task<JwtSecurityToken> GenerateToken(Employee user)
//{
//    var userClaims = await _userManager.GetClaimsAsync(user);
//    var roles = await _userManager.GetRolesAsync(user);

//    var roleClaims = new List<Claim>();

//    for (int i = 0; i < roles.Count; i++)
//    {
//        roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
//    }

//    var claims = new[]
//    {
//        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
//        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//        new Claim(JwtRegisteredClaimNames.Email, user.Email),
//        new Claim(ClaimTypes.Sid, user.Id)
//    }
//    .Union(userClaims)
//    .Union(roleClaims);

//    var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
//    var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

//    var jwtSecurityToken = new JwtSecurityToken(
//        issuer: _jwtSettings.Issuer,
//        audience: _jwtSettings.Audience,
//        claims: claims,
//        expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
//        signingCredentials: signingCredentials);
//    return jwtSecurityToken;
//}