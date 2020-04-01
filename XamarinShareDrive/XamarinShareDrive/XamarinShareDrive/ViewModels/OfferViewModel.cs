using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using Android.Widget;
using XamarinShareDrive.Adapters;
using XamarinShareDrive.BusinessLogic;
using XamarinShareDrive.Models;
using XamarinShareDrive.Services;

namespace XamarinShareDrive.ViewModels
{
    public sealed class OfferViewModel
    {
        public List<Offer> Offers { get; set; } = new List<Offer>();
        private OffersService OffersService { get; }
        private Seller Seller { get; set; }

        private OffersAdapter OffersAdapter { get; }

        public OfferViewModel()
        {
            this.SetUpOffers();
        }


        private string _price = string.Empty;
        public string Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        private string _posterId = string.Empty;
        public string PosterId
        {
            get => _posterId;
            set => SetProperty(ref _posterId, value);
        }

        private string _startingPoint = string.Empty;
        public string StartingPoint
        {
            get => _startingPoint;
            set => SetProperty(ref _startingPoint, value);
        }

        private string _endPoint = string.Empty;
        public string EndPoint
        {
            get => _endPoint;
            set => SetProperty(ref _endPoint, value);
        }

        private void SetUpSeller()
        {
            this.Seller = Cache.SellersHelper.GetSellerById(this.PosterId);
        }

        private void SetProperty(ref string property, string value)
        {
            if (property == null) throw new ArgumentNullException(nameof(property));
            if (value == null) throw new ArgumentNullException(nameof(value));

            property = value;
        }

        private void SetUpOffers()
        {
            this.Offers = Cache.OffersHelper.GetAllOffers();
        }

        
    }
}
