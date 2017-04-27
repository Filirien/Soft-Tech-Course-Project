﻿using LandsSystem.Data;
using System.Collections.Generic;

namespace LandsSystem.Models.BuyDetailsModel
{
    public class LandDetailsModel
    {
        public int LandId { get; set; }

        public int LandAdId { get; set; }

        public string SellerId { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public double Price { get; set; }

        public double Area { get; set; }

        public bool Electricity { get; set; }

        public bool Water { get; set; }

        public bool Sewage { get; set; }

        public string ImageUrl { get; set; }
    }
}