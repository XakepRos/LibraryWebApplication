using Abp.AspNetCore.Mvc.ViewComponents;

namespace LibraryWebApplication.Web.Views
{
    public abstract class LibraryWebApplicationViewComponent : AbpViewComponent
    {
        protected LibraryWebApplicationViewComponent()
        {
            LocalizationSourceName = LibraryWebApplicationConsts.LocalizationSourceName;
        }
    }
}
