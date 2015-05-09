using System;
using System.ComponentModel;
using SitecoreWorkbox.Models;
using System.Collections.ObjectModel;
using SitecoreWorkbox.Helpers;
using Xamarin.Forms;

namespace SitecoreWorkbox.ViewModels
{
	public class WorkflowItemsViewModel : RefreshableViewModel
	{
		public WorkflowItemsViewModel ()
		{
			Workflow = AppData.CurrentWorkflow;
			RefreshDataAction = RefreshContentItems;
			RefreshCommand = new Command(Refresh, () => !IsBusy);
			Refresh ();
		}

		private async void RefreshContentItems()
		{
			var groups = new ObservableCollection<WorkflowStateGroup> ();

			var workflowStates = await SitecoreHelper.GetWorkflowStatesInWorkflow (Workflow);
			foreach (var workflowState in workflowStates) {
				var workflowStateGroup = new WorkflowStateGroup { DisplayName = workflowState.DisplayName };
				var contentItems = await SitecoreHelper.GetContentItemsInWorkflowState (workflowState);

				foreach (var contentItem in contentItems) {
					workflowStateGroup.Add (contentItem);
				}

				groups.Add (workflowStateGroup);
			}

			WorkflowStateGroups = groups;
		}

		Workflow _workflow;
		public Workflow Workflow
		{
			get { return _workflow; }
			set {
				if (_workflow == value)
					return;

				_workflow = value;
				OnPropertyChanged ("Workflow");
			}
		}

		ObservableCollection<WorkflowStateGroup> _workflowStateGroups;
		public ObservableCollection<WorkflowStateGroup> WorkflowStateGroups
		{
			get { return _workflowStateGroups; }
			private set {
				if (_workflowStateGroups == value)
					return;

				_workflowStateGroups = value;
				OnPropertyChanged ("WorkflowStateGroups");
			}
		}
	}
}

