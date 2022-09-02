using Abp.Authorization;
using LibraryWebApplication.Authorization.Roles;
using LibraryWebApplication.Authorization.Users;

namespace LibraryWebApplication.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
