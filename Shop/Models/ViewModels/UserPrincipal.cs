using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Shop.Models.ViewModels
{
	public class UserPrincipal : IPrincipal
	{	
		public IIdentity Identity { get; private set; }

		//public string LoginName { get; private set; }

		//public string Email { get; private set; }

		public string Roles { get; private set; }

		public UserPrincipal(string loginName, string role)
		{
			//this.LoginName = loginName;
			this.Roles = role;
			Identity = new GenericIdentity(loginName);
		}

		public bool IsInRole(string role)
		{
			return role == Roles;
		}
	}
}