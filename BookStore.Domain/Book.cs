using System;
using System.Collections.Generic;

namespace BookStorage.Models
{
    public class Book
    {

        public Book()
        {
            this.Authors = new List<Author>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}