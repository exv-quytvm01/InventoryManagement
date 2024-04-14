using InventoryManagement.Application.Dto.SaleOrderDetails;
using InventoryManagement.Application.Dto.SaleOrders;
using InventoryManagement.Application.Featurers.Customers.Queries.GetCustomers;
using InventoryManagement.Application.Featurers.Products.Queries.GetProducts;
using InventoryManagement.Application.Featurers.SaleOrders.Commands.Create;
using InventoryManagement.Application.Featurers.SaleOrders.Queries.GetAll;
using InventoryManagement.Application.Featurers.SaleOrders.Queries.GetDetailSaleOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagement.Presentation.Controllers
{
    public class SaleController : ApiControllerBase
    {
        public SaleController(IMediator mediator) : base(mediator)
        {
        }

        public async Task<ActionResult> Index(string SearchString = null, string SortOrder = "date_desc",
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

            var sales = await _mediator.Send(new GetSaleOrdersQuery()
            {
                searchString = SearchString,
                pageNumber = PageNumber,
                sortOrder = SortOrder,
                pageSize = PageSize,
                currentFilter = CurrentFilter
            });

            return View(sales);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateSaleOrderDto item = new CreateSaleOrderDto();
            item.ListSaleProducts.Add(new CreateSaleOrderDetailDto() { Id = 1 });
            var command = new GetCustomersQuery();
            var response = await _mediator.Send(command);
            var command1 = new GetProductsQuery();
            var response1 = await _mediator.Send(command1);
            ViewData["CustomerId"] = new SelectList(response, "Id", "CustomerName");
            ViewData["ProductId"] = new SelectList(response1, "Id", "Title");
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] CreateSaleOrderDto createSaleOrderDto)
        {
            var command = new CreateSaleOrderCommand { SaleOrderDto = createSaleOrderDto };
            var response = await _mediator.Send(command);
            return RedirectToAction("Index", "Sale");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int Id)
        {
            var command = new GetDetailSaleOrderQuery() { Id = Id };
            var reponse = await _mediator.Send(command);
            return View(reponse);
        }
    }
}
