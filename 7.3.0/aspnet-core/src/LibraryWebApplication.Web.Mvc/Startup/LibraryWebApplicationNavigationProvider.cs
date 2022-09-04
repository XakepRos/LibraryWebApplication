using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using LibraryWebApplication.Authorization;

namespace LibraryWebApplication.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class LibraryWebApplicationNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
               
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fas fa-home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "About",
                        icon: "fas fa-info-circle"
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "Tenants",
                        icon: "fas fa-building",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Tenants)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "fas fa-users",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "fas fa-theater-masks",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles)
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Departments,
                        L("Departments"),
                        url: "Department",
                        icon: "fas fa-building"
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.FileTypes,
                        L("File Types"),
                        url: "Filetypes",
                        icon: "fas fa-file"
                    )
                //)
                //.AddItem( // Menu items below is just for demonstration!
                //    new MenuItemDefinition(
                //        "MultiLevelMenu",
                //        L("MultiLevelMenu"),
                //        icon: "fas fa-circle"
                //    ).AddItem(
                //        new MenuItemDefinition(
                //            "AspNet",
                //            new FixedLocalizableString("ASP.NET"),
                //            icon: "far fa-circle"
                //        ).AddItem(
                //            new MenuItemDefinition(
                //                "AspNetHome",
                //                new FixedLocalizableString("Home"),
                //                url: "",
                //                icon: "far fa-dot-circle"
                //            )
                //        ).AddItem(
                //            new MenuItemDefinition(
                //                "AspNetTemplates",
                //                new FixedLocalizableString("Templates"),
                //                url: "Home",
                //                icon: "far fa-dot-circle"
                //            )
                //        ).AddItem(
                //            new MenuItemDefinition(
                //                "AspNetSamples",
                //                new FixedLocalizableString("Samples"),
                //                url: "Home",
                //                icon: "far fa-dot-circle"
                //            )
                //        ).AddItem(
                //            new MenuItemDefinition(
                //                "AspNetDocuments",
                //                new FixedLocalizableString("Documents"),
                //                url: "Home",
                //                icon: "far fa-dot-circle"
                //            )
                //        )
                //    ).AddItem(
                //        new MenuItemDefinition(
                //            "AspNet",
                //            new FixedLocalizableString("ASP.NET"),
                //            icon: "far fa-circle"
                //        ).AddItem(
                //            new MenuItemDefinition(
                //                "AspNetHome",
                //                new FixedLocalizableString("Home"),
                //                url: "Home",
                //                icon: "far fa-dot-circle"
                //            )
                //        ).AddItem(
                //            new MenuItemDefinition(
                //                "AspNetFeatures",
                //                new FixedLocalizableString("Features"),
                //                url: "Home",
                //                icon: "far fa-dot-circle"
                //            )
                //        ).AddItem(
                //            new MenuItemDefinition(
                //                "AspNetPricing",
                //                new FixedLocalizableString("Pricing"),
                //                url: "",
                //                icon: "far fa-dot-circle"
                //            )
                //        ).AddItem(
                //            new MenuItemDefinition(
                //                "AspNetFaq",
                //                new FixedLocalizableString("Faq"),
                //                url: "",
                //                icon: "far fa-dot-circle"
                //            )
                //        ).AddItem(
                //            new MenuItemDefinition(
                //                "AspNetDocuments",
                //                new FixedLocalizableString("Documents"),
                //                url: "Home",
                //                icon: "far fa-dot-circle"
                //            )
                //        )
                 //   )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, LibraryWebApplicationConsts.LocalizationSourceName);
        }
    }
}