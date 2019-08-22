using System.ComponentModel.DataAnnotations;

namespace krabs.Application.ViewModels.ClientsViewModel
{
    public class SaveClientPropertyViewModel
    {
        [Required]
        public string Value { get; set; }
        [Required]
        public string Key { get; set; }
        [Required]
        public string ClientId { get; set; }
    }
}