using System.ComponentModel.DataAnnotations;

namespace krabs.Application.ViewModels.RoleViewModels
{
    public class RemoveRoleViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
