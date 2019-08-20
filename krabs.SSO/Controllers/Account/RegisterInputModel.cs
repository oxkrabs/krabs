using System.ComponentModel.DataAnnotations;

namespace krabs.SSO.Controllers.Account
{
    public class RegisterInputModel
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        public string ReturnUrl { get; set; }
    }
}