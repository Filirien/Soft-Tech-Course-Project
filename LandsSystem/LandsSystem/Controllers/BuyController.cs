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
                    HouseAddress = h.Address,
                    HousePrice = h.Price
                })
                .ToList();

            return View(houses);
        }

        public ActionResult Apartmnets()
        {
            var db = new LandsDbContext();

            var apartments = db.Apartments
                .OrderBy(a => a.Id)
                .Select(a => new ApartmentBuyModel
                {
                    ApartmentAddress = a.Address,
                    ApartmentPrice = a.Price
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
                    LandAddress = l.Address,
                    LandPrice = l.Price
                })
                .ToList();

            return View(lands);
        }
    }
}