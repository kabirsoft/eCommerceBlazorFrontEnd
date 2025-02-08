using Microsoft.AspNetCore.Components;
using eCommerceBlazorFrontEnd.Components.SharedPages.User;
using eCommerceBlazorFrontEnd.Services.AuthService;
using Blazored.LocalStorage;


namespace eCommerceBlazorFrontEnd.Components.Pages
{
    public partial class Login : ComponentBase
    {
        [Inject]
        private IAuthService authService { get; set; }
        [Inject]
        private NavigationManager navigationManager { get; set; }
        [Inject]
        private ILocalStorageService localStorageService { get; set; }

        private UserLogin user = new UserLogin();
        private string errorMessage = string.Empty;

        private async Task HandleLogin()
        {
            var result = await authService.Login(user);
            if (result.Success)
            {
                await localStorageService.SetItemAsync("authToken", result.Data);
                navigationManager.NavigateTo("/");
            }
            else
            {
                errorMessage = result.Message;
            }
        }
    }
}

