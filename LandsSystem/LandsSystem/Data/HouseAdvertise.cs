using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LandsSystem.Data
{
    public class HouseAdvertise
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; }

        [Required]
        [ForeignKey("Seller")]
        public string SellerId { get; set; }

        public virtual User Seller { get; set; }

        [ForeignKey("Buyer")]
        public string BuyerId { get; set; }

        public virtual User Buyer { get; set; }

        [ForeignKey("House")]
        public int HouseId { get; set; }

        public virtual House House { get; set; }
    }
}