using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace InventoryManagement.Presentation.Controllers
{
    public class ApiControllerBase : Controller
    {
        protected IMediator _mediator;

        public ApiControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        
    }
}
