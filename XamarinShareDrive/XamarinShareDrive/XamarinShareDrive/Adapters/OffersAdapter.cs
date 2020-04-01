using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Android.OS;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XamarinShareDrive.Models;
using XamarinShareDrive.Services;

namespace XamarinShareDrive.Adapters
{
    public sealed class OffersAdapter
    {
        public OffersService OffersService { get; }

        public OffersAdapter(OffersService service)
        {
            this.OffersService = service;
        }

        public List<Offer> GetAllOffersAsync()
        {
            var offers = this.OffersService.GetAllOffersJson();

            var offersList = new List<Offer>();

                JArray obj = JArray.Parse(offers.Result);
                foreach (var item in obj)
                {
                    JObject data = JObject.Parse(item.ToString());
                    var str1 = data.ToString();
                    offersList.Add(JsonConvert.DeserializeObject<Offer>(data.ToString()));
                }

                return offersList;

        }
    }
}
