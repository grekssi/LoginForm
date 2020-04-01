using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinShareDrive.StringMessages;

namespace XamarinShareDrive.BusinessLogic
{
    public sealed class Alerter
    {
        public static async void InvalidLoginAlert() =>  await Application.Current.MainPage.DisplayAlert("Invalid Credentials",
                RequestErrorMessages.InvalidLoginRequest, "Ok", "Cancel");

        public static async void InvalidRegistrationAlert() => await Application.Current.MainPage.DisplayAlert("Invalid Credentials",
            RequestErrorMessages.InvalidRegistrationRequest, "Ok", "Cancel");
    }
}
