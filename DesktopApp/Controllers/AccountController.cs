using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using DesktopApp.Attributes;
using Domain;
using Services;
using Services.Interfaces;

namespace DesktopApp.Controllers
{
    public class AccountController : LetsPlayDartsControllerController
    {
        [HttpGet]
        [IsAdmin]
        public ActionResult AddAccount()
        {
            return View();
        }

        [HttpPost]
        [IsAdmin]
        public ActionResult AddAccount(Account account)
        {
            if (ViewData.ModelState.IsValid)
            {
                account.Subscription = Subscription;
                _accountService.AddAccount(account);
            }
            return RedirectToAction("GetAccounts");
        }

        [IsAdmin]
        public ActionResult GetAccounts()
        {
            ViewData.Model = Subscription.Accounts;
            return View();
        }

        [HttpGet]
        public ActionResult EditAccount(long accountId)
        {
            if (accountId == 0)
            {
                accountId = _accountService.GetAccountByEmailAddress(System.Web.HttpContext.Current.User.Identity.Name).Id;
            }
            var account = _accountService.GetAccount(accountId);
            ViewData.Model = account;
            return View();
        }

        [HttpPost]
        public ActionResult EditAccount(Account account)
        {
            _accountService.EditAccount(account);
            return RedirectToAction("GetAccounts");
        }

        [IsAdmin]
        public ActionResult DeleteAccount(long accountId)
        {
            _accountService.DeleteAccount(accountId);
            return RedirectToAction("GetAccounts");
        }

        [Authorize]
        public ActionResult GetAccount(long accountId)
        {
            var account = _accountService.GetAccount(accountId);
            ViewData.Model = account;
            return View();
        }
    }
}
