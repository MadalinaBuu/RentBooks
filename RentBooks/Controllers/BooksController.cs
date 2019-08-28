using System.Collections.Generic;
using System.Web.Mvc;
using RentBooks.Models;
using RentBooks.ViewModels;

namespace RentBooks.Controllers
{
    public class BooksController : Controller
    {
        public ViewResult Index()
        {
            var books = GetBooks();

            return View(books);
        }

        private IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book { Id = 1, Name = "La rasarit de Eden" },
                new Book { Id = 2, Name = "Matilda" }
            };
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