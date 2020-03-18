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

        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new AuthorMap());
            modelBuilder.Configurations.Add(new BookMap());

        }

    }
}