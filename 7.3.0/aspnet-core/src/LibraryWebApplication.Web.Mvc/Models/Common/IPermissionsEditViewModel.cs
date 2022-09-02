using System.Collections.Generic;
using LibraryWebApplication.Roles.Dto;

namespace LibraryWebApplication.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}