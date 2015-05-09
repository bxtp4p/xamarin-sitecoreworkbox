using System;
using System.Collections.Generic;
using SitecoreWorkbox.ViewModels;
using Xamarin.Forms;
using System.Reflection;
using SitecoreWorkbox.Views;

namespace SitecoreWorkbox.Factories
{
	public abstract class ViewFactory
	{
		public static Page CreatePageFromViewModel<TViewModel>(TViewModel model)
			where TViewModel: BaseViewModel
		{
			Page page;
			Type modelType = model.GetType ();

			if (modelType == typeof(LoginViewModel)) {
				page = new LoginPage ();
			} else if (modelType == typeof(WorkboxViewModel)) {
				page = new WorkboxPage ();
			} else if (modelType == typeof(WorkflowItemsViewModel)) {
				page = new WorkflowItemsPage ();
			} else {
				page = new LoginPage ();
			}

			model.Navigation = page.Navigation;
			page.BindingContext = model;

			return page;
		}
	}
}

