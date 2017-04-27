using LandsSystem.Data;
using LandsSystem.Models;
using LandsSystem.Models.BuyDetailsModel;
using LandsSystem.Models.HomeBuyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LandsSystem.Controllers
{
    public class BuyController : Controller
    {
        // GET: Buy
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Houses(int page = 1, string user = null)
        {
            var db = new LandsDbContext();

            var pageSize = 5;

            var houses = db.Houses
                .OrderByDescending(h => h.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(h => new HouseBuyModel
                {
                    Id = h.Id,
                    HouseImageUrl = h.ImageUrl,
                    HouseAddress = h.Address,
                    HousePrice = h.Price,
                    HouseYearOfBuilt = h.YearOfBuilt,
                    LandArea = h.LandArea,
                    HouseArea = h.HouseArea
                })
                .ToList();

            ViewBag.CurrentPage = page;

            return View(houses);
        }

        public ActionResult Apartments(int page = 1, string user = null)
        {
<<<<<<< HEAD
            using (var context = new LandsDbContext())
            {
=======
            var db = new LandsDbContext();

            var pageSize = 5;

            var apartments = db.Apartments
                .OrderByDescending(a => a.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(a => new ApartmentBuyModel
                {
                    Id = a.Id,
                    ApartmentImageUrl = a.ImageUrl,
                    ApartmentAddress = a.Address,
                    ApartmentPrice = a.Price,
                    ApartmentArea = a.ApartmentArea,
                    TerraceArea = a.TerraceArea,
                    ApartmentYearOfBuilt = a.YearOfBuilt
                })
                .ToList();
>>>>>>> fbee3241c27c92268f968262288634cb1626b50f

                var apartments = context.Apartments
                    .Select(a => new ApartmentBuyModel
                    {
                        Id = a.Id,
                        ApartmentImageUrl = a.ImageUrl,
                        ApartmentAddress = a.Address,
                        ApartmentPrice = a.Price,
                        ApartmentArea = a.ApartmentArea,
                        TerraceArea = a.TerraceArea,
                        ApartmentYearOfBuilt = a.YearOfBuilt
                    })
                    .OrderByDescending(a => a.Id)
                    .ToList();

                return View(apartments);
            }
        }

        public ActionResult Lands(int page = 1, string user = null)
        {
<<<<<<< HEAD
            using (var context = new LandsDbContext())
            {
=======
            var db = new LandsDbContext();

            var pageSize = 5;

            var lands = db.Lands
                .OrderByDescending(a => a.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(l => new LandBuyModel
                {
                    Id = l.Id,
                    LandImageUrl = l.ImageUrl,
                    LandAddress = l.Address,
                    LandPrice = l.Price,
                    Area = l.Area
                })
                .ToList();
>>>>>>> fbee3241c27c92268f968262288634cb1626b50f

                var lands = context.LandAdvertises
                    .Select(la => new LandDetailsModel
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
                    })
                    .OrderByDescending(a => a.LandId)
                    .ToList();


                return View(lands);
            }
        }

        public ActionResult HouseDetails(int id)
        {
            var db = new LandsDbContext();

            var house = db.Houses
                .Where(h => h.Id == id)
                .Select(h => new HouseDetailsModel
                {

                    Address = h.Address,
                    Price = h.Price,
                    YearOfBuilt = h.YearOfBuilt,
                    LandArea = h.LandArea,
                    HouseArea = h.HouseArea,
                    Floors = h.Floors,
                    Bedrooms = h.Bedrooms,
                    LivingRooms = h.LivingRooms,
                    Bathrooms = h.Bathrooms,
                    HaveBasement = h.HaveBasement,
                    HaveGarage = h.HaveGarage,
                    HavePool = h.HavePool,
                    ParkSlots = h.ParkSlots,
                    ImageUrl = h.ImageUrl,
                    HouseAdvertises = h.HouseAdvertises
                })
                .FirstOrDefault();

            if (house == null)
            {
                return HttpNotFound();
            }

            return View(house);
        }

        public ActionResult ApartmentDetails(int id)
        {
            var db = new LandsDbContext();

            var apartment = db.Apartments
                .Where(a => a.Id == id)
                .Select(a => new ApartmentDetailsModel
                {

                    Address = a.Address,
                    Price = a.Price,
                    YearOfBuilt = a.YearOfBuilt,
                    ApartmentArea = a.ApartmentArea,
                    TerraceArea = a.TerraceArea,
                    Floor = a.Floor,
                    Bedrooms = a.Bedrooms,
                    LivingRooms = a.LivingRooms,
                    Bathroom = a.Bathroom,
                    HaveBasement = a.HaveBasement,
                    HaveGarage = a.HaveGarage,
                    HaveElevator = a.HaveElevator,
                    ParkSlots = a.ParkSlots,
                    ImageUrl = a.ImageUrl,
                    ApartmentAdvertises = a.ApartmentAdvertises
                })
                .FirstOrDefault();

            if (apartment == null)
            {
                return HttpNotFound();
            }

            return View(apartment);
        }

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
            return View(model);

        }

    }
}