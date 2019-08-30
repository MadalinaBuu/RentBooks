using RentBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentBooks.ViewModels
{
    public class BookFormViewModel
    {
        public IEnumerable<BookGenre> Genre { get; set; }
        public Book Book { get; set; }
    }
}