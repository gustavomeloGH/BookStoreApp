using BookStorage.Models;
using System;
using System.Collections.Generic;

namespace BookStoreApp
{
    public interface IAuthorRepository : IDisposable
    {
        List<Author> Get();
        Author Get(int id);
        List<Author> Get(string name);
        bool Create(Author author);
        bool Update(Author author);
        void Delete(int id);

    }
}
