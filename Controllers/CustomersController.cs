using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;


namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        // Database Context Setup
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // Action Methods

        public ViewResult Index()
        {
            // Get customers created locally
            //var customers = GetCustomers();

            // Get customers from dbContext
            var customers = _context.Customer.ToList();
            
            
            return View(customers);
        }

 

        public ActionResult Details(int id)
        {
            // Step 1 - Run GetCustomers() to get list of customers
            // Step 2 - For each customer when customer id equals the id that was passed in, store that customer
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);

            // Step 3 - if no customers match the condition above, throw 404 error
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer {Id = 1, Name = "Lowell"},
                new Customer {Id = 2, Name = "Erin"}
            };
        }
    }

}
