using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using LibraryWebApplication.Authorization;
using LibraryWebApplication.Controllers;
using LibraryWebApplication.Departments;
using LibraryWebApplication.Departments.Dto;
using LibraryWebApplication.EntityFrameworkCore;
using LibraryWebApplication.MultiTenancy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using static LibraryWebApplication.Authorization.Roles.StaticRoleNames;

namespace LibraryWebApplication.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Departments)]
    public class DepartmentController : LibraryWebApplicationControllerBase
    {
        private readonly IDepartmentAppService _departmentAppService;

        public DepartmentController(IDepartmentAppService departmentAppService)
        {
            _departmentAppService = departmentAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> EditModal(int deptId)
        {
            var deptDto = await _departmentAppService.GetAsync(new EntityDto(deptId));
            return PartialView("_EditModal", deptDto);
        }
    }
}
