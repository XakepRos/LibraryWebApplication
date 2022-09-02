using Abp.AutoMapper;
using LibraryWebApplication.Roles.Dto;
using LibraryWebApplication.Web.Models.Common;

namespace LibraryWebApplication.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
