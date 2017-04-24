namespace LandsSystem.Controllers
{
    using LandsSystem.Data;
    using LandsSystem.Models;
    using Microsoft.AspNet.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class SellController : Controller
    {
        // GET: Sell
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Houses()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Houses(HouseCreateModel model)
        {
            if (this.ModelState.IsValid)
            {
                var ownerId = this.User.Identity.GetUserId();

                var house = new House
                {
                    Address = model.Address,
                    Price = model.Price,
                    YearOfBuilt = model.YearOfBuilt,
                    LandArea = model.LandArea,
                    HouseArea = model.HouseArea,
                    Floors = model.Floors,
                    Bedrooms = model.Bedrooms,
                    LivingRooms = model.LivingRooms,
                    Bathrooms = model.Bathrooms,
                    HaveBasement = model.HaveBasement,
                    HavePool = model.HavePool,
                    HaveGarage = model.HaveGarage,
                    ParkSlots = model.ParkSlots,
                    ImageUrl = model.ImageUrl
                };
                var db = new LandsDbContext();
                db.Houses.Add(house);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = house.Id });

            }
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Apartments()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Apartments(ApartmentCreateModel model)
        {
            if (this.ModelState.IsValid)
            {
                var ownerId = this.User.Identity.GetUserId();

                var apartment = new Apartment
                {
                    Address = model.Address,
                    Price = model.Price,
                    YearOfBuilt = model.YearOfBuilt,
                    ApartmentArea = model.ApartmentArea,
                    Floor = model.Floor,
                    Bedrooms = model.Bedrooms,
                    LivingRooms = model.LivingRooms,
                    Bathroom = model.Bathroom,
                    TerraceArea=model.TerraceArea,
                    HaveBasement = model.HaveBasement,
                    HaveElevator = model.HaveElevator,
                    HaveGarage = model.HaveGarage,
                    ParkSlots = model.ParkSlots,
                    ImageUrl = model.ImageUrl
                };
                var db = new LandsDbContext();
                db.Apartments.Add(apartment);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = apartment.Id });

            }
            return View(model);
        }


        [Authorize]
        [HttpGet]
        public ActionResult Lands()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Lands(LandCreateModel model)
        {
            if (this.ModelState.IsValid)
            {
                var ownerId = this.User.Identity.GetUserId();

                var land = new Land
                {
                    Address = model.Address,
                    Price = model.Price,
                    Area = model.Area,
                    Electricity=model.Electricity,
                    Water=model.Water,
                    Sewage=model.Sewage,
                    ImageUrl = model.ImageUrl
                };
                var db = new LandsDbContext();
                db.Lands.Add(land);
                db.SaveChanges();

                return RedirectToAction("Details", new { id = land.Id });
            }
            return View(model);
        }


    }
}