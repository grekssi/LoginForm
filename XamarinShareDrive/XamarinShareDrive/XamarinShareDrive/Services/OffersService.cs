using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Newtonsoft.Json.Linq;
using Org.Json;
using XamarinShareDrive.Models;

namespace XamarinShareDrive.Services
{
    public sealed class OffersService
    {
        string url = @"https://meower-api.grekssi.now.sh/offers";
        public Task<string> GetAllOffersJson()
        {
            return Task.Run(() =>
            {
                var httpWebRequest = (HttpWebRequest) WebRequest.Create(OffersRequestsURLs.GetAllOffersURL);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                try
                {
                    var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        return result;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            });
        }

    }
}
