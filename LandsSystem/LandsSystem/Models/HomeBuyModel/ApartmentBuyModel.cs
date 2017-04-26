using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandsSystem.Models.HomeBuyModel
{
    public class ApartmentBuyModel
    {
        public int Id { get; set; }

        public string ApartmentAddress { get; set; }

        public double ApartmentPrice { get; set; }

        public int ApartmentYearOfBuilt { get; set; }

        public string ApartmentImageUrl { get; set; }
    }
}