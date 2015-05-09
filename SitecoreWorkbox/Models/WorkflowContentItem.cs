using System;
using Sitecore.MobileSDK.API.Items;

namespace SitecoreWorkbox.Models
{
	public class WorkflowContentItem : ContentItem
	{
		public WorkflowContentItem() {}
		public WorkflowContentItem(ISitecoreItem item) : base(item) {}
		
		public WorkflowState CurrentWorkflowState { get; set; }
	}
}