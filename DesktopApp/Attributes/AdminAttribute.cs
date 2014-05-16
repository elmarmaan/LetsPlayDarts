using System;
using System.Web.Mvc;
using Domain;
using Services;

namespace DesktopApp.Attributes
{
    public class IsAdminAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session != null)
            {
                var accountService = new AccountService();
                var account = accountService.GetAccountByEmailAddress(System.Web.HttpContext.Current.User.Identity.Name);
                if (account == null)
                {
                    filterContext.Result = new RedirectResult("/SignUp/LogOn");
                }
                else if(account.IsAdmin)
                {
                    
                }
                else
                {
                    filterContext.Result = new RedirectResult("/Home/Index");
                }
            }
        }
    }
}
