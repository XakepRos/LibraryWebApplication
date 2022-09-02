using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using LibraryWebApplication.Configuration;
using LibraryWebApplication.Web;

namespace LibraryWebApplication.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class LibraryWebApplicationDbContextFactory : IDesignTimeDbContextFactory<LibraryWebApplicationDbContext>
    {
        public LibraryWebApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LibraryWebApplicationDbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            LibraryWebApplicationDbContextConfigurer.Configure(builder, configuration.GetConnectionString(LibraryWebApplicationConsts.ConnectionStringName));

            return new LibraryWebApplicationDbContext(builder.Options);
        }
    }
}
