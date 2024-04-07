
using InventoryManagement.Application.Dto.Products;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Products.Commands.Create
{
    public class CreateProductCommand : IRequest<ProductDto>
    {
        public CreateProductDto? ProductDto;
    }
}
