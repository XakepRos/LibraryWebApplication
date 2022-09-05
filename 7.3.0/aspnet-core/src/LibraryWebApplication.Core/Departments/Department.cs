using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using LibraryWebApplication.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApplication.Departments
{   
    public class Department: Entity<int>
    {
        public string DepartmentName { get; set; }
        public string Description { get; set; }       
    }
}
