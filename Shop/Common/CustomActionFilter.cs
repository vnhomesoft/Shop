using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Shop.Common
{
	public class CustomActionFilter : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			base.OnActionExecuting(filterContext);
			var controller = filterContext.Controller as Controller;
			if(controller != null)
			{
				controller.ViewBag.CurrentAccount = filterContext.HttpContext.Session["shop:user"] as Account;
			}
			if (controller.ViewBag.CurrentAccount == null)
			{
				string query = filterContext.HttpContext.Request.QueryString.ToString();
				controller.Response.Redirect("/Account/Login" + (!string.IsNullOrEmpty(query)? "?"+query : string.Empty), true); // terminate current proccess to prevent error 
			}
		}
	}
}