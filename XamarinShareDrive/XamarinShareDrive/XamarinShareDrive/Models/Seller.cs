using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinShareDrive.Models
{
    public sealed class Seller
    {
        public string Id { get; } 
        
        public string Name { get; }
        
        public ushort Rank { get; }

        public string Avatar { get; }

        public Seller(string id, string name, ushort rank, string avatar)
        {
            this.Id = id;
            this.Name = name;
            this.Rank = rank;
            this.Avatar = avatar;
        }
    }
}
