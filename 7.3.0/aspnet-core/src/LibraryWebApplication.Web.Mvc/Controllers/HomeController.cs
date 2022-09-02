using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using LibraryWebApplication.Controllers;

namespace LibraryWebApplication.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : LibraryWebApplicationControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
