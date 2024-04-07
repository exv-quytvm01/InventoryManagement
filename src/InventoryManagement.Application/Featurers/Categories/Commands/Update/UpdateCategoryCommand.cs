using InventoryManagement.Application.Dto.Categories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Categories.Commands.Update
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public CategoryDto? CategoryDto { get; set; }
    }
}
