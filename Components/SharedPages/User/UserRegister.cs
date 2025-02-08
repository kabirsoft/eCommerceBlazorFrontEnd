using System.ComponentModel.DataAnnotations;

namespace eCommerceBlazorFrontEnd.Components.SharedPages.User
{
    public class UserRegister
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
