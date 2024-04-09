using InventoryManagement.Application.Dto;
using InventoryManagement.Application.Dto.Categories;
using InventoryManagement.Application.Featurers.Categories.Commands.Create;
using InventoryManagement.Application.Featurers.Products.Queries.GetProducts;
using InventoryManagement.Application.Featurers.Stocks.Command.Create;
using InventoryManagement.Application.Featurers.Stocks.Queries.GetStocksByPage;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagement.Presentation.Controllers
{
    [Authorize]
    public class StockController : ApiControllerBase
    {
        public StockController(IMediator mediator) : base(mediator)
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

            var stocks = await _mediator.Send(new GetStocksQueryByPage()
            {
                searchString = SearchString,
                pageNumber = PageNumber,
                sortOrder = SortOrder,
                pageSize = PageSize,
                currentFilter = CurrentFilter
            });
            return View(stocks);
        }

        public async Task<ActionResult> Create()
        {
            var command = new GetProductsQuery();
            var response = await _mediator.Send(command);
            ViewData["ProductId"] = new SelectList(response, "Id", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] StockDto stock)
        {
            var command = new CreateStockCommand { Stock = stock };
            var response = await _mediator.Send(command);
            return RedirectToAction("Index", "Stock");
        }
    }
}
