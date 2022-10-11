using BlazorMap.Shared.Entities;
using BlazorMap.Shared.Helpers;

namespace BlazorMap.Server.Services.Categories
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<Category>>> GetCategoriesAsync();
        Task<ServiceResponse<Category>> GetCategoryAsync(int categoryId);
        Task<ServiceResponse<Category>> CreateCategory(Category category);
        Task<ServiceResponse<Category>> UpdateCategory(Category category);
        Task<ServiceResponse<bool>> DeleteCategory(int categoryId);
    }
}
