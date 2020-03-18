using System.Collections.Generic;

namespace BookStorage.Models
{
    public class Author
    {

        public Author()
        {
            this.Books = new List<Book>();
        }

        public ICollection<Book> Books { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }


    }
}