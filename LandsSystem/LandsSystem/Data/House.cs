using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandsSystem.Data
{
    public class House:Property
    {
        public int YearOfBuilt { get; set; }

        public double LandArea { get; set; }

        public double HouseArea { get; set; }

        public int Floors { get; set; }

        public int Bedrooms { get; set; }
        
        public int LivingRooms { get; set; }

        public int Bathroom { get; set; }

        public bool HaveBasement { get; set; }

        public bool HavePool { get; set; }

        public bool HaveGarage { get; set; }

        public int PrakSlots { get; set; }

    }
}