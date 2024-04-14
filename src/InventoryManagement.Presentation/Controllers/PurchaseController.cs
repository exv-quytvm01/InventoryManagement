using InventoryManagement.Application.Dto.ProductionOrderDetails;
using InventoryManagement.Application.Dto.ProductOrders;
using InventoryManagement.Application.Featurers.ProductionOrders.Commands.Create;
using InventoryManagement.Application.Featurers.ProductionOrders.Queries.GetDetailPro;
using InventoryManagement.Application.Featurers.ProductionOrders.Queries.GetProOrders;
using InventoryManagement.Application.Featurers.Products.Queries.GetProducts;
using InventoryManagement.Application.Featurers.Suppliers.Queries.GetSuppliers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagement.Presentation.Controllers
{
    public class PurchaseController : ApiControllerBase
    {
        public PurchaseController(IMediator mediator) : base(mediator)
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

            var purchases = await _mediator.Send(new GetProOrdersQuery()
            {
                searchString = SearchString,
                pageNumber = PageNumber,
                sortOrder = SortOrder,
                pageSize = PageSize,
                currentFilter = CurrentFilter
            });

            return View(purchases);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateProductOrderDto item = new CreateProductOrderDto();
            item.ListProductOrders.Add(new CreateProductionOrderDetailDto() { Id = 1 });
            var command = new GetSuppliersQuery();
            var response = await _mediator.Send(command);
            var command1 = new GetProductsQuery();
            var response1 = await _mediator.Send(command1);
            ViewData["SupplierId"] = new SelectList(response, "Id", "SupplierName");
            ViewData["ProductId"] = new SelectList(response1, "Id", "Title");
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] CreateProductOrderDto createProductOrder)
        {
            var command = new CreateProductOrderCommand { ProductOrderDto = createProductOrder };
            var response = await _mediator.Send(command);
            return RedirectToAction("Index", "Purchase");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int Id)
        {
            var command = new GetDetailProOrderQuery() { Id = Id };
            var reponse = await _mediator.Send(command);
            return View(reponse);
        }

    }
}
