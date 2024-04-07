using InventoryManagement.Application.Dto.Products;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Products.Commands.Update
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public ProductDto? ProductDto { get; set; }
        public IFormFile Image { get; set; }
    }
}
