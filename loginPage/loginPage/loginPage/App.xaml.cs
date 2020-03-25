using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using loginPage.Services;
using loginPage.Views;

namespace loginPage
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AuthenticationPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
