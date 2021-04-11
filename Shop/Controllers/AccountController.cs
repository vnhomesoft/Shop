using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NLog;
using Shop.Common.Constants;
using Shop.Models;
using Shop.Models.ViewModels;

namespace Shop.Controllers
{
    public class AccountController : Controller
    {
        private static Logger logger = LogManager.GetLogger(LoggerName.DEFAULT);
        ShopDbContext db = new ShopDbContext();

        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginView model)
        {
            Account userRecord = db.Accounts.FirstOrDefault(user => user.LoginName.ToLower() ==
             model.LoginName && user.Password == model.Password);
            string returnUrl = Request.Params["ReturnUrl"];
            if (userRecord != null)
            {
                FormsAuthentication.SetAuthCookie(model.LoginName, model.RememberLogin);
                //TODO: set user identity
                Session["shop:user"] = userRecord;
				if (!string.IsNullOrEmpty(returnUrl))
				{
                    return Redirect(returnUrl);
				}
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }
            ModelState.AddModelError("", "Invalid Username or Password");
            return View();
        }

        //public ActionResult SignUp()
        //{
        //    return View();
        //}

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        //public ActionResult DeleteAccount()
        //{
        //    return View();
        //}
    }
}