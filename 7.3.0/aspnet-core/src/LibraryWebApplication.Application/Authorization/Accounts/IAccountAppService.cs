using System.Threading.Tasks;
using Abp.Application.Services;
using LibraryWebApplication.Authorization.Accounts.Dto;

namespace LibraryWebApplication.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
