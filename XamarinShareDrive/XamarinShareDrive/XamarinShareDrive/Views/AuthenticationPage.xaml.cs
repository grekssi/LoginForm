using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinShareDrive.BusinessLogic;
using XamarinShareDrive.Services;
using XamarinShareDrive.ViewModels;

namespace XamarinShareDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthenticationPage : ContentPage
    {
        public AuthenticationPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel(new LoginService(), new PageNavigator());
        }


        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            
            EmailLayout.IsVisible = true;
            
            RegisterLabel.IsVisible = false;
            
            RegisterButton.IsVisible = true;
            
            LoginButton.IsVisible = false;
        }

        private void AuthenticationButton_OnClicked(object sender, EventArgs e)
        {
            MainFrame.IsVisible = false;

            RobotImage.ScaleTo(3, 200);
            RobotImage.TranslateTo(0, 100, 200);
        }
    }
}