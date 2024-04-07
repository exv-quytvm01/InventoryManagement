using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Featurers.Categories.Commands.Delete
{
    public class DeleteCategoryComand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
