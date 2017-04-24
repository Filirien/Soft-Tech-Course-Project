using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandsSystem.Models
{
    public class HouseBuyModel
    {
        public string HouseAddress { get; set; }

        public double HousePrice { get; set; }

        public int HouseYearOfBuilt { get; set; }

        public double HouseLandArea { get; set; }

        public double HouseArea { get; set; }

        public int HouseFloors { get; set; }

        public int HouseBedrooms { get; set; }

        public int HouseLivingRooms { get; set; }

        public int HouseBathrooms { get; set; }

        public bool HouseHaveBasement { get; set; }

        public bool HouseHavePool { get; set; }

        public bool HouseHaveGarage { get; set; }

        public int? HouseParkSlots { get; set; }

        public string HouseImageUrl { get; set; }
    }
}