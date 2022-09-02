using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using LibraryWebApplication.Controllers;

namespace LibraryWebApplication.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : LibraryWebApplicationControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
