using eCommerceBlazorFrontEnd.Services.ProductService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace eCommerceBlazorFrontEnd.Components.SharedPages
{
    public partial class Search
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IProductService ProductService { get; set; }
        private string searchText = string.Empty;
        private List<string> suggestions = new List<string>();
        protected ElementReference searchInput;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await searchInput.FocusAsync();
            }
        }
        public async Task SearchProducts()
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                NavigationManager.NavigateTo($"/product/search/{searchText}");
            }
        }
        public async Task HandleSearch(KeyboardEventArgs e)
        {
            Console.WriteLine($"Key pressed: {e.Key}");
            if (e.Key == null || e.Key.Equals("Enter"))
            {
                await SearchProducts();
            }
            else if (searchText.Length > 1)
            {
                suggestions = await ProductService.SearchProductsSuggestions(searchText);
            }
        }
    }
}
