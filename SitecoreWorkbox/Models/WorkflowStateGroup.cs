using System;
using System.Collections.ObjectModel;

namespace SitecoreWorkbox.Models
{
	public class WorkflowStateGroup : ObservableCollection<WorkflowContentItem>
	{
		public WorkflowStateGroup (){}

		public string DisplayName { get; set; }
	}
}

