using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace LibraryWebApplication.Controllers
{
    public abstract class LibraryWebApplicationControllerBase: AbpController
    {
        protected LibraryWebApplicationControllerBase()
        {
            LocalizationSourceName = LibraryWebApplicationConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
