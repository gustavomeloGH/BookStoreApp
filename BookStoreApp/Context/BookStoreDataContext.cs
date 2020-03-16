using BookStorage.Models;
using BookStoreApp.Mapping;
using System.Data.Entity;

namespace BookStorage.Context
{

    public class BookStoreDataContext : DbContext
    {
        public BookStoreDataContext() : base("DefaultConnection")
        {
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ActorMap());
            modelBuilder.Configurations.Add(new BookMap());

        }

    }
}