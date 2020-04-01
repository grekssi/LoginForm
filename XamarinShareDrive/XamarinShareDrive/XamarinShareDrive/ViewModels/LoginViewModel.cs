using System;
using Android.Util;
using Xamarin.Forms;
using XamarinShareDrive.BusinessLogic;
using XamarinShareDrive.Models;
using XamarinShareDrive.Services;
using XamarinShareDrive.Views;

namespace XamarinShareDrive.ViewModels
{
    public sealed class LoginViewModel
    {
        private LoginService LoginService { get; }
        private PageNavigator Navigator { get; }

        public LoginViewModel(LoginService loginService, PageNavigator navigator)
        {
            if (loginService == null) throw new ArgumentNullException(nameof(loginService));
            if (navigator == null) throw new ArgumentNullException(nameof(navigator));

            this.LoginService = loginService;
            this.Navigator = navigator;
            this.LoginCommand = new Command(this.Login, this.CanLogin);
            this.RegistrationCommand = new Command(this.Register, this.CanRegister);
        }

        private string _username = string.Empty;
        public string Username
        {
            get => _username;
            set
            {
                this.SetProperty(ref _username, value);
                this.LoginCommand.ChangeCanExecute();
                this.RegistrationCommand.ChangeCanExecute();
            }
        }

        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set
            {
                this.SetProperty(ref _password, value);
                this.LoginCommand.ChangeCanExecute();
                this.RegistrationCommand.ChangeCanExecute();
            }
        }

        private string _email = string.Empty;
        public string Email
        {
            get => _email;
            set
            {
                this.SetProperty(ref _email, value);
                this.LoginCommand.ChangeCanExecute();
                this.RegistrationCommand.ChangeCanExecute();
            }
        }

        public Command LoginCommand { get; }
        public Command RegistrationCommand { get; }

        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(this.Username) &&
                   !string.IsNullOrEmpty(this.Password);
        }

        private bool CanRegister()
        {
            return !string.IsNullOrEmpty(this.Username) &&
                   !string.IsNullOrEmpty(this.Password) &&
                    !string.IsNullOrEmpty(this.Email);
        }

        private void SetProperty(ref string property, string value)
        {
            if (property == null) throw new ArgumentNullException(nameof(property));
            if (value == null) throw new ArgumentNullException(nameof(value));

            property = value;
        }

        private void Login()
        {
            try
            {
                var username = this.Username ?? string.Empty;
                var password = this.Password ?? string.Empty;
                var email = this.Email ?? string.Empty;

                var login = new Login(username, password, email);

                var validationMessage = this.LoginService.Validate(login);

                if (!string.IsNullOrEmpty(validationMessage))
                {
                    if (this.LoginService.LoginUserRequest(login).Result)
                    {
                        this.Navigator.NavigateToMainPage(MainPages.AppShell);
                        return;
                    }
                    Alerter.InvalidLoginAlert();
                }
            }
            catch (Exception)
            {
                Alerter.InvalidLoginAlert();
            }
            this.Navigator.NavigateToMainPage(MainPages.AuthenticationPage);
        }

        private void Register()
        {
            try
            {
                var username = this.Username ?? string.Empty;
                var password = this.Password ?? string.Empty;
                var email = this.Email ?? string.Empty;

                var login = new Login(username, password, email);

                var validationMessage = this.LoginService.Validate(login);

                if (string.IsNullOrEmpty(validationMessage))
                {
                    if (this.LoginService.RegisterNewUserRequest(login).Result)
                    {
                        this.Navigator.NavigateToMainPage(MainPages.AuthenticationPage);
                        return;
                    }
                    Alerter.InvalidRegistrationAlert();
                }
            }
            catch (Exception)
            {
                Alerter.InvalidRegistrationAlert();
            }
            this.Navigator.NavigateToMainPage(MainPages.AuthenticationPage);
        }
    }
}
