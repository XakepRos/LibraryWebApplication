using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using LibraryWebApplication.Authorization;
using LibraryWebApplication.Departments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApplication.Departments
{
    [AbpAuthorize(PermissionNames.Pages_Departments)]
    public class DepartmentService : CrudAppService<Department, DepartmentDto>
    {
        public DepartmentService(IRepository<Department, int> repository) : base(repository)
        {
        }
    }
}
