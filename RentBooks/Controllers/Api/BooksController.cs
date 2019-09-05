using AutoMapper;
using RentBooks.Dtos;
using RentBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace RentBooks.Controllers.Api
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/books
        //public IEnumerable<BookDto> GetBooks(string query = null)
        //{
        //    var booksQuery = _context.Books
        //        .Include(m => m.Genre)
        //        .Where(m => m.NumberAvailable > 0);

        //    if (!String.IsNullOrWhiteSpace(query))
        //        booksQuery = booksQuery.Where(m => m.Name.Contains(query));

        //    return booksQuery
        //        .ToList()
        //        .Select(Mapper.Map<Book, BookDto>);
        //}
        public IEnumerable<BookDto> GetBooks(string query = "")
        {
            var booksQuery = _context.Books.Include(m => m.Genre);
            return booksQuery.Where(m => m.Name.Contains(query)).ToList().Select(Mapper.Map<Book, BookDto>);
        }
        //GET /api/book/1
        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Books.SingleOrDefault(c => c.Id == id);

            if (book == null)
                return NotFound();

            return Ok(Mapper.Map<Book, BookGenreDto>(book));
        }
        //POST /api/books
        [HttpPost]
        public IHttpActionResult CreateBook(BookGenreDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var book = Mapper.Map<BookGenreDto, Book>(bookDto);
            _context.Books.Add(book);
            _context.SaveChanges();

            bookDto.Id = book.Id;

            return Created(new Uri(Request.RequestUri + "/" + book.Id), bookDto);
        }
        //PUT /api/books/1
        [HttpPut]
        public IHttpActionResult UpdateBook(int id, BookGenreDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var bookInDb = _context.Books.SingleOrDefault(c => c.Id == id);

            if (bookInDb == null)
                return NotFound();

            Mapper.Map(bookDto, bookInDb);

            _context.SaveChanges();
            return Ok();
        }
        //DELETE /api/books/1
        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            var bookInDb = _context.Books.SingleOrDefault(c => c.Id == id);

            if (bookInDb == null)
                return NotFound();

            _context.Books.Remove(bookInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
