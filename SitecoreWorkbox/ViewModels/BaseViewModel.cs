using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace SitecoreWorkbox.ViewModels
{
	public abstract class BaseViewModel : INotifyPropertyChanged
	{
		protected void OnPropertyChanged (string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler (this, new PropertyChangedEventArgs (propertyName));
		}

		public INavigation Navigation { get; set; }

		#region INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion
	}
}

