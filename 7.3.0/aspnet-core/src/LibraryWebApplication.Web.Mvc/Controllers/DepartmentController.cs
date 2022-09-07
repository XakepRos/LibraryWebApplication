using Abp.Application.Services.Dto;
using LibraryWebApplication.Controllers;
using LibraryWebApplication.Departments;
using LibraryWebApplication.Departments.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LibraryWebApplication.Web.Controllers
{
    public class DepartmentController : LibraryWebApplicationControllerBase
    {
        private readonly DepartmentService _departmentService;
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> EditModal(int deptId)
        {     
            var deptDto = _departmentService.EditDepartment(deptId);
            return PartialView("_EditModal", deptDto);      
        }
    }
}
