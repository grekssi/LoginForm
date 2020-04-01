using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinShareDrive.Views;

namespace XamarinShareDrive.BusinessLogic
{
    public sealed class PageNavigator
    {
        public void NavigateToMainPage(MainPages page)
        {
            switch (page)
            {
                case MainPages.AppShell:
                    Application.Current.MainPage = new AppShell();
                    break;
                case MainPages.AuthenticationPage:
                    Application.Current.MainPage = new AuthenticationPage();
                    break;
            }
        }
    }
}
