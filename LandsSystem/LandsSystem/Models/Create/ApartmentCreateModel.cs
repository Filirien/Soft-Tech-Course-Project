
namespace LandsSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ApartmentCreateModel
    {
        [Required]
        public string Address { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
        
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

        [Required]
        public string ImageUrl { get; set; }

    }
}