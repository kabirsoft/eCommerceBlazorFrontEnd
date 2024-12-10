using eCommerceBlazorFrontEnd.Dto;
using eCommerceBlazorFrontEnd.Services.CartService;
using Microsoft.AspNetCore.Components;

namespace eCommerceBlazorFrontEnd.Components.Pages
{
    public partial class Cart
    {
        List<CartProductResponseDto> CartProducts = null;
        string message = "Loading cart...";
        [Inject]
        public ICartService CartService { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var cartItems = await CartService.GetCartItems();

                if (cartItems.Count == 0)
                {
                    message = "No products in cart";
                    CartProducts = new List<CartProductResponseDto>();
                }
                else
                {
                    CartProducts = await CartService.GetCartProducts();
                }
                StateHasChanged(); // Notify Blazor to update the UI
            }
        }

        private async Task RemoveItemFromCart(int productId, int productTypeId)
        {
            await CartService.RemoveItemFromCart(productId, productTypeId);
            if ((await CartService.GetCartItems()).Count == 0)
            {
                message = "No products in cart";
                CartProducts = new List<CartProductResponseDto>();
            }
            else
            {
                CartProducts = await CartService.GetCartProducts();
            }
            StateHasChanged(); // Notify Blazor to update the UI
        }

        private async Task UpdateQuantity(ChangeEventArgs e, CartProductResponseDto product)
        {
            product.Quantity = int.Parse(e.Value.ToString());
            if (product.Quantity < 1)
            {
                product.Quantity = 1;
            }
            await CartService.UpdateQuantity(product);
            CartProducts = await CartService.GetCartProducts();
            StateHasChanged(); // Notify Blazor to update the UI
        }
    }
}
