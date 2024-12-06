using Blazored.LocalStorage;
using eCommerceBlazorFrontEnd.Services.CartService;
using Microsoft.AspNetCore.Components;


namespace eCommerceBlazorFrontEnd.Components.SharedPages.Cart
{
    public partial class CartCounter : IDisposable
    {
        [Inject]
        public ICartService? CartService { get; set; }
        [Inject]
        public ILocalStorageService? LocalStorage { get; set; }
        [Inject]
        public ILogger<CartCounter>? Logger { get; set; }

        private int _cartItemsCount;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                if (CartService != null)
                {
                    CartService.OnChange += UpdateCartCount;
                }

                await UpdateCartCountAsync();
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex, "Failed to load cart items.");
                _cartItemsCount = 0;
            }
        }

        private void UpdateCartCount()
        {
            // Call the asynchronous method and update the state.
            _ = UpdateCartCountAsync();
        }

        private async Task UpdateCartCountAsync()
        {
            if (LocalStorage != null)
            {
                var cart = await LocalStorage.GetItemAsync<List<CartItem>>("cart") ?? new List<CartItem>();
                _cartItemsCount = cart.Count;
                StateHasChanged();
            }
        }

        public int CartItemsCount => _cartItemsCount;

        public void Dispose()
        {
            if (CartService != null)
            {
                CartService.OnChange -= UpdateCartCount;
            }
        }
    }
}
