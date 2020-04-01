using System;
using System.Collections.Generic;
using System.Text;
using XamarinShareDrive.Adapters;
using XamarinShareDrive.Models;

namespace XamarinShareDrive.BusinessLogic.Providers
{
    public sealed class SellersHelper
    {
        private OffersAdapter Adapter { get; set; }
        private Dictionary<string, Seller> Sellers { get; set; }

        

        public Seller GetSellerById(string id)
        {
            if(string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));

            Sellers.TryGetValue(id, out var seller);

            return seller;
        }
    }
}
