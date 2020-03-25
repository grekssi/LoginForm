using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using loginPage.Models;
using loginPage.Services;
using loginPage.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace loginPage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthenticationPage : ContentPage
    {
        public AuthenticationPage()
        {
            InitializeComponent();
            this.BindingContext = new AuthenticationViewModel();
        }
    }
}