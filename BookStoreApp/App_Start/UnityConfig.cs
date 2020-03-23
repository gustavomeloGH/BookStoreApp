using BookStorage.Models;
using BookStoreApp.Repository;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace BookStoreApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IRepository<Author>, AuthorRepository>();
            container.RegisterType<IRepository<Book>, BookRepository>();
            container.RegisterType<IRepository<Category>, CategoryRepository>();

            container.RegisterType<BookStoreDataContext, BookStoreDataContext>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}