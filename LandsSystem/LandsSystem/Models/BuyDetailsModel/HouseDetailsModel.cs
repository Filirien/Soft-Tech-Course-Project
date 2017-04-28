using LandsSystem.Data;
using System;
using System.Collections.Generic;

namespace LandsSystem.Models.BuyDetailsModel
{
    public class HouseDetailsModel
    {
        public int HouseId { get; set; }

        public int HouseAdId { get; set; }

        public DateTime CreationDate { get; set; }

        public string SellerId { get; set; }

        public string FullName { get; set; }

        public string SellerName { get; set; }

        public string SellerPhone { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public double Price { get; set; }

        public int YearOfBuilt { get; set; }

        public double LandArea { get; set; }

        public double HouseArea { get; set; }

        public int Floors { get; set; }

        public int Bedrooms { get; set; }

        public int LivingRooms { get; set; }

        public int Bathrooms { get; set; }

        public bool HaveBasement { get; set; }

        public bool HavePool { get; set; }

        public bool HaveGarage { get; set; }

        public int? ParkSlots { get; set; }

        public string ImageUrl { get; set; }

        public virtual List<HouseAdvertise> HouseAdvertises { get; set; } = new List<HouseAdvertise>();
    }
}