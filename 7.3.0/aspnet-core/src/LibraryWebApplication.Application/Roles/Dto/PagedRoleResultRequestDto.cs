using Abp.Application.Services.Dto;

namespace LibraryWebApplication.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

