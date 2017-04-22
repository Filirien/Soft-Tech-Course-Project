using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandsSystem.Data
{
    public class Land: Property
    {
        public double Area { get; set; }

        public bool Electricity { get; set; }

        public bool Water { get; set; }

        public bool Sewage { get; set; }

    }
}