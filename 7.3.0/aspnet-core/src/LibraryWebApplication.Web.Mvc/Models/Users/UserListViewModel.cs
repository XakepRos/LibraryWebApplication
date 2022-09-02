using System.Collections.Generic;
using LibraryWebApplication.Roles.Dto;

namespace LibraryWebApplication.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
