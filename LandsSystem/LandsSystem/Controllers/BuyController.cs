using LandsSystem.Data;
using LandsSystem.Models.BuyDetailsModel;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LandsSystem.Controllers
{
    public class BuyController : Controller
    {
        // GET: Buy
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Houses(int page = 1, string user = null)
        {
            var db = new LandsDbContext();

            var pageSize = 5;

            var houses = db.HouseAdvertises
                .OrderByDescending(h => h.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(h => new HouseDetailsModel
                {
                    HouseAdId = h.Id,
                    Description = h.Description,
                    SellerId = h.SellerId,
                    SellerName = h.Seller.UserName,
                    HouseId = h.House.Id,
                    Price = h.House.Price,
                    YearOfBuilt = h.House.YearOfBuilt,
                    LandArea = h.House.LandArea,
                    HouseArea = h.House.HouseArea,
                    Floors = h.House.Floors,
                    Bedrooms = h.House.Bedrooms,
                    LivingRooms = h.House.LivingRooms,
                    Bathrooms = h.House.Bathrooms,
                    HaveBasement = h.House.HaveBasement,
                    HavePool = h.House.HavePool,
                    HaveGarage = h.House.HaveGarage,
                    ParkSlots = h.House.ParkSlots,
                    ImageUrl = h.House.ImageUrl

                })
                .ToList();

            ViewBag.CurrentPage = page;

            return View(houses);
        }

        [Authorize]
        public ActionResult Apartments(int page = 1, string user = null)
        {

            using (var context = new LandsDbContext())
            {
                var pageSize = 5;

                var apartments = context.ApartmentAdvertises
                    .OrderByDescending(a => a.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(a => new ApartmentDetailsModel
                    {
                        ApartmentAdId = a.Id,
                        Description = a.Description,
                        SellerId = a.SellerId,
                        SellerName = a.Seller.UserName,
                        ApartmentId = a.Apartment.Id,
                        Address = a.Apartment.Address,
                        Price = a.Apartment.Price,
                        YearOfBuilt = a.Apartment.YearOfBuilt,
                        ApartmentArea = a.Apartment.ApartmentArea,
                        Floor = a.Apartment.Floor,
                        Bedrooms = a.Apartment.Bedrooms,
                        LivingRooms = a.Apartment.LivingRooms,
                        Bathroom = a.Apartment.Bathroom,
                        TerraceArea = a.Apartment.TerraceArea,
                        HaveBasement = a.Apartment.HaveBasement,
                        HaveElevator = a.Apartment.HaveElevator,
                        HaveGarage = a.Apartment.HaveGarage,
                        ParkSlots = a.Apartment.ParkSlots,
                        ImageUrl = a.Apartment.ImageUrl

                    })
                    .ToList();

                ViewBag.CurrentPage = page;

                return View(apartments);
            }
        }

        [Authorize]
        public ActionResult Lands(int page = 1, string user = null)
        {

            using (var context = new LandsDbContext())
            {

                var pageSize = 5;

                var lands = context.LandAdvertises
                    .OrderByDescending(a => a.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(la => new LandDetailsModel
                    {
                        LandAdId = la.Id,
                        Description = la.Description,
                        SellerId = la.SellerId,
                        SellerName = la.Seller.UserName,
                        LandId = la.Land.Id,
                        ImageUrl = la.Land.ImageUrl,
                        Address = la.Land.Address,
                        Price = la.Land.Price,
                        Area = la.Land.Area,
                        Electricity = la.Land.Electricity,
                        Water = la.Land.Water,
                        Sewage = la.Land.Sewage
                    })
                    .ToList();

                ViewBag.CurrentPage = page;

                return View(lands);
            }
        }

        [Authorize]
        public ActionResult HouseDetails(HouseDetailsModel model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(model);
        }

        [Authorize]
        public ActionResult ApartmentDetails(ApartmentDetailsModel model)
        {

            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(model);
        }

        [Authorize]
        public ActionResult LandDetails(LandDetailsModel model)
        {

            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            return View(model);

        }
        [Authorize]
        [HttpGet]
        public ActionResult LandEdit(int? landAdId)
        {
            if (landAdId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var context = new LandsDbContext())
            {
                var la = context.LandAdvertises
                                    .FirstOrDefault(x => x.Id == landAdId);
                var model = new LandDetailsModel()
                {
                    LandAdId = la.Id,
                    Description = la.Description,
                    SellerId = la.SellerId,
                    LandId = la.Land.Id,
                    ImageUrl = la.Land.ImageUrl,
                    Address = la.Land.Address,
                    Price = la.Land.Price,
                    Area = la.Land.Area,
                    Electricity = la.Land.Electricity,
                    Water = la.Land.Water,
                    Sewage = la.Land.Sewage
                };
                if (model == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                return View(model);
            }

        }

        [Authorize]
        [HttpPost]
        public ActionResult LandEdit(LandDetailsModel model)
        {
            if (this.ModelState.IsValid)
            {
                using (var context = new LandsDbContext())
                {
                    var land = context.Lands
                        .FirstOrDefault(l => l.Id == model.LandId);
                    if (land == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    land.Address = model.Address;
                    land.Price = model.Price;
                    land.Area = model.Area;
                    land.Electricity = model.Electricity;
                    land.Water = model.Water;
                    land.Sewage = model.Sewage;
                    land.ImageUrl = model.ImageUrl;

                    var landAd = context.LandAdvertises
                        .FirstOrDefault(la => la.Id == model.LandAdId);
                    if (landAd == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    landAd.Description = model.Description;
                    context.SaveChanges();
                    return RedirectToAction("Lands", "Buy");
                }
            }
            return View(model);

        }


        [Authorize]
        [HttpGet]
        public ActionResult HouseEdit(int? houseAdId)
        {
            if (houseAdId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var context = new LandsDbContext())
            {
                var h = context.HouseAdvertises.FirstOrDefault(x => x.Id == houseAdId);
                var model = new HouseDetailsModel()
                {
                    HouseAdId = h.Id,
                    Description = h.Description,
                    SellerId = h.SellerId,
                    SellerName = h.Seller.UserName,
                    HouseId = h.House.Id,
                    Address = h.House.Address,
                    Price = h.House.Price,
                    YearOfBuilt = h.House.YearOfBuilt,
                    LandArea = h.House.LandArea,
                    HouseArea = h.House.HouseArea,
                    Floors = h.House.Floors,
                    Bedrooms = h.House.Bedrooms,
                    LivingRooms = h.House.LivingRooms,
                    Bathrooms = h.House.Bathrooms,
                    HaveBasement = h.House.HaveBasement,
                    HavePool = h.House.HavePool,
                    HaveGarage = h.House.HaveGarage,
                    ParkSlots = h.House.ParkSlots,
                    ImageUrl = h.House.ImageUrl
                };
                if (model == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                return View(model);
            }

        }

        [Authorize]
        [HttpPost]
        public ActionResult HouseEdit(HouseDetailsModel model)
        {
            if (this.ModelState.IsValid)
            {
                using (var context = new LandsDbContext())
                {
                    var house = context.Houses.FirstOrDefault(h => h.Id == model.HouseId);
                    if (house == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    house.Address = model.Address;
                    house.Price = model.Price;
                    house.YearOfBuilt = model.YearOfBuilt;
                    house.LandArea = model.LandArea;
                    house.HouseArea = model.HouseArea;
                    house.Floors = model.Floors;
                    house.Bedrooms = model.Bedrooms;
                    house.LivingRooms = model.LivingRooms;
                    house.Bathrooms = model.Bathrooms;
                    house.HaveBasement = model.HaveBasement;
                    house.HavePool = model.HavePool;
                    house.HaveGarage = model.HaveGarage;
                    house.ParkSlots = model.ParkSlots;
                    house.ImageUrl = model.ImageUrl;

                    var houseAd = context.HouseAdvertises
                        .FirstOrDefault(ha => ha.Id == model.HouseAdId);
                    if (houseAd == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    houseAd.Description = model.Description;
                    context.SaveChanges();
                    return RedirectToAction("Houses", "Buy");
                }
            }
            return View(model);

        }

        [Authorize]
        [HttpGet]
        public ActionResult ApartmentEdit(int? apartmentAdId)
        {
            if (apartmentAdId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var context = new LandsDbContext())
            {
                var a = context.ApartmentAdvertises.FirstOrDefault(x => x.Id == apartmentAdId);
                var model = new ApartmentDetailsModel()
                {
                    ApartmentAdId = a.Id,
                    Description = a.Description,
                    SellerId = a.SellerId,
                    SellerName = a.Seller.UserName,
                    ApartmentId = a.Apartment.Id,
                    Address = a.Apartment.Address,
                    Price = a.Apartment.Price,
                    YearOfBuilt = a.Apartment.YearOfBuilt,
                    ApartmentArea = a.Apartment.ApartmentArea,
                    Floor = a.Apartment.Floor,
                    Bedrooms = a.Apartment.Bedrooms,
                    LivingRooms = a.Apartment.LivingRooms,
                    Bathroom = a.Apartment.Bathroom,
                    TerraceArea = a.Apartment.TerraceArea,
                    HaveBasement = a.Apartment.HaveBasement,
                    HaveElevator = a.Apartment.HaveElevator,
                    HaveGarage = a.Apartment.HaveGarage,
                    ParkSlots = a.Apartment.ParkSlots,
                    ImageUrl = a.Apartment.ImageUrl
                };
                if (model == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                return View(model);
            }

        }

        [Authorize]
        [HttpPost]
        public ActionResult ApartmentEdit(ApartmentDetailsModel model)
        {
            if (this.ModelState.IsValid)
            {
                using (var context = new LandsDbContext())
                {
                    var apartment = context.Apartments.FirstOrDefault(a => a.Id == model.ApartmentId);
                    if (apartment == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    apartment.Address = model.Address;
                    apartment.Price = model.Price;
                    apartment.YearOfBuilt = model.YearOfBuilt;
                    apartment.ApartmentArea = model.ApartmentArea;
                    apartment.Floor = model.Floor;
                    apartment.Bedrooms = model.Bedrooms;
                    apartment.LivingRooms = model.LivingRooms;
                    apartment.Bathroom = model.Bathroom;
                    apartment.TerraceArea = model.TerraceArea;
                    apartment.HaveBasement = model.HaveBasement;
                    apartment.HaveElevator = model.HaveElevator;
                    apartment.HaveGarage = model.HaveGarage;
                    apartment.ParkSlots = model.ParkSlots;
                    apartment.ImageUrl = model.ImageUrl;

                    var apartmentAd = context.ApartmentAdvertises
                        .FirstOrDefault(aa => aa.Id == model.ApartmentAdId);
                    if (apartmentAd == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    apartmentAd.Description = model.Description;
                    context.SaveChanges();
                    return RedirectToAction("Apartments", "Buy");
                }
            }
            return View(model);
        }

        [Authorize]
        public ActionResult LandDelete(int? landAdId)
        {
            if (landAdId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var context = new LandsDbContext())
            {
                var landAd = context.LandAdvertises.FirstOrDefault(la => la.Id == landAdId);
                var land = context.Lands.FirstOrDefault(l => l.Id == landAd.LandId);

                context.Lands.Remove(land);
                context.LandAdvertises.Remove(landAd);
                context.SaveChanges();
            }
            return RedirectToAction("Lands", "Buy");
        }


        [Authorize]
        public ActionResult ApartmentDelete(int? apartmentAdId)
        {
            if (apartmentAdId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var context = new LandsDbContext())
            {
                var apartmentAd = context.ApartmentAdvertises.FirstOrDefault(aa => aa.Id == apartmentAdId);
                var apartment = context.Apartments.FirstOrDefault(a => a.Id == apartmentAd.ApartmentId);

                context.Apartments.Remove(apartment);
                context.ApartmentAdvertises.Remove(apartmentAd);
                context.SaveChanges();
            }
            return RedirectToAction("Apartments", "Buy");
        }


        [Authorize]
        public ActionResult HouseDelete(int? houseAdId)
        {
            if (houseAdId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var context = new LandsDbContext())
            {
                var houseAd = context.HouseAdvertises.FirstOrDefault(ha => ha.Id == houseAdId);
                var house = context.Houses.FirstOrDefault(h=> h.Id == houseAd.HouseId);

                context.Houses.Remove(house);
                context.HouseAdvertises.Remove(houseAd);
                context.SaveChanges();
            }
            return RedirectToAction("Houses", "Buy");
        }
    }
}