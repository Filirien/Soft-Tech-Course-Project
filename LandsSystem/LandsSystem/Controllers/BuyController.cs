using LandsSystem.Data;
using LandsSystem.Models;
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
        public ActionResult Houses()
        {
            var db = new LandsDbContext();

            var houses = db.Houses
                .OrderBy(h => h.Id)
                .Select(h => new HouseBuyModel
                {
                    HouseImageUrl = h.ImageUrl,
                    HouseAddress = h.Address,
                    HousePrice = h.Price,
                    HouseYearOfBuilt = h.YearOfBuilt
                })
                .ToList();

            return View(houses);
        }

        public ActionResult Apartments()
        {
            var db = new LandsDbContext();

            var apartments = db.Apartments
                .OrderBy(a => a.Id)
                .Select(a => new ApartmentBuyModel
                {
                    ApartmentImageUrl = a.ImageUrl,
                    ApartmentAddress = a.Address,
                    ApartmentPrice = a.Price,
                    ApartmentYearOfBuilt = a.YearOfBuilt
                })
                .ToList();

            return View(apartments);
        }

        public ActionResult Lands()
        {
            var db = new LandsDbContext();

            var lands = db.Lands
                .OrderBy(a => a.Id)
                .Select(l => new LandBuyModel
                {
                    LandImageUrl = l.ImageUrl,
                    LandAddress = l.Address,
                    LandPrice = l.Price
                })
                .ToList();

            return View(lands);
        }

        public ActionResult HouseDetails()
        {
            return View();
        }

        public ActionResult ApartmentDetails()
        {
            return View();
        }

        public ActionResult LandDetails()
        {
            return View();
        }
    }
}