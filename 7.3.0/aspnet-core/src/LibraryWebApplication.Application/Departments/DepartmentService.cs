using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using LibraryWebApplication.Authorization;
using LibraryWebApplication.Authorization.Users;
using LibraryWebApplication.Departments.Dto;
using LibraryWebApplication.Users.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApplication.Departments
{
    //[AbpAuthorize(PermissionNames.Pages_Departments)]
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _departmentRepository;

        public DepartmentService(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        
        public void CreateDepartment(DepartmentDto input)
        {
            var department = _departmentRepository.FirstOrDefault(p => p.DepartmentName == input.DepartmentName);
            if (department != null)
            {
                throw new UserFriendlyException("Department is already exists!");
            }

            department = new Department {  DepartmentName = input.DepartmentName, Description = input.Description };
            _departmentRepository.Insert(department);
        }

        public Task GetAllDepartment()
        {
            //return await _departmentRepository.GetAllListAsync();
            throw new NotImplementedException();
        }

        public Task GetDepartment(int deptId)
        {
            throw new NotImplementedException();
        }

        public Task EditDepartment(int deptId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDepartment(int deptId)
        {
            throw new NotImplementedException();
        }

      
    }
}
