using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using LibraryWebApplication.Authorization.Users;
using LibraryWebApplication.Editions;

namespace LibraryWebApplication.Departments
{
    public class DepartmentManager: Department
    {
        public DepartmentManager(
                  IRepository<Department> departmentRepository)
                  : base(
                      departmentRepository
                  
                     )
        {
        }
    }
}