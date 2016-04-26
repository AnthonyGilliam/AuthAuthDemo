using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using AuthAuthDemo.Web.Models;
using AuthAuthDemo.Web.ModelHelpers;
using AuthAuthDemo.Web.Validators;

namespace AuthAuthDemo.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserModelHelper _userHelper;
        private readonly IAccountValidator _accountValidator;
        public AccountController()
        {
            _userHelper = new UserModelHelper();
            _accountValidator = new AccountValidator();
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
            try
            {
                if(!_accountValidator.Validate(ModelState, model))
                    return PartialView("_RegisterForm", model);

                //TODO: Get rid of this WebMatrix shit and put in a real membership provider that actually works when you set it up.
//            if (!WebSecurity.UserExists(model.Email))
//            {
//                WebSecurity.CreateUserAndAccount(model.Email, model.Password);
//                WebSecurity.Login(model.Email, model.Password, true);
//                _userHelper.UpdateUser(model);
//                return Json(new { success = true });
//            }
            }
            catch (Exception ex)
            {
                //TODO: Add logging here
                ModelState.AddModelError(string.Empty, "Sorry, we cannot register you at this time.  Please try again later.");
            }

            return PartialView("_RegisterForm", model);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }
    }
}