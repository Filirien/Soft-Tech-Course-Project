using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandsSystem.Data
{
    public class Land
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public double Price { get; set; }

        public double Area { get; set; }

        public bool Electricity { get; set; }

        public bool Water { get; set; }

        public bool Sewage { get; set; }

        public virtual List<LandAdvertise> LandAdvertises { get; set; } = new List<LandAdvertise>();
    }
}