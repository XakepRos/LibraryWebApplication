using Abp.Application.Services;
using LibraryWebApplication.MultiTenancy.Dto;

namespace LibraryWebApplication.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

