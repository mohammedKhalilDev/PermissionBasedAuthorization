using PermissionBasedAuthorization.Models;

namespace PermissionBasedAuthorization.Areas.Administration.Models.Roles
{
    public class PermissionsFormViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public Dictionary<string, List<CheckBoxViewModel>> RoleClaims { get; set; } = new Dictionary<string, List<CheckBoxViewModel>>();

    }
}
