using System.ComponentModel.DataAnnotations;

namespace krabs.Application.ViewModels.ClientsViewModel
{
    public class RemoveClientViewModel
    {
        [Required]
        public string ClientId { get; set; }

    }
}