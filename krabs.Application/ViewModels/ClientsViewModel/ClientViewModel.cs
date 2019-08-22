using System.ComponentModel.DataAnnotations;
using IdentityServer4.Models;

namespace krabs.Application.ViewModels.ClientsViewModel
{
    public class ClientViewModel : Client
    {
        [Required]
        public string OldClientId { get; set; }
    }
}
