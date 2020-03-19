using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BookStorage.Models;

namespace BookStoreApp
{
    public class AuthorRepository : IAuthorRepository
    {
        private BookStoreDataContext _db;

        public AuthorRepository(BookStoreDataContext context)
        {
            _db = context;
        }

        public bool Create(Author author)
        {
            try
            {
                _db.Authors.Add(author);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Author author)
        {
            try
            {
                _db.Entry<Author>(author).State = EntityState.Modified;
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
            var author = _db.Authors.Find(id);
            _db.Authors.Remove(author);
            _db.SaveChanges();
        }

        public List<Author> Get()
        {
            return _db.Authors.ToList();
        }

        public Author Get(int id)
        {
            return _db.Authors.Find(id);
        }

        public List<Author> Get(string name)
        {
            return _db.Authors.Where(x => x.Name.Contains(name)).ToList() ;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

    }
}
