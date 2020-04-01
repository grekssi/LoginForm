using System;
using System.Collections.Generic;
using System.Text;
using XamarinShareDrive.Adapters;
using XamarinShareDrive.BusinessLogic.Providers;
using XamarinShareDrive.Models;
using XamarinShareDrive.Services;

namespace XamarinShareDrive.BusinessLogic
{
    public static class Cache
    {
        public static SellersHelper SellersHelper = new SellersHelper();
        public static OffersHelper OffersHelper = new OffersHelper(new OffersAdapter(new OffersService()));
    }
}
