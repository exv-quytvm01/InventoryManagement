using ExampleProject.Core.Entities;
using InventoryManagement.Application.Dto.Identity;
using InventoryManagement.Application.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;


namespace InventoryManagement.Infrastructure.Repositories
{
    public class AcountRepository : IAcountRepository
    {
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;
        private readonly ILogger<AcountRepository> _logger;

        public AcountRepository(UserManager<Employee> userManager,
            ILogger<AcountRepository> logger,
            SignInManager<Employee> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
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
                throw; // Re-throw the exception to maintain the stack trace
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
