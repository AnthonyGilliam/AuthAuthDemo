using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Profile;
using System.Web.Security;
using WebMatrix.WebData;
using AuthAuthDemo.Web.ModelHelpers;

namespace AuthAuthDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private UserModelHelper _userHelper;

        public HomeController()
        {
            _userHelper = new UserModelHelper();
        }

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

        [HttpGet]
        public ActionResult ShowUsers()
        {
            var users = _userHelper.GetAllUsers();

            return View(users);
        }
    }
}