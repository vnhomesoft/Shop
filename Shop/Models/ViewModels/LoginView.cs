using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models.ViewModels
{
	public class LoginView
	{
		public string LoginName { get; set; }

		public string Password { get; set; }

		public bool RememberLogin { get; set; }
	}
}