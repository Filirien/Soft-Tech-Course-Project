
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

        [Range(1930, 2017)]
        [Display(Name = "Year of Built")]
        public int YearOfBuilt { get; set; }

        [Display(Name = "Apartment Area")]
        public double ApartmentArea { get; set; }

        public int Floor { get; set; }

        public int Bedrooms { get; set; }

        [Display(Name = "Living Rooms")]
        public int LivingRooms { get; set; }

        public int Bathroom { get; set; }

        [Display(Name = "Terrace Area")]
        public int TerraceArea { get; set; }

        [Display(Name = "Have Basement")]
        public bool HaveBasement { get; set; }

        [Display(Name = "Have Elevator")]
        public bool HaveElevator { get; set; }

        [Display(Name = "Have Garage")]
        public bool HaveGarage { get; set; }

        [Display(Name = "Park Slots")]
        public int ParkSlots { get; set; }

        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

    }
}