using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace LibraryWebApplication.Authorization
{
    public class LibraryWebApplicationAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, displayName: L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Departments, displayName: L("Departments"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, LibraryWebApplicationConsts.LocalizationSourceName);
        }
    }
}


