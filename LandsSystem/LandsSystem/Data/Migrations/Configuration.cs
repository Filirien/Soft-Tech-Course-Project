namespace LandsSystem.Migrations
{
    using LandsSystem.Data;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LandsSystem.Data.LandsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LandsSystem.Data.LandsDbContext context)
        {
            // Seed Users
            if (!context.Users.Any())
            {
                CreateUser(context, "niki@gmail.com", "123", "Nikolay", "Georgiev", 55);
                CreateUser(context, "denis@gmail.com", "123", "Denis", "Vasilev", 65);
                CreateUser(context, "marin@gmail.com", "123", "Marin", "Kunovski", 75);
                CreateUser(context, "pesho.pesho@gmail.com", "123", "Pesho", "Pesho", 8);
            }

            // Seed Roles
            if (!context.Roles.Any())
            {
                CreateRole(context, "Administrator");

                // Seed Roles To Users
                AddUserToRole(context, "niki@gmail.com", "Administrator");
                AddUserToRole(context, "denis@gmail.com", "Administrator");
                AddUserToRole(context, "marin@gmail.com", "Administrator");
            }


            //Seed Houses
            if (!context.Houses.Any())
            {
                CreateHouse(context, "София, ул. Лале 5", 50000, 2002, 266, 66, 1, 2, 1, 1, false, false, false, 2);
                CreateHouse(context, "Видин, ул. Войвода 6", 48200, 1996, 310, 80, 1, 2, 1, 2, false, false, false, 1);
                CreateHouse(context, "София, ул. Хризантема 2", 80000, 2002, 490, 98, 2, 2, 1, 2, false, false, false, 2);
                CreateHouse(context, "София, ул. Дъга 5", 350000, 2012, 1088, 240, 3, 7, 3, 3, true, true, true, 5);
                CreateHouse(context, "Варна, ул. Слънце 8", 150000, 2008, 766, 130, 2, 4, 3, 2, false, true, false, 2);
                CreateHouse(context, "Бургас, ул. Лазур 24", 230000, 2017, 600, 120, 2, 5, 2, 2, true, true, true, 1);
                CreateHouse(context, "София, ул. Алабин 13", 120000, 2002, 440, 82, 2, 2, 1, 1, false, false, false, 0);
            }


            //Seed Apartments
            if (!context.Apartments.Any())
            {
                CreateApartment(context, "София, кв. Обеля, бл. 24", 288000, 2017, 140, 3, 3, 2, 2, 11, true, true, true, 1);
                CreateApartment(context, "София, кв. Лозенец, бл. 18", 218000, 2009, 113, 5, 2, 1, 1, 0, true, true, true, 0);
                CreateApartment(context, "София, кв. Свобода, бл. 32", 100000, 1988, 75, 2, 1, 1, 1, 0, true, true, false, 1);
                CreateApartment(context, "София, кв. Младост, бл. 30", 188000, 2003, 155, 1, 1, 1, 1, 0, false, false, false, 1);
                CreateApartment(context, "София, кв. Дружба, бл. 238", 128000, 1992, 95, 8, 2, 1, 1, 0, true, true, false, 1);
            }

            //Seed Lands
            if (!context.Lands.Any())
            {
                CreateLand(context, "София, кв. Дружба", 60000 , 811, false, true,true);
                CreateLand(context, "с. Волуяк", 71000, 950, false, false, false);
                CreateLand(context, "София, кв. Надежда", 50000, 732, true, true, true);
                CreateLand(context, "София, кв. Банишора", 32000, 400, true, true, false);
                CreateLand(context, "София, кв. Обеля", 90000, 1105, true, true, true);
            }


            if (!context.HouseAdvertises.Any())
            {
                var user1 = context.Users.FirstOrDefault(u => u.Email == "niki@gmail.com");
                var user2 = context.Users.FirstOrDefault(u => u.Email == "denis@gmail.com");
                var user3 = context.Users.FirstOrDefault(u => u.Email == "marin@gmail.com");
                var user4 = context.Users.FirstOrDefault(u => u.Email == "pesho.pesho@gmail.com");

                var house1 = context.Houses.Find(1);
                var house2 = context.Houses.Find(2);
                var house3 = context.Houses.Find(3);
                var house4 = context.Houses.Find(4);
                var house5 = context.Houses.Find(5);
                var house6 = context.Houses.Find(6);
                var house7 = context.Houses.Find(7);

                CreateHouseAd(context, "Продавам хубава къща.", user1, house1);
                CreateHouseAd(context, "Продавам къщата на Пешо.", user4, house2);
                CreateHouseAd(context, "Продавам  къща.", user3, house3);
                CreateHouseAd(context, "Продавам голяма луксозна къща.", user1, house4);
                CreateHouseAd(context, "Продавам къща в покрайнините на Варна.", user2, house5);
                CreateHouseAd(context, "Продавам къща на 100 метра от плажа.", user2, house6);
                CreateHouseAd(context, "Продавам къща в центъра на София.", user3, house7);
            }
            if (!context.ApartmentAdvertises.Any())
            {
                var user1 = context.Users.FirstOrDefault(u => u.Email == "niki@gmail.com");
                var user2 = context.Users.FirstOrDefault(u => u.Email == "denis@gmail.com");
                var user3 = context.Users.FirstOrDefault(u => u.Email == "marin@gmail.com");
                var user4 = context.Users.FirstOrDefault(u => u.Email == "pesho.pesho@gmail.com");

                var apartment1 = context.Apartments.Find(1);
                var apartment2 = context.Apartments.Find(2);
                var apartment3 = context.Apartments.Find(3);
                var apartment4 = context.Apartments.Find(4);
                var apartment5 = context.Apartments.Find(5);

                CreateApartmentAd(context, "Продавам апартамент на 50 метра от метростанция Обеля.", user1, apartment1);
                CreateApartmentAd(context, "Продавам апартамент в центъра на София.", user4, apartment2);
                CreateApartmentAd(context, "Продавам апартамент в близост до северния парк.", user3, apartment3);
                CreateApartmentAd(context, "Продавам двустаен апартамент.", user1, apartment4);
                CreateApartmentAd(context, "Продавам апартамента на тъщата.", user2, apartment5);
            }
            if (!context.LandAdvertises.Any())
            {
                var user1 = context.Users.FirstOrDefault(u => u.Email == "niki@gmail.com");
                var user2 = context.Users.FirstOrDefault(u => u.Email == "denis@gmail.com");
                var user3 = context.Users.FirstOrDefault(u => u.Email == "marin@gmail.com");
                var user4 = context.Users.FirstOrDefault(u => u.Email == "pesho.pesho@gmail.com");

                var land1 = context.Lands.Find(1);
                var land2 = context.Lands.Find(2);
                var land3 = context.Lands.Find(3);
                var land4 = context.Lands.Find(4);
                var land5 = context.Lands.Find(5);

                CreateLandAd(context, "Продавам парцел.", user1, land1);
                CreateLandAd(context, "Продавам нива.", user4, land2);
                CreateLandAd(context, "Продавам изгодно земята на комшията.", user3, land3);
                CreateLandAd(context, "Продавам ъглов равен парцел.", user1, land4);
                CreateLandAd(context, "Продавам терен за строителство.", user2, land5);
            }
        }

       
        private void CreateHouseAd(LandsDbContext context, string description, User seller, House house)
        {
            HouseAdvertise houseAd = new HouseAdvertise()
            {
                Description = description,
                Seller = seller,
                House = house
            };

            context.HouseAdvertises.Add(houseAd);
            context.SaveChanges();
        }
        private void CreateApartmentAd(LandsDbContext context, string description, User seller, Apartment apartment)
        {
            ApartmentAdvertise apartmentAd = new ApartmentAdvertise()
            {
                Description = description,
                Seller=seller,
                Apartment=apartment
            };
            context.ApartmentAdvertises.Add(apartmentAd);
            context.SaveChanges();
        }

        private void CreateLandAd(LandsDbContext context, string description, User seller, Land land)
        {
            LandAdvertise landAd = new LandAdvertise()
            {
                Description = description,
                Seller = seller,
                Land = land
            };
            context.LandAdvertises.Add(landAd);
            context.SaveChanges();
        }

        private void CreateApartment(LandsDbContext context, string address, int price, int yearOfBuild, int apartmentArea, int floors, int bedrooms, int livingRooms, int bathrooms, int terraceArea, bool haveBasement, bool haveElevator, bool haveGarage, int parkSlots)
        {
            Apartment apartment = new Apartment()
            {
                Address = address,
                Price = price,
                YearOfBuilt = yearOfBuild,
                ApartmentArea = apartmentArea,
                Floor = floors,
                Bedrooms = bedrooms,
                LivingRooms = livingRooms,
                Bathroom = bathrooms,
                TerraceArea = terraceArea,
                HaveBasement = haveBasement,
                HaveElevator = haveElevator,
                HaveGarage = haveGarage,
                PrakSlots = parkSlots
            };
            context.Apartments.Add(apartment);
            context.SaveChanges();
        }

        private void CreateHouse(LandsDbContext context, string address, int price, int yearOfBuild, int landArea, int houseArea, int floors, int bedrooms, int livingRooms, int bathrooms, bool haveBasement, bool havePool, bool haveGarage, int parkSlots)
        {
            House house = new House()
            {
                Address = address,
                Price = price,
                YearOfBuilt = yearOfBuild,
                LandArea = landArea,
                HouseArea = houseArea,
                Floors = floors,
                Bedrooms = bedrooms,
                LivingRooms = livingRooms,
                Bathrooms = bathrooms,
                HaveBasement = haveBasement,
                HavePool = havePool,
                HaveGarage = haveGarage,
                ParkSlots = parkSlots
            };
            context.Houses.Add(house);
            context.SaveChanges();
        }

        private void CreateLand(LandsDbContext context, string address, int price, int area, bool electricity, bool water, bool sewage)
        {

            Land land = new Land()
            {
                Address = address,
                Price = price,
                Area = area,
                Electricity = electricity,
                Water = water,
                Sewage = sewage
            };
            context.Lands.Add(land);
            context.SaveChanges();
        }

        private void CreateUser(LandsDbContext context, string email, string password, string firstName, string lastName, int age)
        {
            var userManager = new UserManager<User>(
                new UserStore<User>(context));
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            var rnd = new Random();

            var user = new User
            {
                UserName = email,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                RegisteredOn = DateTime.Now.AddDays(rnd.Next(0, 300))
            };

            var userCreateResult = userManager.Create(user, password);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", userCreateResult.Errors));
            }
        }

        private void CreateRole(LandsDbContext context, string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole(roleName));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }
        }

        private void AddUserToRole(LandsDbContext context, string userName, string roleName)
        {
            var user = context.Users.FirstOrDefault(u => u.UserName == userName);

            if (user == null)
            {
                return;
            }

            var userManager = new UserManager<User>(
                new UserStore<User>(context));
            var addAdminRoleResult = userManager.AddToRole(user.Id, roleName);
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }
        }
    }
}
