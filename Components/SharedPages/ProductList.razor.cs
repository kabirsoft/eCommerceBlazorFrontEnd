using eCommerceBlazorFrontEnd.Models;
using eCommerceBlazorFrontEnd.Services.ProductService;
using Microsoft.AspNetCore.Components;

namespace eCommerceBlazorFrontEnd.Components.SharedPages
{
    public partial class ProductList : IDisposable
    {        
        [Inject]
        IProductService ProductService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            ProductService.ProductsChanged += StateHasChanged;            
        }

        public void Dispose()
        {
            ProductService.ProductsChanged -= StateHasChanged;
        }

        private string GetProductPrice(Product product)
        {
            var variants = product.ProductVariant;
            if (variants.Count == 0)
            {
                return string.Empty;
            }
            else if (variants.Count == 1)
            {
                return variants[0].Price.ToString("C");
            }
            decimal minPrice = variants.Min(v => v.Price);
            return $"Starting at {minPrice.ToString("C")}";
        }
    }
}
