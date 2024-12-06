using eCommerceBlazorFrontEnd.Components.SharedPages.Cart;

namespace eCommerceBlazorFrontEnd.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddItemToCart(CartItem cartItem);
        Task<List<CartItem>> GetCartItems();
    }
}
