using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Services;
using LibraryWebApplication.Departments.Dto;
using LibraryWebApplication.MultiTenancy.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApplication.Departments
{
    public interface IDepartmentService : IAsyncCrudAppService<DepartmentDto, int, PagedDepartmentResultRequestDto, CreateDepartmentDto, DepartmentDto>
    {
       
    }
}
