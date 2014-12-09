using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Itransition.My;

namespace Itransition.Controllers
{
    public class HomeController : Controller
    {
        private GlobalRepository r = new GlobalRepository();

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult AllUsers()
        {
            var users = r.GetAllUsers();
            return View(users);
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

        public ActionResult Profile(string id)
        {
            var user = r.GetUser(id);
            return View(user);
        }
    }
}