using eCommerceBlazorFrontEnd.Components.SharedPages.User;
using eCommerceWebApiBackEnd.Shared;

namespace eCommerceBlazorFrontEnd.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;

        public AuthService(HttpClient http)
        {
            _http = http;
        }
        public async Task<ServiceResponse<int>> AddUser(UserRegister newUser)
        {
            var result = await _http.PostAsJsonAsync("api/auth/AddUser", newUser);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        public async Task<ServiceResponse<string>> Login(UserLogin user)
        {
            var result = await _http.PostAsJsonAsync("api/auth/Login", user);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();

        }
    }
}
