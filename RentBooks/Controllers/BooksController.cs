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
        public ActionResult BookForm()
        {
            var genre = _context.Genre.ToList();
            var viewModel = new BookFormViewModel
            {
                Genre = genre
            };

            return View(viewModel);
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
        [HttpPost]
        public ActionResult Save(Book book)
        {
            if (book.Id == 0)
                _context.Books.Add(book);
            else
            {
                var bookInDb = _context.Books.Single(c => c.Id == book.Id);

                //Mapper.Map(customer, customerInDb);
                //it should be used with a partial class of Customer

                bookInDb.Name = book.Name;
                bookInDb.ReleaseDate = book.ReleaseDate;
                bookInDb.DateAdded = book.DateAdded;
                bookInDb.GenreId = book.GenreId;
                bookInDb.NumberInStock = book.NumberInStock;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Books");
        }
        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(c => c.Id == id);
            if (book == null)
                return HttpNotFound();

            var viewModel = new BookFormViewModel
            {
                Book = book,
                Genre = _context.Genre.ToList()
            };

            return View("BookForm", viewModel);
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