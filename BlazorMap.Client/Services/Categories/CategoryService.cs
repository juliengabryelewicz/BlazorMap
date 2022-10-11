using BlazorMap.Shared.Entities;
using BlazorMap.Shared.Helpers;
using System.Net.Http.Json;

namespace BlazorMap.Client.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public List<Category> Categories { get; set; } = new List<Category>();
        public string Message { get; set; } = "Loading categories...";
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public List<Category> AdminCategories { get; set; }

        public event Action CategoriesChanged;

        public async Task<Category> CreateCategory(Category category)
        {
            var result = await _http.PostAsJsonAsync("api/Category", category);
            var newCategory = (await result.Content
                .ReadFromJsonAsync<ServiceResponse<Category>>()).Data;
            return newCategory;
        }

        public async Task DeleteCategory(Category category)
        {
            var result = await _http.DeleteAsync($"api/Category/{category.Id}");
        }

        public async Task GetAdminCategories()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category/admin");
            AdminCategories = result.Data;
            CurrentPage = 1;
            PageCount = 0;
            if (AdminCategories.Count == 0)
                Message = "No categories found.";
        }

        public async Task<ServiceResponse<Category>> GetCategory(int categoryId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Category>>($"api/Category/{categoryId}");
            return result;
        }

        public async Task GetCategories()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category");
            if (result != null && result.Data != null)
                Categories = result.Data;

            CurrentPage = 1;
            PageCount = 0;

            if (Categories.Count == 0)
                Message = "No categories found";

            CategoriesChanged.Invoke();
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            var result = await _http.PutAsJsonAsync($"api/Category", category);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<Category>>();
            return content.Data;
        }
    }
}
