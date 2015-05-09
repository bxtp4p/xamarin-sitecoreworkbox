using System;
using SitecoreWorkbox.Models;
using Sitecore.MobileSDK.API;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Sitecore.MobileSDK.API.Request.Parameters;
using System.Collections.Generic;
using Sitecore.MobileSDK.API.Session;

namespace SitecoreWorkbox.Helpers
{
	public static class SitecoreHelper
	{
		private const string WORKFLOWS_ITEM_ID = "{05592656-56D7-4D85-AACF-30919EE494F9}";
		private const string DEFAULT_DB = "master";
		
		public static async Task<bool> Authenticate()
		{
			var authenticated = false;

			using (var session = CreateBaseSession().BuildSession ()) {
				authenticated = await session.AuthenticateAsync ();
			}

			return authenticated;
		}

		public static async Task<ObservableCollection<Workflow>> GetWorkflows()
		{
			var workflows = new ObservableCollection<Workflow> ();

			using (var session = CreateBaseSession().BuildSession()) {
				var request = ItemWebApiRequestBuilder
					.ReadItemsRequestWithId(WORKFLOWS_ITEM_ID)
					.AddScope(ScopeType.Children)
					.AddFieldsToRead("Initial state")
					.Build();

				var results = await session.ReadItemAsync (request);

				foreach (var result in results) {
					workflows.Add (new Workflow(result));
				}
			}

			return workflows;
		}

		public static async Task<ObservableCollection<WorkflowState>> GetWorkflowStatesInWorkflow(Workflow workflow)
		{
			var workflowStates = new ObservableCollection<WorkflowState> ();

			using (var session = CreateBaseSession().BuildSession()) {
				var request = ItemWebApiRequestBuilder
					.ReadItemsRequestWithId(workflow.Id)
					.AddScope(ScopeType.Children)
					.AddFieldsToRead("Final")
					.Build();

				var results = await session.ReadItemAsync (request);

				foreach (var result in results) {
					//Don't add states that are considered the final state of the workflow
					bool isFinal = result["Final"].RawValue == "1" ? true : false;
					if (!isFinal) {
						workflowStates.Add (new WorkflowState(result));
					}
				}
			}

			return workflowStates;
		}

		public static async Task<ObservableCollection<WorkflowContentItem>> GetContentItemsInWorkflowState(WorkflowState workflowState)
		{
			var contentItems = new ObservableCollection<WorkflowContentItem> ();
				
			using (var session = CreateBaseSession().BuildSession()) {
				var request = ItemWebApiRequestBuilder
					.ReadItemsRequestWithSitecoreQuery("/sitecore//*[@#__Workflow state# = '" + workflowState.Id + "']")
					.Build();

				var results = await session.ReadItemAsync (request);

				foreach (var result in results) {
					contentItems.Add (new WorkflowContentItem(result) {
						CurrentWorkflowState = workflowState
					});
				}
			}

			return contentItems;
		}

		private static IBaseSessionBuilder CreateBaseSession() {
			return SitecoreWebApiSessionBuilder
				.AuthenticatedSessionWithHost (AppData.Credentials.InstanceUrl)
				.Credentials (AppData.Credentials)
				.DefaultDatabase (DEFAULT_DB);
		}

	}
}

