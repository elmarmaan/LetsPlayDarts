using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Services;
using Services.Interfaces;

namespace DesktopApp.Controllers
{
    public class LetsPlayDartsControllerController : Controller
    {
        protected Subscription Subscription { get; set; }
        protected IAccountService _accountService;

        public LetsPlayDartsControllerController(IAccountService accountService)
        {
            _accountService = accountService;
            SetSubscription();
        }

        public LetsPlayDartsControllerController()
        {
            _accountService = new AccountService();
            SetSubscription();
        }

        private void SetSubscription()
        {
            var account = _accountService.GetAccountByEmailAddress(System.Web.HttpContext.Current.User.Identity.Name);
            if (account != null)
            {
                Subscription = account.Subscription;
            }
        }
    }
}
