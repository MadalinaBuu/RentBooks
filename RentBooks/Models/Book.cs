using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentBooks.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BookGenre Genre { get; set; }
        public byte GenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int NumberInStock { get; set; }

    }
}