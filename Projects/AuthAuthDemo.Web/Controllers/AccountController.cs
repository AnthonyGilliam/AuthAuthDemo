using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using AuthAuthDemo.Web.Models;
using AuthAuthDemo.Web.ModelHelpers;

namespace AuthAuthDemo.Web.Controllers
{
    public class AccountController : Controller
    {
        private UserModelHelper _userHelper;

        public AccountController()
        {
            _userHelper = new UserModelHelper();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var loggedIn = WebSecurity.Login(model.Email, model.Password, true);
                    if(loggedIn)
                    {
                        return RedirectToAction("ShowUsers", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "Sorry, the Email address and Password provided are incorrect.  " +
                            "Please check your inputs and try again.");
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError("Email", "Sorry, An error occured while logging in with the given Email address and Password.  " +
                        "Please try again later");
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            var errors = new List<string>();

            if (!ModelState.IsValid)
            {
                errors = ModelState.Values
                    .Aggregate(new List<string>(), (errs, value) =>
                    {
                        errs.AddRange(value.Errors
                            .Aggregate(new List<string>(), (messages, msg) => { messages.Add(msg.ErrorMessage); return messages; }));
                        
                        return errs;
                    });

                return Json(new { success = false, errors = errors });
            }
            try
            {
                //TODO: Get rid of this WebMatrix shit and put in a real membership provider that actually works when you set it up.
                if (!WebSecurity.UserExists(model.Email))
                {
                    WebSecurity.CreateUserAndAccount(model.Email, model.Password);
                    WebSecurity.Login(model.Email, model.Password, true);
                    _userHelper.UpdateUser(model);
                    return Json(new { success = true });
                }

                return Json(new { success = false, errors = new[] { "The Email address provided already exists.  " +
                    "Please Login or enter a different email address." }});
            }
            catch(Exception ex)
            {
                 return Json(new { success = false, errors = new[] { "Sorry, but this Email address and Password cannot be registered at this time.  " + 
                    "Please try again later."}});
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }
    }
}