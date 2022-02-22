using POS.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POS.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        Task<Category> GetCategoryByIdAsync(long categoryId);

        Task InsertCategoryAsync(Category category);

        Task UpdateCategoryAsync(Category category);

        Task DeleteCategoryAsync(Category category);
    }
}
