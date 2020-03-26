using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using loginPage.Annotations;
using loginPage.Services;
using loginPage.Views;
using Xamarin.Forms;

namespace loginPage.Models
{
    public sealed class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string username;
        private string password;
        private string email;

        public string Username
        {
            get => this.username;
            set
            {
                this.username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => this.password;
            set
            {
                this.password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string Email
        {
            get => this.email;
            set
            {
                this.email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public ICommand LogIn { get; }
        public ICommand Register { get; }

        public User()
        {
            LogIn = new Command(() => {AuthenticationRequestProvider.SendLoginRequest(this);});
            Register = new Command(() => {AuthenticationRequestProvider.SendRegistrationRequest(this);});
        }

        
    }
}
 