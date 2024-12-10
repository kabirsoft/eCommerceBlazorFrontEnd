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
    }
}
