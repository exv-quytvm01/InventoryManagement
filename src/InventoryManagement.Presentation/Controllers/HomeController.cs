using InventoryManagement.Application.Dto.Identity;
using InventoryManagement.Application.Featurers.Identities.Create;
using InventoryManagement.Application.Featurers.Identities.GetById;
using InventoryManagement.Application.Featurers.Identities.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InventoryManagement.Presentation.Controllers
{
    [Authorize]
    public class HomeController : ApiControllerBase
    {
        public HomeController(IMediator mediator) : base(mediator)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string Id) {
            var command = new GetUserById() { Id = Id };
            var reponse = await _mediator.Send(command);
            return View(reponse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateEmployeeDto employeeDto, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                var command = new UpdateUserCommand()
                {
                    employee = employeeDto,
                    Image = Image
                };
                var response = await _mediator.Send(command);
                if (response)
                {
                    return RedirectToAction("Edit", "Home");
                }
            }

            return View(employeeDto);
        }
    }
}
