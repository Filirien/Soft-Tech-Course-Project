using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LandsSystem.Models
{
    public class LandCreateModel
    {
        [Required]
        public string Address { get; set; }

        [Required]
        public string Description { get; set; }

        public double Price { get; set; }

        public double Area { get; set; }

        public bool Electricity { get; set; }

        public bool Water { get; set; }

        public bool Sewage { get; set; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }
    }
}