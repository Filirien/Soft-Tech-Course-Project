namespace LandsSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class LandsDbContext : IdentityDbContext<User>
    {
        public LandsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<>)
        }

        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<Land> Lands { get; set; }
        public virtual DbSet<HouseAdvertise> Advertises { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // House Configuration
            modelBuilder.Entity<HouseAdvertise>()
                .HasRequired(a => a.Seller)
                .WithMany(a => a.PostedHouseAds)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HouseAdvertise>()
                .HasOptional(a => a.Buyer)
                .WithMany(a => a.BoughtHouseAds)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HouseAdvertise>()
                .HasRequired(a => a.House)
                .WithMany(a => a.HouseAdvertises)
                .WillCascadeOnDelete(false);


            // Apartment Configuration
            modelBuilder.Entity<ApartmentAdvertise>()
                .HasRequired(a => a.Seller)
                .WithMany(a => a.PostedApartemntAds)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApartmentAdvertise>()
                .HasOptional(a => a.Buyer)
                .WithMany(a => a.BoughtApartemntAds)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApartmentAdvertise>()
                .HasRequired(a => a.Apartment)
                .WithMany(a => a.ApartmentAdvertises)
                .WillCascadeOnDelete(false);

            // Land Configuration
            modelBuilder.Entity<LandAdvertise>()
                .HasRequired(a => a.Seller)
                .WithMany(a => a.PostedLandAds)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LandAdvertise>()
                .HasOptional(a => a.Buyer)
                .WithMany(a => a.BoughtLandAds)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LandAdvertise>()
                .HasRequired(a => a.Land)
                .WithMany(a => a.LandAdvertises)
                .WillCascadeOnDelete(false);


            base.OnModelCreating(modelBuilder);
        }

        public static LandsDbContext Create()
        {
            return new LandsDbContext();
        }
    }

}