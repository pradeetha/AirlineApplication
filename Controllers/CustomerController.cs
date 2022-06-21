using AirlineApp.Models;
using AirlineApplication.Models;
using AirlineApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirlineApplication.Controllers
{

    [Authorize]
    [AllowAnonymous]
    public class CustomerController : Controller
    {
        private ApplicationDbContext context;
       
        public CustomerController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> customerData = context.Customer.ToList(); 
            return View("Index", customerData);
        }

        //Get Customer by Id
        public ActionResult Details(string id)
        {
           Customer customer = context.Customer.ToList().SingleOrDefault(e => e.Id.ToString() == id);
            return View("Details", customer);
        }

        public ActionResult Create()
        {
            
            return View("Register");
        }

        public ActionResult Edit(string id)
        {
            Guid guidId;
            try
            {
                guidId = Guid.Parse(id);
                var customer = context.Customer.ToList().SingleOrDefault(e => e.Id == guidId);
                if (customer == null) { throw new Exception(); }
                else { return View("Register", customer); }
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
           
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProcessCreate(Customer customer)
        {
            var emailExist = context.Customer.SingleOrDefault(x => x.Email == customer.Email);
            if (ModelState.IsValid) {
                if (emailExist == null)
                {
                    context.Customer.Add(customer);
                    context.SaveChanges();
                    return View("Details", customer);
                }
                else
                {
                    ModelState.AddModelError("Email", "Email already exists");
                    return View("Register", customer);
                }
            }
            else {
                return View("Register", customer);
            }
            
        }

        [HttpPatch]
        [ValidateAntiForgeryToken]
        public ActionResult ProcessUpdate(Customer customer)
        {
            var query = context.Customer.SingleOrDefault(x => x.Id == customer.Id);
            var emailExist = context.Customer.SingleOrDefault(x => x.Email == customer.Email);
            if (ModelState.IsValid) {
                if (emailExist.Id == customer.Id)
                {
                    query.FirstName = customer.FirstName;
                    query.LastName = customer.LastName;
                    query.Phone = customer.Email;
                    query.Email = customer.Email;
                    context.SaveChanges();
                    return View("Details", customer);
                }

                else
                {
                    ModelState.AddModelError("Email", "Email already exists");
                    return View("Register", customer);
                }
            }
            else
            {
                return View("Register", customer);//Form needs fixing
            }

        }

    }
}