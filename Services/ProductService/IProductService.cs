using eCommerceBlazorFrontEnd.Models;

namespace eCommerceBlazorFrontEnd.Services.ProductService
{
    public interface IProductService
    {
        List<Product> Products { get; set; }
        Task GetAllProducts();
    }
}
