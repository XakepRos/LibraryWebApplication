using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Repositories;
using Abp.Modules;
using Abp.Timing;
using LibraryWebApplication.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApplication.Departments
{
    public class Department: Entity
    {
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreationTime { get; set; }
        public IRepository<Department> DepartmentRepository { get; }
    }

    
}
