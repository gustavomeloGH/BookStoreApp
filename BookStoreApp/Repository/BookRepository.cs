using BookStorage.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookStoreApp
{
    public class BookRepository : IRepository<Book>
    {
        private BookStoreDataContext _db;

        public BookRepository(BookStoreDataContext context)
        {
            _db = context;
        }
        
        public bool Create(Book book)
        {
            try
            {
                _db.Books.Add(book);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Book book)
        {
            try
            {
                _db.Entry<Book>(book).State = EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public void Delete(int id)
        {
            var book = _db.Books.Find(id);
            _db.Books.Remove(book);
            _db.SaveChanges();
        }

        public List<Book> List()
        {
            return _db.Books.ToList();
        }

        public Book Get(int id)
        {
            return _db.Books.Find(id);
        }

        public List<Book> Get(string name)
        {
            return _db.Books.Where(x => x.Name.Contains(name)).ToList() ;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

    }
}
