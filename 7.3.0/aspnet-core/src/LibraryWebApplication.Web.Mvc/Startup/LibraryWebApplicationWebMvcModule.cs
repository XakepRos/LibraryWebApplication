using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LibraryWebApplication.Configuration;

namespace LibraryWebApplication.Web.Startup
{
    [DependsOn(typeof(LibraryWebApplicationWebCoreModule))]
    public class LibraryWebApplicationWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public LibraryWebApplicationWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<LibraryWebApplicationNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LibraryWebApplicationWebMvcModule).GetAssembly());
        }
    }
}
