using Library.Models.Category;

namespace Library.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<CategoryViewModel>> GetAllAsync();
    }
}
