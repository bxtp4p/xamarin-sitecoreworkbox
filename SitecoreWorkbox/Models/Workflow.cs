using System;
using System.Collections.ObjectModel;
using Sitecore.MobileSDK.API.Items;

namespace SitecoreWorkbox.Models
{
	public class Workflow : ContentItem
	{
		public Workflow () {}
		public Workflow (ISitecoreItem item) : base (item) {}

		public string IconSource
		{
			get {
				return "outbox.png";
			}
		}

		public string InitialStateId { get; set; }
	}
}

