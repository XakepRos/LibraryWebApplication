using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApplication.Departments.Dto
{
    [AutoMapTo(typeof(Department))]
    public class CreateDepartmentDto: EntityDto/*, IHasCreationTime*/
    {
        [Required]
        public string DepartmentName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Remarks { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsActive { get; set; }
       
    }
}
