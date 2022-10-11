using BlazorMap.Server.Contexts;
using BlazorMap.Shared.Entities;
using BlazorMap.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BlazorMap.Server.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<Category>> CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Category> { Data = category };
        }

        public async Task<ServiceResponse<bool>> DeleteCategory(int categoryId)
        {
            var dbCategory = await _context.Categories.FindAsync(categoryId);
            if (dbCategory == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Category not found."
                };
            }
            
            _context.Remove(dbCategory);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<Category>> GetCategoryAsync(int categoryId)
        {
            var response = new ServiceResponse<Category>();
            Category category = null;

            category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

            if (category == null)
            {
                response.Success = false;
                response.Message = "Sorry, but this category does not exist.";
            }
            else
            {
                response.Data = category;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Category>>> GetCategoriesAsync()
        {
            var response = new ServiceResponse<List<Category>>
            {
                Data = await _context.Categories.ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<Category>> UpdateCategory(Category category)
        {
            var dbCategory = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == category.Id);

            if (dbCategory == null)
            {
                return new ServiceResponse<Category>
                {
                    Success = false,
                    Message = "Category not found."
                };
            }

            dbCategory.Title = category.Title;

            await _context.SaveChangesAsync();
            return new ServiceResponse<Category> { Data = category };
        }

    }
}
