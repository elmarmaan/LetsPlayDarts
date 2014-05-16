using System;
using System.Web.Mvc;
using Domain;

namespace DesktopApp.Attributes
{
    public class IsAdminAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session != null)
            {
                var user = filterContext.HttpContext.Session["Account"] as Account;
                if (user == null)
                {
                    filterContext.Result = new RedirectResult("/SignUp/LogOn");
                }
                else if(user.IsAdmin)
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
