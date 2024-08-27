using eCommerceBlazorFrontEnd.Models;
using Microsoft.AspNetCore.Components;

namespace eCommerceBlazorFrontEnd.Components.Shared
{
    public partial class ProductList
    {
        private static List<Product> products = new List<Product>();

        [Inject]
        private HttpClient Http { get; set; }
        protected override async Task OnInitializedAsync()
        {
            //Console.WriteLine($"[INFO] Base address:{Http.BaseAddress}");

            var result = await Http.GetFromJsonAsync<List<Product>>("api/product");
            if(result != null)
            {
                products = result;
            }
        }
    }
}
