using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contexts;
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

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAccount(Account account)
        {
            if (ViewData.ModelState.IsValid)
            {
                _accountService.AddAccount(account);
            }
            return View();
        }

        public ActionResult GetAccounts()
        {
            var accounts = _accountService.GetAccounts();
            ViewData.Model = accounts;
            return View();
        }
    }
}
