using InventoryManagement.Application.Dto.Categories;
using InventoryManagement.Application.Featurers.Categories.Commands.Create;
using InventoryManagement.Application.Featurers.Categories.Commands.Delete;
using InventoryManagement.Application.Featurers.Categories.Commands.Update;
using InventoryManagement.Application.Featurers.Categories.Queries.GetCateById;
using InventoryManagement.Application.Featurers.Categories.Queries.GetCategories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Presentation.Controllers
{
   
    [Authorize]
    public class CategoryController : ApiControllerBase
    {
        public CategoryController(IMediator mediator) : base(mediator)
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

            var categories = await _mediator.Send(new GetCategoriesQuery()
            {
                searchString = SearchString,
                pageNumber = PageNumber,
                sortOrder = SortOrder,
                pageSize = PageSize,
                currentFilter = CurrentFilter
            });
            
            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] CreateCategoryDto categoryDto)
        {
            var command = new CreateCategoryCommand { CategoryDto = categoryDto };
            var response = await _mediator.Send(command);
            return RedirectToAction("Index","Category");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commandps = new GetCategoryByIdQuery() { Id = id };
            var response = await _mediator.Send(commandps);
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] CategoryDto category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var command = new UpdateCategoryCommand()
                {
                    CategoryDto = category
                };
                var response = await _mediator.Send(command);

                return RedirectToAction("Index", "Category");
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(int id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var commandps = new GetCategoryByIdQuery() { Id = id };
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
            var command = new DeleteCategoryComand() { Id = id };
            var response = await _mediator.Send(command);
            return RedirectToAction("Index", "Category");
        }
    }
}
