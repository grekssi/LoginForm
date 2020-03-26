using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using loginPage.Models;
using loginPage.Views;
using Xamarin.Forms;

namespace loginPage.Services
{
    public sealed class AuthenticationRequestProvider
    {
        private static string JsonUserCreator(User user)
        {
            return "{" + $"\"name\":\"{user.Username}\",\"password\":\"{user.Password}\",\"email\":\"{user.Email}\"" + "}";
        }
        private static Task<bool> RegisterNewUserRequest(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            return Task.Run(() =>
            {
                var httpWebRequest = (HttpWebRequest) WebRequest.Create(AuthenticationURLs.NewUserRegistrationURL);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonUserCreator(user);

                    streamWriter.Write(json);
                }

                try
                {
                    var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        private static Task<bool> LoginUserRequest(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            return Task.Run(() =>
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(AuthenticationURLs.UserLoginURL);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonUserCreator(user);

                    streamWriter.Write(json);
                }

                try
                {
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public static async void SendLoginRequest(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            var task = await LoginUserRequest(user);
            if (!task)
            {
                await Application.Current.MainPage.DisplayAlert("Invalid request", "Please enter valid Username and Password", "OK", "Cancel");
                Application.Current.MainPage = new AuthenticationPage();
                return;
            }
            Application.Current.MainPage = new MainPage();
        }

        public static async void SendRegistrationRequest(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            var task = await RegisterNewUserRequest(user);
            if (!task)
            {
                await Application.Current.MainPage.DisplayAlert("Invalid request", "Please enter valid Username, Password and Email", "OK", "Cancel");
                Application.Current.MainPage = new AuthenticationPage();
            }
            Application.Current.MainPage = new AuthenticationPage();
        }
    }
}
