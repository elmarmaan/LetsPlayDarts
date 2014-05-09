using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contexts;
using Domain;

namespace DesktopApp.Controllers
{
    public class SignUpController : Controller
    {
        //
        // GET: /SignUp/

        public ActionResult Index()
        {
            var db = new LetsPlayDartsContext();
            var account = new Account
            {
                EmailAddress = "test",
                Password = "test",
                Name = "test"
            };
            db.Accounts.Add(account);
            db.SaveChanges();
            return View();
        }

    }
}
