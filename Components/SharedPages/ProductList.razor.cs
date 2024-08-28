using eCommerceBlazorFrontEnd.Models;
using eCommerceBlazorFrontEnd.Services.ProductService;
using eCommerceWebApiBackEnd.Shared;
using Microsoft.AspNetCore.Components;

namespace eCommerceBlazorFrontEnd.Components.SharedPages
{
    public partial class ProductList
    {        
        [Inject]
        IProductService ProductService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await ProductService.GetAllProducts();
        }
    }
}
