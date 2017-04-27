using LandsSystem.Data;
using LandsSystem.Models;
using LandsSystem.Models.BuyDetailsModel;
using LandsSystem.Models.HomeBuyModel;
using System;
using System.Collections.Generic;
using System.Linq;
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

            return View(apartments);
        }

        public ActionResult Lands(int page = 1, string user = null)
        {
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

            return View(lands);
        }

        public ActionResult HouseDetails(int id)
        {
            var db = new LandsDbContext();
            
            var house = db.Houses
                .Where(h => h.Id == id)
                .Select(h => new HouseDetailsModel
                {
                    Id = h.Id,
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
                    Id = a.Id,
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

        public ActionResult LandDetails(int id)
        {
            var db = new LandsDbContext();

            var land = db.Lands
                .Where(l => l.Id == id)
                .Select(l => new LandDetailsModel
                {
                    Id = l.Id,
                    Address = l.Address,
                    Price = l.Price,
                    Area = l.Area,
                    Electricity = l.Electricity,
                    Water = l.Water,
                    Sewage = l.Sewage,
                    ImageUrl = l.ImageUrl,
                    LandAdvertises = l.LandAdvertises
                })
                .FirstOrDefault();
            
            if (land == null)
            {
                return HttpNotFound();
            }

            return View(land);
        }
    }
}