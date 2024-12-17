using eCommerceBlazorFrontEnd.Components.SharedPages.User;
using eCommerceBlazorFrontEnd.Services.AuthService;
using Microsoft.AspNetCore.Components;

namespace eCommerceBlazorFrontEnd.Components.Pages
{
    public partial class Register
    {
        UserRegister user = new UserRegister();
        string message = string.Empty;
        string messageCssClass = string.Empty;
        [Inject]
        public IAuthService AuthService { get; set; }
    
        public async Task HandleRegistation()
        {
           //Console.WriteLine($"Register user with the email: {user.Email}");
           var result = await AuthService.AddUser(user);
            message = result.Message;
            if (result.Success)
            {
                messageCssClass = "text-success";
            }
            else
            {
                messageCssClass = "text-danger";
            }
        }
    }

}
