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
        string CategoryUrl { get; set; }

        Task GetAllProductsWithPagination(int page);
        Task<ServiceResponse<Product>> GetProductByIdAsync(int productId);
        Task GetProductsByCategoryWithPagination(string categoryUrl, int page);
        Task GetFeaturedProductsWithPagination(int page);
        Task SearchProductsWithPagination(string searchText, int page);
        Task<List<string>> SearchProductsSuggestions(string searchText);

        // These are not used now, becoz pagination functonality is implemented
        Task GetAllProducts();
        Task GetProductsByCategory(string categoryUrl);
        Task SearchProducts(string searchText);
        Task GetFeaturedProducts();
        // End These are not used now, becoz pagination functonality is implemented

    }
}
