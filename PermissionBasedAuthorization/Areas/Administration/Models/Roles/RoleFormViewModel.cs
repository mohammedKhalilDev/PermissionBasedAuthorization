using System.ComponentModel.DataAnnotations;

namespace PermissionBasedAuthorization.Areas.Administration.Models.Roles
{
    public class RoleFormViewModel
    {
        [Required, StringLength(256)]
        public string Name { get; set; }
    }
}
