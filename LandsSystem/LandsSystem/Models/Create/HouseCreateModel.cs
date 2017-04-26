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

        [Range(1930, 2017)]
        [Display(Name = "Year of Built")]
        public int YearOfBuilt { get; set; }

        [Display(Name = "Land Area")]
        public double LandArea { get; set; }

        [Display(Name = "House Area")]
        public double HouseArea { get; set; }

        public int Floors { get; set; }

        public int Bedrooms { get; set; }

        [Display(Name = "Living Rooms")]
        public int LivingRooms { get; set; }

        public int Bathrooms { get; set; }

        [Display(Name = "Have Basement")]
        public bool HaveBasement { get; set; }

        [Display(Name = "Have Elevator")]
        public bool HavePool { get; set; }

        [Display(Name = "Have Garage")]
        public bool HaveGarage { get; set; }

        [Display(Name = "Park Slots")]
        public int? ParkSlots { get; set; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }
    }
}