using ExampleProject.Core.Entities;
using InventoryManagement.Application.Dto.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.IRepository
{
    public interface IAcountRepository
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
        Task<bool> CreateUser(CreateEmployeeDto employee, string Path);
        Task<bool> UpdateUser(Employee employee);
        Task<List<IdentityRole>> ListRoles();
        Task<IReadOnlyList<Employee>> CreateAsync(IQueryable<Employee> source, int pageIndex, int pageSize);
        IQueryable<Employee> getListByCondition();
        Task<Employee> GetById(string id);
    }
}
