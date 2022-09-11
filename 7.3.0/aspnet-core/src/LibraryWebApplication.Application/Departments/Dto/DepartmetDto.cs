using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LibraryWebApplication.MultiTenancy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApplication.Departments.Dto
{
    [AutoMapTo(typeof(Department))]
    public class DepartmentDto : EntityDto<int>
    {
        [Required]
        public string DepartmentName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Remarks { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
