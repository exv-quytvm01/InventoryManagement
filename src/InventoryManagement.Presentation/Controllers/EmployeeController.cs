using InventoryManagement.Application.Dto.Identity;
using InventoryManagement.Application.Featurers.Identities.Create;
using InventoryManagement.Application.Featurers.Identities.GetById;
using InventoryManagement.Application.Featurers.Identities.GetRoles;
using InventoryManagement.Application.Featurers.Identities.GetUsersByPage;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagement.Presentation.Controllers
{
    [Authorize(Policy = "RequireAdministratorRole")]
    public class EmployeeController : ApiControllerBase
    {
        public EmployeeController(IMediator mediator) : base(mediator)
        {
        }

        public async Task<IActionResult> Index(string SearchString = null, string SortOrder = "date_desc",
            int PageNumber = 1, int PageSize = 10, string CurrentFilter = null)
        {
            ViewData["CurrentSort"] = SortOrder;
            if (SearchString != null)
            {
                PageNumber = 1;
            }
            else
            {
                SearchString = CurrentFilter;
            }

            ViewData["CurrentFilter"] = SearchString;

            var employees = await _mediator.Send(new GetUsersByPageCommand()
            {
                searchString = SearchString,
                pageNumber = PageNumber,
                sortOrder = SortOrder,
                pageSize = PageSize,
                currentFilter = CurrentFilter
            });

            return View(employees);
        }

        public async Task<ActionResult> Create()
        {
            var command = new GetRoles();
            var response = await _mediator.Send(command);
            ViewData["RoleId"] = new SelectList(response, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] ViewAddEmployee request)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateEmployeeCommand()
                {
                    viewadd = request
                };
                var response = await _mediator.Send(command);
                if (response)
                {
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to create user.");
                }
            }
            return View(request);
        }

        public async Task<IActionResult> Detail(string Id)
        {
            var command = new GetUserById() {  Id = Id };
            var reponse = await _mediator.Send(command);
            return View(reponse);
        }

        
    }
}
