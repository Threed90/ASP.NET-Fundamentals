using Library.Data;
using Library.Models.Category;
using Microsoft.EntityFrameworkCore;
using Library.Services.Interfaces;

namespace Library.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly LibraryDbContext data;
        public CategoryService(LibraryDbContext data)
        {
            this.data = data;
        }
        public async Task<List<CategoryViewModel>> GetAllAsync()
        {
            return await this.data.Categories
                .AsNoTracking()
                .Select(g => new CategoryViewModel()
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();
        }
    }
}
