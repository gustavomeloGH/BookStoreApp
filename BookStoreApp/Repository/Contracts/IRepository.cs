using System;
using System.Collections.Generic;

namespace BookStoreApp
{
    public interface IRepository<T> : IDisposable where T : class
    {
        
        List<T> List();
        T Get(int id);
        List<T> Get(string name);
        bool Create(T t);
        bool Update(T t);
        void Delete(int id);

    }
}
