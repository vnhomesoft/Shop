using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Common.Constants;

namespace Shop.Areas.Admin.Controllers
{
	public class BaseController : Controller
	{
		// TODO: include ID and name of item in message
		protected void SetSuccessNotification()
		{
			string controller = RouteData.GetRequiredString("controller");
			string action = RouteData.GetRequiredString("action");
			if("edit" == action?.ToLower())
			{
				TempData.Add("Message", "Item is saved.");
			}else if ("deleteconfirmed" == action?.ToLower())
			{
				TempData.Add("Message", "Item is deleted.");
			}
			else
			{
				TempData.Add("Message", "Action is succeed.");
			}

		}
	}
}