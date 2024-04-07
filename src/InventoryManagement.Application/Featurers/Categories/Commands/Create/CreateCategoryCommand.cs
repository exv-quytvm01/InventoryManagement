using InventoryManagement.Application.Dto.Categories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Categories.Commands.Create
{
    public class CreateCategoryCommand : IRequest<CategoryDto>
    {
        public CreateCategoryDto? CategoryDto { get; set; }
    }
}
