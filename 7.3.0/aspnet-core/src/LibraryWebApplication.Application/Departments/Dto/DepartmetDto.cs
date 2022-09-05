using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibraryWebApplication.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApplication.Departments.Dto
{
    [AutoMapTo(typeof(Department))]
    public class DepartmentDto : EntityDto<int>
    {
        public string DepartmentName { get; set; }
        public string Description { get; set; }
    }
}
