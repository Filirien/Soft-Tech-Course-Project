namespace LandsSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class HouseCreateModel
    {
        [Required]
        public string Address { get; set; }

        [Required]
        public string Description { get; set; }

        public double Price { get; set; }

        public int YearOfBuilt { get; set; }

        public double LandArea { get; set; }

        public double HouseArea { get; set; }

        public int Floors { get; set; }

        public int Bedrooms { get; set; }

        public int LivingRooms { get; set; }

        public int Bathrooms { get; set; }

        public bool HaveBasement { get; set; }

        public bool HavePool { get; set; }

        public bool HaveGarage { get; set; }

        public int? ParkSlots { get; set; }

        public string ImageUrl { get; set; }
    }
}