using eCommerceBlazorFrontEnd.Components.SharedPages.Cart;
using eCommerceBlazorFrontEnd.Dto;

namespace eCommerceBlazorFrontEnd.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddItemToCart(CartItem cartItem);
        Task<List<CartItem>> GetCartItems();
        Task<List<CartProductResponseDto>> GetCartProducts();
    }
}
