using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PermissionBasedAuthorization.Core.Constants
{
    public static class Permissions
    {
        public static Dictionary<string, List<string>> GenerateAllPermissionsGroupedByModule()
        {
            var permissionTypes = new List<Type> { typeof(Users), typeof(Roles), typeof(Home) }; // Add other permission classes here
            var groupedPermissions = new Dictionary<string, List<string>>();

            foreach (var permissionType in permissionTypes)
            {
                var moduleName = permissionType.Name;
                var fields = permissionType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

                var permissions = fields.Select(field => field.GetValue(null)?.ToString())
                                        .Where(permission => !string.IsNullOrEmpty(permission))
                                        .ToList();

                if (permissions.Any())
                {
                    groupedPermissions.Add(moduleName, permissions);
                }
            }

            return groupedPermissions;
        }

        public static class Users
        {
            public const string View = "Permissions.Users.View";
            public const string Create = "Permissions.Users.Create";
            public const string Edit = "Permissions.Users.Edit";
            public const string Delete = "Permissions.Users.Delete";
        }
        public static class Roles
        {
            public const string View = "Permissions.Roles.View";
            public const string Create = "Permissions.Roles.Create";
            public const string Edit = "Permissions.Roles.Edit";
            public const string Delete = "Permissions.Roles.Delete";
            public const string ManageRolePermissions = "Permissions.Roles.ManageRolePermissions";
        }
        public static class Home
        {
            public const string View = "Permissions.Home.View";
            public const string Create = "Permissions.Home.Create";
            public const string Edit = "Permissions.Home.Edit";
            public const string Delete = "Permissions.Home.Delete";
        }
    }

}
