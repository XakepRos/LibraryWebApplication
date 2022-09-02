using System.Collections.Generic;
using LibraryWebApplication.Roles.Dto;

namespace LibraryWebApplication.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
