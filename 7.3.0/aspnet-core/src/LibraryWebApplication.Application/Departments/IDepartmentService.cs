using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LibraryWebApplication.Departments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApplication.Departments
{
    public interface IDepartmentService: IApplicationService
    {
        void CreateDepartment(DepartmentDto input);
        Task DeleteDepartment(int deptId);
        Task EditDepartment(int deptId);
        Task GetDepartment(int deptId);
        Task GetAllDepartment();

    }
}
