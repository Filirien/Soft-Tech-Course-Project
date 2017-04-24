using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandsSystem.Models.HomeBuyModel
{
    public class LandBuyModel
    {
        public int Id { get; set; }

        public string LandAddress { get; set; }

        public double LandPrice { get; set; }

        public double LandArea { get; set; }

        public bool LandElectricity { get; set; }

        public bool LandWater { get; set; }

        public bool LandSewage { get; set; }

        public string LandImageUrl { get; set; }
    }
}