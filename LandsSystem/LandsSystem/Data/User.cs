
namespace LandsSystem.Data
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime RegisteredOn { get; set; }

        [Range(0, 120)]
        public int Age { get; set; }


        public virtual List<HouseAdvertise> PostedHouseAds { get; set; } = new List<HouseAdvertise>();
        public virtual List<HouseAdvertise> BoughtHouseAds { get; set; } = new List<HouseAdvertise>();

        public virtual List<ApartmentAdvertise> PostedApartemntAds { get; set; } = new List<ApartmentAdvertise>();
        public virtual List<ApartmentAdvertise> BoughtApartemntAds { get; set; } = new List<ApartmentAdvertise>();

        public virtual List<LandAdvertise> PostedLandAds { get; set; } = new List<LandAdvertise>();
        public virtual List<LandAdvertise> BoughtLandAds { get; set; } = new List<LandAdvertise>();

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }


}