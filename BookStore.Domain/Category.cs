using System.Collections.Generic;

namespace BookStorage.Models
{
    public class Category
    {

        public Category()
        {
            this.Books = new List<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}