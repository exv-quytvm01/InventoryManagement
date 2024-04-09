using InventoryManagement.Application.Dto.Suppliers;
using InventoryManagement.Application.Featurers.Suppliers.Queries.GetSuppliersByPage;
using InventoryManagement.Application.Featurers.Suppliers.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InventoryManagement.Application.Featurers.Suppliers.Queries.GetSupById;
using InventoryManagement.Application.Featurers.Suppliers.Commands.Update;
using InventoryManagement.Application.Featurers.Suppliers.Commands.Delete;

namespace InventoryManagement.Presentation.Controllers
{
    [Authorize]
    public class SupplierController : ApiControllerBase
    {
        public SupplierController(IMediator mediator) : base(mediator)
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

            var suppliers = await _mediator.Send(new GetSuppliersQueryByPage()
            {
                searchString = SearchString,
                pageNumber = PageNumber,
                sortOrder = SortOrder,
                pageSize = PageSize,
                currentFilter = CurrentFilter
            });
            return View(suppliers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] CreateSupplierDto supplierDto)
        {
            var command = new CreateSupplierCommand { SupplierDto = supplierDto };
            var response = await _mediator.Send(command);
            return RedirectToAction("Index", "Supplier");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var command = new GetSupplierByIdQuery() { Id = id };
            var response = await _mediator.Send(command);
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] SupplierDto supplier)
        {
            if (id != supplier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var command = new UpdateSupplierCommand()
                {
                    SupplierDto = supplier
                };
                var response = await _mediator.Send(command);

                return RedirectToAction("Index", "Supplier");
            }
            return View(supplier);
        }

        public async Task<IActionResult> Delete(int id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var commandps = new GetSupplierByIdQuery () { Id = id };
            var response = await _mediator.Send(commandps);
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
            var command = new DeleteSupplierCommand() { Id = id };
            var response = await _mediator.Send(command);
            return RedirectToAction("Index", "Supplier");
        }
    }
}
