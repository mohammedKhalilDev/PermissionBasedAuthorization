using PermissionBasedAuthorization.Models;

namespace PermissionBasedAuthorization.Areas.Administration.Models.Users
{
    public class UserRolesViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<CheckBoxViewModel> Roles { get; set; }
    }
}
