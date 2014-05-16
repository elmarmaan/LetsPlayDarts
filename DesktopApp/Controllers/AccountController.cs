using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DesktopApp.Attributes;
using Domain;
using Services;
using Services.Interfaces;

namespace DesktopApp.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public AccountController()
        {
            _accountService = new AccountService();
        }

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
                _accountService.AddAccount(account);
            }
            return RedirectToAction("GetAccounts");
        }

        [IsAdmin]
        public ActionResult GetAccounts()
        {
            var account = Session["Account"] as Account;
            ViewData.Model = account.Subscription.Accounts;
            return View();
        }

        [HttpGet]
        public ActionResult EditAccount(long accountId)
        {
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

        public ActionResult DeleteAccount(long accountId)
        {
            _accountService.DeleteAccount(accountId);
            return RedirectToAction("GetAccounts");
        }

        public ActionResult GetAccount(long accountId)
        {
            var account = _accountService.GetAccount(accountId);
            ViewData.Model = account;
            return View();
        }
    }
}
