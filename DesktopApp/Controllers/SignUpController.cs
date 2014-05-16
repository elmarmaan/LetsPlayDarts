using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Contexts;
using DesktopApp.Attributes;
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
        private ISubscriptionService _subscriptionService;

        public SignUpController(IAccountService accountService, ISubscriptionService subscriptionService)
        {
            _accountService = accountService;
            _subscriptionService = subscriptionService;
        }

        public SignUpController()
        {
            _accountService = new AccountService();
            _subscriptionService = new SubscriptionService();
        }

        [HttpGet]
        public ActionResult LogOn()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Account account)
        {
            if (ViewData.ModelState.IsValid)
            {
                account.IsAdmin = true;
                _subscriptionService.CreateSubscription(account);
            }
            return RedirectToAction("Index", "Home");
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
                    var sessionAccount = _accountService.GetAccountByEmailAddress(account.EmailAddress);
                    Session["Account"] = sessionAccount;
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
