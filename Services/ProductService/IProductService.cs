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
        string Message { get; set; }
        int CurrentPage { get; set; }
        int TotalPages { get; set; }
        string LastSearchText { get; set; }
        Task GetAllProducts();
        Task<ServiceResponse<Product>> GetProductByIdAsync(int productId);
        Task GetProductsByCategory(string categoryUrl);        
        Task SearchProducts(string searchText);
        Task SearchProductsWithPagination(string searchText, int page);
        Task<List<string>> SearchProductsSuggestions(string searchText);
        Task GetFeaturedProducts();
    }
}
