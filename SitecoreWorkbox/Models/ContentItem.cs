using System;
using System.ComponentModel;
using Sitecore.MobileSDK.API.Items;

namespace SitecoreWorkbox.Models
{
	public class ContentItem
	{
		public ContentItem () {}
		public ContentItem(ISitecoreItem sitecoreItem) {
			DisplayName = sitecoreItem.DisplayName;
			Id = sitecoreItem.Id;
			Path = sitecoreItem.Path;
		}

		public string DisplayName { get; set; }
		public string Id { get; set; }
		public string Path { get; set; }
	}
}

