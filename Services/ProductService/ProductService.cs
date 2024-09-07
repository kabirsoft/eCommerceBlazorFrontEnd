using eCommerceBlazorFrontEnd.Models;
using eCommerceWebApiBackEnd.Shared;


namespace eCommerceBlazorFrontEnd.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService( HttpClient http)
        {
            _http = http;
        }
        public List<Product> Products { get; set; } = new List<Product>();

        public event Action ProductsChanged;

        public async Task GetAllProducts()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product");
                
            if (result != null && result.Data != null)
            {
                Products = result.Data;
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
            ProductsChanged?.Invoke();
        }

        public async Task<ServiceResponse<Product>> GetProductByIdAsync(int productId)
        {
            var reslult = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
            return reslult;
        }
    }
}
