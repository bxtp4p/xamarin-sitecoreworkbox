using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using SitecoreWorkbox.Models;
using Sitecore.MobileSDK.API;
using SitecoreWorkbox.Helpers;
using SitecoreWorkbox.Views;
using SitecoreWorkbox.Factories;


namespace SitecoreWorkbox.ViewModels
{
	public class LoginViewModel : BaseViewModel
	{
		public ICommand LoginCommand { get; protected set; }
	
		UserCredentials _userCredentials;

		public LoginViewModel()
		{
			_userCredentials = new UserCredentials ();

			this.LoginCommand = new Command (async () => {
				AppData.Credentials = _userCredentials;
				var authenticated = await SitecoreHelper.Authenticate();

				if(authenticated) {
					App.Current.MainPage = new NavigationPage(
						ViewFactory.CreatePageFromViewModel(new WorkboxViewModel()));
				};

				
			}, () => !string.IsNullOrEmpty (_userCredentials.InstanceUrl) 
				&& !string.IsNullOrEmpty (_userCredentials.Username) 
				&& !string.IsNullOrEmpty (_userCredentials.Password));
		}

		public string InstanceUrl
		{
			get { return _userCredentials.InstanceUrl; }
			set {
				if (_userCredentials.InstanceUrl == value)
					return;

				_userCredentials.InstanceUrl = value;
				OnPropertyChanged ("InstanceUrl");
				((Command)LoginCommand).ChangeCanExecute ();
			}	
		}

		public string Username
		{
			get { return _userCredentials.Username; }
			set {
				if (_userCredentials.Username == value)
					return;

				_userCredentials.Username = value;
				OnPropertyChanged ("Username");
				((Command)LoginCommand).ChangeCanExecute ();
			}
		}

		public string Password
		{
			get { return _userCredentials.Password; }
			set {
				if (_userCredentials.Password == value)
					return;

				_userCredentials.Password = value;
				OnPropertyChanged ("Password");
				((Command)LoginCommand).ChangeCanExecute ();
			}
		}
	}
}

