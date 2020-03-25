using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using loginPage.Models;
using Xamarin.Forms;

namespace loginPage.Services
{
    public sealed class AuthenticationRequestProvider
    {
        private static string JsonUserCreator(User user)
        {
            return "{" + $"\"name\":\"{user.Username}\",\"password\":\"{user.Password}\",\"email\":\"{user.Email}\"" + "}";
        }
        public static Task<bool> RegisterNewUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            return Task.Run(() =>
            {
                var httpWebRequest = (HttpWebRequest) WebRequest.Create("https://meower-api.grekssi.now.sh/register");
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

        public static Task<bool> LoginUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            return Task.Run(() =>
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://meower-api.grekssi.now.sh/login");
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
    }
}
