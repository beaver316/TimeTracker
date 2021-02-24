using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TimeTracker.PageModels.Base;
using TimeTracker.Services.Account;
using TimeTracker.Services.Navigation;
using Xamarin.Forms;

namespace TimeTracker.PageModels
{
    public class LoginPageModel : PageModelBase
    {
        private ICommand _logInCommand;
        private INavigationService _navigationService;
        private IAccountService _accountService;

        public ICommand LogInCommand
        {
            get => _logInCommand;
            set
            {
                _logInCommand = value;
                OnPropertyChanged(nameof(LogInCommand));
            }
        }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public LoginPageModel(INavigationService navigationService, IAccountService accountService)
        {
            _navigationService = navigationService;
            _accountService = accountService;

            // init our login command
            LogInCommand = new Command(DoLogInAction);
        }

        private async void DoLogInAction(object obj)
        {
            var loginAttempt = await _accountService.LoginAsync(Username, Password);

            if (loginAttempt)
            {
                // navigate to the dashboard
                await _navigationService.NavigateToAsync<DashboardPageModel>();
            }
            else 
            {
                // display an alert for failure 
            }
        }
    }
}
