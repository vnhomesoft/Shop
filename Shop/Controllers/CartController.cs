using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddToCart(int productId, int quantity)
        {
            return View();
        }

        public ActionResult RemoveFromCart(int productId)
        {
            return View();
        }

        public ActionResult CheckOut()
        {
            return View();
        }
    }
}