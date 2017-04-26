namespace LandsSystem.Controllers
{
    using LandsSystem.Data;
    using LandsSystem.Models;
    using Microsoft.AspNet.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.Net;
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
        public ActionResult CreateHouse()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateHouse(HouseCreateModel model)
        {
            if (this.ModelState.IsValid)
            {
                if (model == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                using (var context = new LandsDbContext())
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

                    context.Houses.Add(house);
                    context.SaveChanges();

                    var adHouse = new HouseAdvertise
                    {
                        Description = model.Description,
                        SellerId = ownerId,
                        HouseId = house.Id
                    };

                    context.HouseAdvertises.Add(adHouse);
                    context.SaveChanges();

                    return RedirectToAction("Houses","Buy");
                }
            }
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateApartment()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateApartment(ApartmentCreateModel model)
        {
            if (this.ModelState.IsValid)
            {
                if (model == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                using (var context = new LandsDbContext())
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
                        TerraceArea = model.TerraceArea,
                        HaveBasement = model.HaveBasement,
                        HaveElevator = model.HaveElevator,
                        HaveGarage = model.HaveGarage,
                        ParkSlots = model.ParkSlots,
                        ImageUrl = model.ImageUrl
                    };

                    context.Apartments.Add(apartment);
                    context.SaveChanges();

                    var adApartment = new ApartmentAdvertise
                    {
                        Description=model.Description,
                        SellerId=ownerId,
                        ApartmentId=apartment.Id
                    };

                    context.ApartmentAdvertises.Add(adApartment);
                    context.SaveChanges();
                    return RedirectToAction("Apartments","Buy");
                }
            }
            return View(model);
        }


        [Authorize]
        [HttpGet]
        public ActionResult CreateLand()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateLand(LandCreateModel model)
        {
            if (model==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (this.ModelState.IsValid)
            {
                using (var context = new LandsDbContext())
                {
                    var ownerId = this.User.Identity.GetUserId();

                    var land = new Land
                    {
                        Address = model.Address,
                        Price = model.Price,
                        Area = model.Area,
                        Electricity = model.Electricity,
                        Water = model.Water,
                        Sewage = model.Sewage,
                        ImageUrl = model.ImageUrl
                    };

                    context.Lands.Add(land);
                    context.SaveChanges();

                    var adLand = new LandAdvertise()
                    {
                        Description = model.Description,
                        SellerId = ownerId,
                        LandId=land.Id
                    };

                    context.LandAdvertises.Add(adLand);
                    context.SaveChanges();

                    return RedirectToAction("Lands","Buy");
                }
            }
            return View(model);
        }


    }
}