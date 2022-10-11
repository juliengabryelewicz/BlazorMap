using BlazorMap.Shared.Entities;
using BlazorMap.Shared.Helpers;

namespace BlazorMap.Client.Services.Categories
{
   public interface ICategoryService
    {
        event Action CategoriesChanged;
        List<Category> Categories { get; set; }
        List<Category> AdminCategories { get; set; }
        string Message { get; set; }
        int CurrentPage { get; set; }
        int PageCount { get; set; }
        Task GetCategories();
        Task<ServiceResponse<Category>> GetCategory(int categoryId);
        Task GetAdminCategories();
        Task<Category> CreateCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task DeleteCategory(Category category);
    }
}
