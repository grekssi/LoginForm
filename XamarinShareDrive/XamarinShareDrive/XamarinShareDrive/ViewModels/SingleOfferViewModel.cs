using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinShareDrive.ViewModels
{
    public sealed class SingleOfferViewModel
    {

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

        private void SetProperty(ref string property, string value)
        {
            if (property == null) throw new ArgumentNullException(nameof(property));
            if (value == null) throw new ArgumentNullException(nameof(value));

            property = value;
        }

        public void Initialize(string price, string posterId, string startPoint, string endPoint)
        {
            this.Price = price;
            this.PosterId = posterId;
            this.StartingPoint = startPoint;
            this.EndPoint = endPoint;
        }
    }
}
