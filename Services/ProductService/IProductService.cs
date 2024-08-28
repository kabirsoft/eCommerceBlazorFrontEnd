using eCommerceBlazorFrontEnd.Models;
using eCommerceWebApiBackEnd.Shared;

namespace eCommerceBlazorFrontEnd.Services.ProductService
{
    public interface IProductService
    {
        List<Product> Products { get; set; }
        Task GetAllProducts();
        Task<ServiceResponse<Product>> GetProductByIdAsync(int productId);
    }
}
