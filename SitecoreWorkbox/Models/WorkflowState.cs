using System;
using System.Collections.ObjectModel;
using Sitecore.MobileSDK.API.Items;

namespace SitecoreWorkbox.Models
{
	public class WorkflowState : ContentItem
	{
		public WorkflowState () {}
		public WorkflowState (ISitecoreItem item) : base(item) {}
	}
}

