using eCommerceBlazorFrontEnd.Models;
using eCommerceBlazorFrontEnd.Services.ProductService;
using Microsoft.AspNetCore.Components;

namespace eCommerceBlazorFrontEnd.Components.Pages
{
    public partial class ProductDetails
    {
        private Product? product = null;
        private string message = string.Empty;
        private int CurrentTypeId = 1;        

        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }
        
        protected override async Task OnParametersSetAsync()
        {
            message = "Loading product...";
            var result = await ProductService.GetProductByIdAsync(Id);
            if( !result.Success )
            {
                message = result.Message;
            }
            else
            {
                product = result.Data;
                if(product.ProductVariant.Count > 0)
                {
                    CurrentTypeId = product.ProductVariant[0].ProductTypeId;
                }
            }
        }
        private ProductVariant GetSelectedVariant()
        {
            var variant = product?.ProductVariant.FirstOrDefault(v => v.ProductTypeId == CurrentTypeId);
            return variant;
        }     
    }
}
