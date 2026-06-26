using Microsoft.AspNetCore.Mvc;
using Ticketora.Application.Features.CQRSDesignPattern.Categories.Commands;
using Ticketora.Application.Features.CQRSDesignPattern.Categories.Handlers;

namespace Ticketora.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly GetByIdCategoryQueryHandler _getByIdCategoryQueryHandler;

        public CategoryController(CreateCategoryCommandHandler createCategoryCommandHandler, 
            UpdateCategoryCommandHandler updateCategoryCommandHandler, 
            RemoveCategoryCommandHandler removeCategoryCommandHandler, 
            GetCategoryQueryHandler getCategoryQueryHandler, GetByIdCategoryQueryHandler getByIdCategoryQueryHandler)
        {
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _getByIdCategoryQueryHandler = getByIdCategoryQueryHandler;
        }

        public async Task<IActionResult> CategoryList()
        {
            var values = await _getCategoryQueryHandler.Handle();
            return View(values);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _createCategoryCommandHandler.Handle(command);
            return RedirectToAction("CategoryList");
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand { CategoryId = id });
            return RedirectToAction("CategoryList");
        }
    }
}
