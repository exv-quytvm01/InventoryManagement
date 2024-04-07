using ExampleProject.Core.Entities;
using InventoryManagement.Application.Dto.Identity;
using InventoryManagement.Application.Featurers.Identities.Login;
using InventoryManagement.Application.Featurers.Identities.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Presentation.Controllers
{ 
    public class AccountController : ApiControllerBase
    {
        private readonly SignInManager<Employee> _signInManager;

        public AccountController(IMediator mediator, SignInManager<Employee> signInManager) : base(mediator)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AuthRequest request)
        {
            if (ModelState.IsValid)
            {
                var command = new AuthFeatureCommand {AuthRequest = request };
                var response = await _mediator.Send(command);
                if (response != null)
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

                
            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationRequest request)
        {
            if (ModelState.IsValid)
            {
                var command = new RegistrationFeatureCommand { RegisRequest = request };
                var response = await _mediator.Send(command);
                if(response != null)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            return View();
        }
    }
}
