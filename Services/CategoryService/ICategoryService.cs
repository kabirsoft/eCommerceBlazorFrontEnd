using eCommerceBlazorFrontEnd.Models;

namespace eCommerceBlazorFrontEnd.Services.CategoryService
{
    public interface ICategoryService
    {
        List<Category> Categories { get; set; }
        Task GetAllCategories();
    }
}
