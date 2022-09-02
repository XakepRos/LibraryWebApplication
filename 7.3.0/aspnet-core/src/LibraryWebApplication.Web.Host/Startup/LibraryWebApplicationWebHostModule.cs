using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LibraryWebApplication.Configuration;

namespace LibraryWebApplication.Web.Host.Startup
{
    [DependsOn(
       typeof(LibraryWebApplicationWebCoreModule))]
    public class LibraryWebApplicationWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public LibraryWebApplicationWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LibraryWebApplicationWebHostModule).GetAssembly());
        }
    }
}
