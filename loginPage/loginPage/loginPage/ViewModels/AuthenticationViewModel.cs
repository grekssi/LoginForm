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
        }
    }
}
