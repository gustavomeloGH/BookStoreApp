using BookStorage.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookStoreApp.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        private BookStoreDataContext _db;

        public CategoryRepository(BookStoreDataContext context)
        {
            _db = context;
        }
       
        public bool Create(Category caregory)
        {
            try
            {
                _db.Categories.Add(caregory);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Category caregory)
        {
            try
            {
                _db.Entry<Category>(caregory).State = EntityState.Modified;
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
            var category = _db.Categories.Find(id);
            _db.Categories.Remove(category);
            _db.SaveChanges();
        }

        public List<Category> List()
        {
            return _db.Categories.ToList();
        }

        public Category Get(int id)
        {
            return _db.Categories.Find(id);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public List<Category> Get(string name)
        {
            return _db.Categories.Where(x => x.Name.Contains(name)).ToList();
        }
    }
}