using System.Threading.Tasks;
using LibraryWebApplication.Configuration.Dto;

namespace LibraryWebApplication.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
