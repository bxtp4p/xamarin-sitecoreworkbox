using System;
using Xamarin.Forms;

namespace SitecoreWorkbox.ViewModels
{
	public abstract class RefreshableViewModel : BaseViewModel
	{
		public Command RefreshCommand { get; protected set; }

		bool _isBusy;
		public bool IsBusy
		{
			get { return _isBusy; }
			set {
				if (_isBusy == value)
					return;

				_isBusy = value;
				OnPropertyChanged ("IsBusy");
			}
		}

		protected Action RefreshDataAction { get; set; }

		public async void Refresh()
		{
			if (IsBusy)
				return;

			IsBusy = true;
			RefreshCommand.ChangeCanExecute ();

			if(RefreshDataAction != null)
				RefreshDataAction ();

			IsBusy = false;
			RefreshCommand.ChangeCanExecute ();
		}
	}
}

