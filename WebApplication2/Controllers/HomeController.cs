using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //protected override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    //base.OnAuthorization(filterContext);
        //    if (!filterContext.RequestContext.HttpContext.User.IsInRole("Admin"))
        //        filterContext.Result = new ViewResult { ViewName = "Error" };
        //}
    }
}