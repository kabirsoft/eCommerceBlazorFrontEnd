using eCommerceBlazorFrontEnd.Components.SharedPages.User;
using eCommerceWebApiBackEnd.Shared;

namespace eCommerceBlazorFrontEnd.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> AddUser(UserRegister newUser);
    }
}
