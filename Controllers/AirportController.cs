using AirlineApp.Models;
using AirlineApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirlineApplication.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AirportController : Controller
    {
        private ApplicationDbContext context;

        public AirportController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        // GET: Airport
        public ActionResult Index()
        {
            List<Airport> airports = context.Airport.ToList();
            return View("Index");
        }

        //Get Airport By Id
        public ActionResult Details(string id)
        {
            Airport airport = context.Airport.ToList().SingleOrDefault(e => e.Id.ToString() == id);
            return View("Details", airport);
        }

        //Create Airport record 
        public ActionResult Create()
        {
            Airport airport = new Airport();
            return View("AirportForm", airport);
        }
     
        // POST Airport request method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProcessCreate(Airport airport)
        {
            var airportExist = context.Airport.SingleOrDefault(x => x.Name == airport.Name);
            if (ModelState.IsValid)
            {
                if (airportExist == null)
                {
                    context.Airport.Add(airport);
                    context.SaveChanges();
                    return View("Details", airport);
                }
                else
                {
                    ModelState.AddModelError("Name", "Airport name already exists");
                    return View("AirportForm", airport);
                }
            }
            else
            {
                return View("AirportForm", airport);
            }
        }
        
        //Update Airport details
        public ActionResult Edit(string id)
        {
            Guid guidId;
            try
            {
                guidId = Guid.Parse(id);
                var airport = context.Airport.ToList().SingleOrDefault(e => e.Id == guidId);
                if (airport == null) { throw new Exception(); }
                else { return View("AirportForm", airport); }
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }


        }

        // Update airport request method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProcessUpdate(Airport airport)
        {
            var query = context.Airport.SingleOrDefault(x => x.Id == airport.Id);
            var airportExist = context.Airport.SingleOrDefault(x => x.Name == airport.Name);
            if (ModelState.IsValid)
            {
                if (airportExist.Id == airport.Id)
                {
                    query.Name = airport.Name;
                    query.Country = airport.Country;
                    context.SaveChanges();
                    return View("Details", airport);
                }

                else
                {
                    ModelState.AddModelError("Name", "Airport already registered.");
                    return View("AirportForm", airport);
                }
            }
            else
            {
                return View("AirportForm", airport);
            }

        }

    }
}