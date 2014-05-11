using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Contexts;
using DesktopApp.Model;
using DesktopApp.Model.Mappers;
using Domain;
using Services;
using Services.Interfaces;

namespace DesktopApp.Controllers
{
    public class SignUpController : Controller
    {
        private IAccountService _accountService;

        public SignUpController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public SignUpController()
        {
            _accountService = new AccountService();
        }

        [HttpGet]
        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var account = ModelToDomainMapper.Map(model);
                if (_accountService.LogOn(account.EmailAddress, account.Password))
                {
                    FormsAuthentication.SetAuthCookie(account.EmailAddress, false);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }
            return View(model);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}
