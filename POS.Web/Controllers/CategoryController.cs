using Microsoft.AspNetCore.Mvc;
using POS.Core.Entities;
using POS.Services.Interfaces;
using POS.Web.ViewModels.Category;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            IEnumerable<Category> categories = await _categoryService.GetAllCategoriesAsync();

            IEnumerable<CategoryOverviewViewModel> viewModels =
                categories.Select(x => new CategoryOverviewViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                });

            return View(viewModels);
        }

        [HttpGet]
        public async Task<ActionResult> Details(long id)
        {
            Category category = await _categoryService.GetCategoryByIdAsync(id);

            var viewModel = new CategoryDetailViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                CreatedOnUtc = category.CreatedOnUtc,
                UpdatedOnUtc = category.UpdatedOnUtc
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var viewModel = new CategoryCreateViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CategoryCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var category = new Category
            {
                Name = viewModel.Name,
                Description = viewModel.Description
            };

            await _categoryService.InsertCategoryAsync(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Edit(long id)
        {
            Category category = await _categoryService.GetCategoryByIdAsync(id);

            var viewModel = new CategoryEditViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CategoryEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            Category category = await _categoryService.GetCategoryByIdAsync(viewModel.Id);

            category.Name = viewModel.Name;
            category.Description = viewModel.Description;

            await _categoryService.UpdateCategoryAsync(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Delete(long id)
        {
            Category category = await _categoryService.GetCategoryByIdAsync(id);
            await _categoryService.DeleteCategoryAsync(category);
            return RedirectToAction(nameof(Index));
        }
    }
}
