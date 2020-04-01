using System;
using System.Collections.Generic;
using System.Text;
using XamarinShareDrive.Adapters;
using XamarinShareDrive.Models;

namespace XamarinShareDrive.BusinessLogic.Providers
{
    public sealed class OffersHelper
    {
        private OffersAdapter Adapter { get; set; }
        private Dictionary<string, Offer> Offers { get; set; }

        public OffersHelper(OffersAdapter adapter)
        {
            this.Offers = new Dictionary<string, Offer>();
            this.Adapter = adapter;
            this.Load();
        }

        public List<Offer> GetAllOffers()
        {
            var list = new List<Offer>();
            foreach (var offer in Offers)
            {
                list.Add(offer.Value);
            }

            return list;
        }

        public void Load()
        {
            var offers = this.Adapter.GetAllOffersAsync();

            foreach (var offer in offers)
            {
                var offerId = offer._Id;
                this.Offers[offerId] = offer;
            }
        }

    }
}
