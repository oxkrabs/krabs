using System.ComponentModel.DataAnnotations;

namespace krabs.Application.ViewModels.UserViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        public string UsernameOrEmail { get; set; }
    }
}
