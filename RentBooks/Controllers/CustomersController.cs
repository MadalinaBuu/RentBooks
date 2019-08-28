using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RentBooks.Models;

namespace RentBooks.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        //intialize db in a constructor
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //dispose this object
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var customers = _context.Customers.ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}