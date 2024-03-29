﻿namespace LandsSystem.Models
{
    public class HouseBuyModel
    {
        public int Id { get; set; }
        public string HouseAddress { get; set; }

        public double HousePrice { get; set; }

        public int HouseYearOfBuilt { get; set; }

        public double LandArea { get; set; }

        public double HouseArea { get; set; }

        public string HouseImageUrl { get; set; }
    }
}