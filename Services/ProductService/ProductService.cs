using eCommerceBlazorFrontEnd.Dto;
using eCommerceBlazorFrontEnd.Models;
using eCommerceWebApiBackEnd.Shared;


namespace eCommerceBlazorFrontEnd.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }
        public List<Product> Products { get; set; } = new List<Product>();
        public string Message { get; set; } = "Loading products...";
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;

        public event Action ProductsChanged;

        public async Task GetAllProducts()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product");

            if (result != null && result.Data != null)
            {
                Products = result.Data;
            }
            CurrentPage = 1;
            TotalPages =  0;
            if (Products.Count == 0)
            {
                Message = "No products found";
            }

            ProductsChanged?.Invoke();
        }

        // Method to get products by category
        public async Task GetProductsByCategory(string categoryUrl)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");

            if (result != null && result.Data != null)
            {
                Products = result.Data;
            }
            CurrentPage = 1;
            TotalPages = 0;
            if (Products.Count == 0)
            {
                Message = "No products found";
            }
            ProductsChanged?.Invoke();
        }

        public async Task<ServiceResponse<Product>> GetProductByIdAsync(int productId)
        {
            var reslult = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
            return reslult;
        }

        public async Task SearchProducts(string searchText)
        {
            var result =
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/search/{searchText}");
            if (result != null && result.Data != null)
            {
                Products = result.Data;
            }
            if (Products.Count == 0)
            {
                Message = $"No products found: {searchText}";
            }
            ProductsChanged?.Invoke();
        }
        public async Task SearchProductsWithPagination(string searchText, int page)
        {
            LastSearchText = searchText;
            var result =
                 await _http.GetFromJsonAsync<ServiceResponse<ProductPaginationDto>>($"api/product/search/{searchText}/{page}");
            if (result != null && result.Data != null)
            {
                Products = result.Data.Products;
                CurrentPage = result.Data.CurrentPage;
                TotalPages = result.Data.TotalPages;
            }
            if (Products.Count == 0)
            {
                Message = $"No products found: {searchText}";
            }
            ProductsChanged?.Invoke();
        }

        public async Task<List<string>> SearchProductsSuggestions(string searchText)
        {
            var result =
                 await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/suggestions/{searchText}");
            return result.Data;
        }

        public async Task GetFeaturedProducts()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/featured");

            if (result != null && result.Data != null)
            {
                Products = result.Data;
            }
            ProductsChanged?.Invoke();
        }

       
    }
}
