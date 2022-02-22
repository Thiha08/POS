using Microsoft.EntityFrameworkCore;
using POS.Core.Entities;
using POS.Infrastructure.Data;
using POS.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POS.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepo;

        public CategoryService(IRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            List<Category> categories = await _categoryRepo.GetAll().ToListAsync();
            return categories;
        }

        public async Task<Category> GetCategoryByIdAsync(long categoryId)
        {
            Category category = await _categoryRepo.GetByIdAsync(categoryId);
            return category;
        }

        public async Task InsertCategoryAsync(Category category)
        {
            await _categoryRepo.InsertAsync(category);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _categoryRepo.UpdateAsync(category);
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            await _categoryRepo.DeleteAsync(category);
        }
    }
}
