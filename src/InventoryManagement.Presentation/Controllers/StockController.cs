using InventoryManagement.Application.Featurers.Products.Queries.GetProductsByPage;
using InventoryManagement.Application.Featurers.Stocks.Queries.GetStocksByPage;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Presentation.Controllers
{
    [Authorize]
    public class StockController : ApiControllerBase
    {
        public StockController(IMediator mediator) : base(mediator)
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
    }
}
