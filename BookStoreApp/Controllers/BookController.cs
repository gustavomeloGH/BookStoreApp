using BookStorage.Models;
using BookStoreApp.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace BookStoreApp.Controllers
{
    [RoutePrefix("livros")]
    public class BookController : Controller
    {

        private BookStoreDataContext _db;

        public BookController(BookStoreDataContext context)
        {
            this._db = context;
        }

        [Route("listar")]
        public ActionResult Index()
        {
            return View(_db.Books.ToList());
        }

        [Route("criar")]
        public ActionResult Create()
        {
            var categories = _db.Categories.ToList();

            var model = new EditorBookViewModel
            {
                Name = "",
                ISBN = "",
                CategoryId = 0,
                CategoryOptions = new SelectList(categories, "Id", "Name")
            };

            return View(model);
        }

        [Route("criar")]
        [HttpPost]
        public ActionResult Create(EditorBookViewModel model)
        {
            var book = new Book();
            book.Name = model.Name;
            book.ISBN = model.ISBN;
            book.ReleaseDate = model.ReleaseDate;
            book.CategoryId = model.CategoryId;
            _db.Books.Add(book);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        [Route("editar")]
        public ActionResult Edit(int id)
        {
            var categories = _db.Categories.ToList();
            var book = _db.Books.Find(id);

            var model = new EditorBookViewModel
            {
                Name = book.Name,
                ISBN = book.ISBN,
                CategoryId = book.CategoryId,
                CategoryOptions = new SelectList(categories, "Id", "Name")
            };

            return View(model);
        }

        [Route("editar")]
        [HttpPost]
        public ActionResult Edit(EditorBookViewModel model)
        {
            var book = _db.Books.Find(model.Id);
            book.Name = model.Name;
            book.ISBN = model.ISBN;
            book.ReleaseDate = model.ReleaseDate;
            book.CategoryId = model.CategoryId;

            _db.Entry<Book>(book).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}