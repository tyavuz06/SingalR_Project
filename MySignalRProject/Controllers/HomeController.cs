using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySignalRProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login()
        {
            HttpCookie cookie = new HttpCookie("user", (GameUser._connections.Count).ToString());
            cookie.Expires = DateTime.Now.AddSeconds(2);
            Response.Cookies.Add(cookie);
            return Json("1");
        }
    }
}