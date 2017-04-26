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

        public string LandImageUrl { get; set; }
    }
}