using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinShareDrive.Models
{
    public sealed class Offer
    {
        public string _Id { get; set; }
        public string Price { get; set; }
        public string UserId { get; set; }
        public string StartingPoint { get; set; }
        public string EndPoint { get; set; }

        public Offer(string price, string posterId, string startPoint, string endPoint, string offerId)
        {
            this._Id = offerId;
            this.Price = price;
            this.UserId = posterId;
            this.StartingPoint = startPoint;
            this.EndPoint = endPoint;
        }
    } 
}
