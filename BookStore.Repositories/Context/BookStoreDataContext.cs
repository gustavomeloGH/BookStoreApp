using BookStorage.Models;
using BookStore.Persistence.Mapping;
using System.Data.Entity;

namespace BookStore.Persistence.Context
{

    public class BookStoreDataContext : DbContext
    {
        public BookStoreDataContext() : base("BookStoreConnectionString")
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