using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinShareDrive.Models;
using XamarinShareDrive.StringMessages;
using XamarinShareDrive.Views;

namespace XamarinShareDrive.Services
{
    public sealed class LoginService
    {
        private static string JsonUserCreator(Login login)
        {
            return "{" + $"\"name\":\"{login.Username}\",\"password\":\"{login.Password}\",\"email\":\"{login.Email}\"" + "}";
        }

        public string Validate(Login login)
        {
            if(login == null) throw new ArgumentNullException();

            var username = login.Username;
            var password = login.Password;
            var email = login.Email;
            if (username == string.Empty || password == string.Empty || email == string.Empty) 
            {
                return @"Please enter valid credentials";
            }

            return string.Empty;
        }

        public Task<bool> RegisterNewUserRequest(Login login)
        {
            if (login == null) throw new ArgumentNullException(nameof(login));

            return Task.Run(() =>
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(AuthenticationURLs.NewUserRegistrationURL);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonUserCreator(login);

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


        //public Task<bool> RegisterNewUserRequest(Login login)
        //{
        //    if (login == null) throw new ArgumentNullException(nameof(login));

        //    var registrationResult = Task.Run(() =>
        //    {
        //        var httpWebRequest = (HttpWebRequest) WebRequest.Create(AuthenticationURLs.NewUserRegistrationURL);
        //        httpWebRequest.ContentType = "application/json";
        //        httpWebRequest.Method = "POST";

        //        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //        {
        //            string json = JsonUserCreator(login);
        //            streamWriter.Write(json);
        //        }

        //        try
        //        {
        //            var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
        //            return true;
        //        }
        //        catch (Exception)
        //        {
        //            return false;
        //        }
        //    }).Result;

        //    return Task.FromResult(registrationResult);
        //}

        //public Task<bool> LoginUserRequest(Login login)
        //{
        //    if (login == null) throw new ArgumentNullException(nameof(login));

        //    var registrationResult = Task.Run(() =>
        //    {
        //        var httpWebRequest = (HttpWebRequest)WebRequest.Create(AuthenticationURLs.UserLoginURL);
        //        httpWebRequest.ContentType = "application/json";
        //        httpWebRequest.Method = "POST";

        //        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //        {
        //            string json = JsonUserCreator(login);
        //            streamWriter.Write(json);
        //        }

        //        try
        //        {
        //            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //            return true;
        //        }
        //        catch (Exception)
        //        {
        //            return false;
        //        }
        //    }).Result;

        //    return Task.FromResult(registrationResult);
        //}

        public Task<bool> LoginUserRequest(Login login)
        {
            if (login == null) throw new ArgumentNullException(nameof(login));

            return Task.Run(() =>
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(AuthenticationURLs.UserLoginURL);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonUserCreator(login);

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
    }
}
