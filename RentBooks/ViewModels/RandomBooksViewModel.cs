using RentBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentBooks.ViewModels
{
    public class RandomBooksViewModel
    {
        public Book Book { get; set; }
        public List<Customer> Customers { get; set; }
}
}