﻿using System.Collections.Generic;

namespace LandsSystem.Data
{
    public class Apartment
    {
        public int Id { get; set; }
        
        public string Address { get; set; }

        public double Price { get; set; }

        public int YearOfBuilt { get; set; }

        public double ApartmentArea { get; set; }

        public int Floor { get; set; }

        public int Bedrooms { get; set; }

        public int LivingRooms { get; set; }

        public int Bathroom { get; set; }

        public int TerraceArea { get; set; }

        public bool HaveBasement { get; set; }

        public bool HaveElevator { get; set; }

        public bool HaveGarage { get; set; }

        public int ParkSlots { get; set; }

        public string ImageUrl { get; set; }

        public virtual List<ApartmentAdvertise> ApartmentAdvertises { get; set; } = new List<ApartmentAdvertise>();
    }
}