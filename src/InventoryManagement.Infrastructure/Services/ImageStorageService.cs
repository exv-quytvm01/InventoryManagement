using InventoryManagement.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Services
{
    public class ImageStorageService : IImageStorageService
    {
        private readonly string _imageFolderPath;

        public ImageStorageService(string imageFolderPath)
        {
            _imageFolderPath = imageFolderPath;
        }

        public async Task<bool> DeleteImageAsync(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return false;

            string filePath = Path.Combine(_imageFolderPath, fileName);
            

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }

            return false;
        }

        public async Task<string> SaveImageAsync(IFormFile imageFile)
        {
            // Tạo đường dẫn lưu trữ mới cho hình ảnh
            string uploadsFolder = Path.Combine(_imageFolderPath, "Images");
            string uploadsFolder1 = Path.Combine("", "Images");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            string filePath1 = Path.Combine(uploadsFolder1, uniqueFileName);
            try
            {
                // Đảm bảo thư mục lưu trữ đã tồn tại
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }
               
                return filePath1;
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Error saving image: {ex.Message}");
                return null;
            }
        }
    }
}
