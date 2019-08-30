using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using RentBooks.Models;
using RentBooks.ViewModels;

namespace RentBooks.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext _context;

        //intialize db in a constructor
        public BooksController()
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
            var books = _context.Books.Include(c => c.Genre).ToList();

            return View(books);
        }
        public ActionResult Details(int id)
        {
            var books = _context.Books.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (books == null)
                return HttpNotFound();

            return View(books);

        }

        // GET: Books/Random
        public ActionResult Random()
        {
            var book = new Book() { Name = "Dama cu camelii" };
            var customers = new List<Customer>
            {
                new Customer{ Name = "John"},
                new Customer{ Name = "Lee"}
            };

            var viewModel = new RandomBooksViewModel
            {
                Book = book,
                Customers = customers
            };

            return View(viewModel);
        }
    }
}