using System.ComponentModel.DataAnnotations;

namespace krabs.Application.ViewModels.UserViewModels
{
    public class SaveUserRoleViewModel
    {
        [Required]
        public string Role { get; set; }
        [Required]
        public string Username { get; set; }
    }
}