using eCommerceBlazorFrontEnd.Models;
using eCommerceWebApiBackEnd.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerceBlazorFrontEnd.Services.ProductService
{
    public interface IProductService
    {
        event Action ProductsChanged;
        List<Product> Products { get; set; }
        Task GetAllProducts();
        Task<ServiceResponse<Product>> GetProductByIdAsync(int productId);
        Task GetProductsByCategory(string categoryUrl);
    }
}
