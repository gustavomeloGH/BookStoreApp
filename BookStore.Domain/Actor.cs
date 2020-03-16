using System.Collections.Generic;

namespace BookStorage.Models
{
    public class Actor
    {

        public Actor()
        {
            this.Books = new List<Book>();
        }

        public ICollection<Book> Books { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }


    }
}