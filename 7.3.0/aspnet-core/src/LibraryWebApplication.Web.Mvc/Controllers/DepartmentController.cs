using Abp.Application.Services.Dto;
using LibraryWebApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LibraryWebApplication.Web.Controllers
{
    public class DepartmentController : LibraryWebApplicationControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        //public async Task<ActionResult> EditModal(int tenantId)
        //{
        //    var tenantDto = await _tenantAppService.GetAsync(new EntityDto(tenantId));
        //    return PartialView("_EditModal", tenantDto);
        //}
    }
}
