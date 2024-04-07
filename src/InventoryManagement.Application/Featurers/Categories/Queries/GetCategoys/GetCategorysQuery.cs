using InventoryManagement.Application.Dto.Categories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Categories.Queries.GetCategoys
{
    public class GetCategorysQuery : IRequest<List<CategoryDto>>
    {
    }
}
