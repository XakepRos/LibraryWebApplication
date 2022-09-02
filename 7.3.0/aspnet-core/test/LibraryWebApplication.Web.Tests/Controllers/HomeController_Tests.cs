using System.Threading.Tasks;
using LibraryWebApplication.Models.TokenAuth;
using LibraryWebApplication.Web.Controllers;
using Shouldly;
using Xunit;

namespace LibraryWebApplication.Web.Tests.Controllers
{
    public class HomeController_Tests: LibraryWebApplicationWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}