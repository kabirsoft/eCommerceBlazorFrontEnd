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
    }
}
