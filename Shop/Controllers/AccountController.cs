using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using Shop.Common.Constants;

namespace Shop.Controllers
{
    public class AccountController : Controller
    {
        private static Logger logger = LogManager.GetLogger(LoggerName.DEFAULT);

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult SignOut()
        {
            return View();
        }

        public ActionResult DeleteAccount()
        {
            return View();
        }
    }
}