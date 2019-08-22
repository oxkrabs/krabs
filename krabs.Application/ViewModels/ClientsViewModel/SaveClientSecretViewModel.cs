using System;
using System.ComponentModel.DataAnnotations;

namespace krabs.Application.ViewModels.ClientsViewModel
{
    public class SaveClientSecretViewModel
    {
        public string Description { get; set; }
        [Required]
        public string Value { get; set; }
        public DateTime? Expiration { get; set; }
        [Required]
        public HashType? Hash { get; set; } = 0;
        [Required]
        public string Type { get; set; }
        [Required]
        public string ClientId { get; set; }
    }
}