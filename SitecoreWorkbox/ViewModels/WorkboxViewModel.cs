using System;
using SitecoreWorkbox.Models;
using SitecoreWorkbox.Helpers;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Windows.Input;
using SitecoreWorkbox.Views;
using SitecoreWorkbox.Factories;

namespace SitecoreWorkbox.ViewModels
{
	public class WorkboxViewModel : RefreshableViewModel
	{
		public WorkboxViewModel ()
		{
			RefreshDataAction = RefreshWorkflows;
			RefreshCommand = new Command(Refresh, () => !IsBusy);
			Refresh ();
		}

		private async void RefreshWorkflows()
		{
			Workflows = await SitecoreHelper.GetWorkflows ();
		}

		ObservableCollection<Workflow> _workflows;
		public ObservableCollection<Workflow> Workflows
		{
			get { return _workflows; }
			private set {
				if (_workflows == value)
					return;

				_workflows = value;
				OnPropertyChanged ("Workflows");
			}
		}

		Workflow _selectedWorkflow;
		public Workflow SelectedWorkflow
		{
			get { return _selectedWorkflow; }
			set {
				if (_selectedWorkflow == value)
					return;

				_selectedWorkflow = value;
				AppData.CurrentWorkflow = _selectedWorkflow;

				OnPropertyChanged ("SelectedWorkflow");
				Navigation.PushAsync (ViewFactory.CreatePageFromViewModel(new WorkflowItemsViewModel()));
			}
		}
	}
}