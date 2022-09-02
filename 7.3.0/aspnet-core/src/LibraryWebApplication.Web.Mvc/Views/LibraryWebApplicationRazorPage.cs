using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace LibraryWebApplication.Web.Views
{
    public abstract class LibraryWebApplicationRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected LibraryWebApplicationRazorPage()
        {
            LocalizationSourceName = LibraryWebApplicationConsts.LocalizationSourceName;
        }
    }
}
