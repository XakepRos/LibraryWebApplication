using System.Threading.Tasks;
using Abp.Application.Services;
using LibraryWebApplication.Sessions.Dto;

namespace LibraryWebApplication.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
