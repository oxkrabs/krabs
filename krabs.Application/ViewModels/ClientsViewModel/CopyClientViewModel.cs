using System.ComponentModel.DataAnnotations;

namespace krabs.Application.ViewModels.ClientsViewModel
{
    public class CopyClientViewModel
    {
        [Required]
        public string ClientId { get; set; }

    }
}