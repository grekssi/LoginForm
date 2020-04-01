using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinShareDrive.Services;

namespace XamarinShareDrive.Models
{
    public sealed class Login
    {
        public string Username { get; }
        public string Password { get; }
        public string Email { get; }

        public Login(string username, string password, string email)
        {
            if (username == null) throw new ArgumentNullException(nameof(username));
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (email == null) throw new ArgumentNullException(nameof(email));

            this.Username = username;
            this.Password = password;
            this.Email = email;
        }
    }
}
