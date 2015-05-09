using System;
using Sitecore.MobileSDK.PasswordProvider.Interface;

namespace SitecoreWorkbox.Models
{
	public class UserCredentials : IWebApiCredentials
	{
		public UserCredentials () {}

		public string InstanceUrl { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }

		public IWebApiCredentials CredentialsShallowCopy ()
		{
			return new UserCredentials () { 
				InstanceUrl = this.InstanceUrl,
				Username = this.Username,
				Password = this.Password
			};
		}

		public void Dispose ()
		{
			InstanceUrl = null;
			Username = null;
			Password = null;
		}
	}
}

