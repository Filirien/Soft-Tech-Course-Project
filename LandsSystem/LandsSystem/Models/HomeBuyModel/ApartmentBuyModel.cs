using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandsSystem.Models.HomeBuyModel
{
    public class ApartmentBuyModel
    {
        public string ApartmentAddress { get; set; }

        public double ApartmentPrice { get; set; }

        public int ApartmentYearOfBuilt { get; set; }

        public double ApartmentArea { get; set; }

        public int ApartmentFloor { get; set; }

        public int ApartmentBedrooms { get; set; }

        public int ApartmentLivingRooms { get; set; }

        public int ApartmentBathroom { get; set; }

        public int ApartmentTerraceArea { get; set; }

        public bool ApartmentHaveBasement { get; set; }

        public bool ApartmentHaveElevator { get; set; }

        public bool ApartmentHaveGarage { get; set; }

        public int ApartmentParkSlots { get; set; }

        public string ApartmentImageUrl { get; set; }
    }
}