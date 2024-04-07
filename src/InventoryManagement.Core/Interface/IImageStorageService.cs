using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Interface
{
    public interface IImageStorageService
    {
        Task<string> SaveImageAsync(IFormFile imageFile);
        Task<bool> DeleteImageAsync(string fileName);
    }
}
