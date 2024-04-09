using InventoryManagement.Application.Dto.Customers;
using InventoryManagement.Application.Featurers.Customers.Commands.Create;
using InventoryManagement.Application.Featurers.Customers.Commands.Delete;
using InventoryManagement.Application.Featurers.Customers.Commands.Update;
using InventoryManagement.Application.Featurers.Customers.Queries.GetCustomerById;
using InventoryManagement.Application.Featurers.Customers.Queries.GetCustomersByPage;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Presentation.Controllers
{
    [Authorize]
    public class CustomerController : ApiControllerBase
    {
        public CustomerController(IMediator mediator) : base(mediator)
        {
        }

        public async Task<IActionResult> Index(string SearchString = null, string SortOrder = "date_desc",
            int PageNumber = 1, int PageSize = 10, string CurrentFilter = null)
        {
            ViewData["CurrentSort"] = SortOrder;
            //Sorting
            //ViewData["NameSortParam"] = string.IsNullOrEmpty(SortOrder) ? "name_desc" : "";
            //ViewData["LastModifiSortParm"] = SortOrder == "date_asc" ? "date_desc" : "date_asc";
            if (SearchString != null)
            {
                PageNumber = 1;
            }
            else
            {
                SearchString = CurrentFilter;
            }

            ViewData["CurrentFilter"] = SearchString;

            var customers = await _mediator.Send(new GetCustomersQueryByPage()
            {
                searchString = SearchString,
                pageNumber = PageNumber,
                sortOrder = SortOrder,
                pageSize = PageSize,
                currentFilter = CurrentFilter
            });
            return View(customers);      
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] CreateCustomerDto customerDto)
        {
            var command = new CreateCustomerCommand { CustomerDto = customerDto };
            var response = await _mediator.Send(command);
            return RedirectToAction("Index", "Customer");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var command = new GetCustomerByIdQuery() { Id = id };
            var response = await _mediator.Send(command);
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] CustomerDto customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var command = new UpdateCustomerCommand()
                {
                    CustomerDto = customer
                };
                var response = await _mediator.Send(command);

                return RedirectToAction("Index", "Customer");
            }
            return View(customer);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var command = new GetCustomerByIdQuery() { Id = id };
            var response = await _mediator.Send(command);
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var command = new DeleteCustomerCommand() { Id = id };
            var response = await _mediator.Send(command);
            return RedirectToAction("Index", "Customer");
        }
    }
}
