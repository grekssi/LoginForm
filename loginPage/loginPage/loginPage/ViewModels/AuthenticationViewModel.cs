using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using loginPage.Models;
using loginPage.Services;
using loginPage.Views;
using Xamarin.Forms;

namespace loginPage.ViewModels
{
    public sealed class AuthenticationViewModel
    {
        public User User { get; set; } = new User();

        public AuthenticationViewModel()
        {
            LoginCommand = new Command(SendLoginRequest);
            RegistrationCommand = new Command(SendRegistarionRequest);

        }

        private ICommand _loginCommand;
        private ICommand _registrationCommand;

        public ICommand LoginCommand { get; }
        public ICommand RegistrationCommand { get; }

        public async void SendLoginRequest()
        {
            var task = await AuthenticationRequestProvider.LoginUser(this.User);
            if (!task)
            {
                await Application.Current.MainPage.DisplayAlert("Invalid request", "Please enter valid username, password and email", "OK", "Cancel");
            }
            Application.Current.MainPage = new MainPage();
        }
        public async void SendRegistarionRequest()
        {
            var task = await AuthenticationRequestProvider.RegisterNewUser(this.User);
            if (!task)
            {
                await Application.Current.MainPage.DisplayAlert("Invalid request", "Please enter valid username, password and email", "OK", "Cancel");
            }

        }
    }
}
