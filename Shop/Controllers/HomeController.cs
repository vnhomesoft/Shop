using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        ShopDbContext db = new ShopDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var post = db.Posts.Where(p => p.Name == "about").FirstOrDefault();
            if(post == null)
			{
                return HttpNotFound();
			}
            return View(post);
        }

        public ActionResult Contact()
        {
            var post = db.Posts.Where(p => p.Name.ToLower() == "contact").FirstOrDefault();
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
    }
}