using InventoryManagement.Application.Dto.Products;
using InventoryManagement.Application.Featurers.Categories.Queries.GetCategoys;
using InventoryManagement.Application.Featurers.Products.Commands.Create;
using InventoryManagement.Application.Featurers.Products.Commands.Delete;
using InventoryManagement.Application.Featurers.Products.Commands.Update;
using InventoryManagement.Application.Featurers.Products.Queries.GetProductById;
using InventoryManagement.Application.Featurers.Products.Queries.GetProductsByPage;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagement.Presentation.Controllers
{
    [Authorize]    
    public class ProductController : ApiControllerBase
    {
        public ProductController(IMediator mediator) : base(mediator)
        {
        }

        public async Task<IActionResult> Index(string SearchString = null, string SortOrder = "date_desc",
            int PageNumber = 1, int PageSize = 20, string CurrentFilter = null)
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

            var products = await _mediator.Send(new GetProductsQueryByPage()
            {
                searchString = SearchString,
                pageNumber = PageNumber,
                sortOrder = SortOrder,
                pageSize = PageSize,
                currentFilter = CurrentFilter
            });
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var command = new GetCategorysQuery();
            var response = await _mediator.Send(command);
            ViewData["CategoryId"] = new SelectList(response, "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] CreateProductDto product)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateProductCommand() { ProductDto = product };
                var repsonse = await _mediator.Send(command);
                return RedirectToAction("Index", "Product");
            }
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var commandps = new GetProductByIdQuery() { Id = id };
            var responsep = await _mediator.Send(commandps);
            if (responsep == null)
            {
                return NotFound();
            }

            var command = new GetCategorysQuery();
            var response = await _mediator.Send(command);
            ViewData["CategoryId"] = new SelectList(response, "Id", "CategoryName");
            return View(responsep);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,[FromForm] ProductDto product, [FromForm] IFormFile? Image)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var command = new UpdateProductCommand()
                {
                    ProductDto = product,
                    Image = Image
                };
                var response = await _mediator.Send(command);

                return RedirectToAction("Index", "Product");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commandps = new GetProductByIdQuery() { Id = id };
            var responsep = await _mediator.Send(commandps);
            if (responsep == null)
            {
                return NotFound();
            }

            // command = new GetCategorysQuery();
            //var response = await _mediator.Send(command);
            //ViewData["CategoryId"] = new SelectList(response, "Id", "CategoryName");
            return View(responsep);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var command = new DeleteProductCommand() { Id = id};
            var response = await _mediator.Send(command);
            return RedirectToAction("Index", "Product");
        }

    }
}
