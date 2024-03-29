﻿using RentBooks.Dtos;
using RentBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RentBooks.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            //if (newRental.BooksIds.Count() == 0)
            //    return BadRequest("No Book Ids have been given.");

            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

            //if (customer == null)
            //    return BadRequest("CustomerId is not valid.");

            var books = _context.Books.Where(m => newRental.BooksIds.Contains(m.Id)).ToList();

            //if (books.Count() != newRental.BooksIds.Count)
            //    return BadRequest("One or more BookIds are invalid.");

            var oldRentals = _context.Rentals.Where(c => c.CustomerId == newRental.CustomerId).ToList();
            var bookRentedAlready = oldRentals.Where(m => newRental.BooksIds.Contains(m.BookId)).ToList();

            foreach (var book in books)
            {
                if (book.NumberAvailable == 0)
                    return BadRequest("Book is not available.");

                if (books.Count() > 5)
                    return BadRequest("You can't rent more than 5 books.");

                if (bookRentedAlready.Count() > 0)
                    return BadRequest("You have rented this book already.");

                book.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Book = book,
                    DateRented = DateTime.Now

                };
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
