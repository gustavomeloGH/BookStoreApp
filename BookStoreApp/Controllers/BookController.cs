using BookStorage.Models;
using BookStoreApp.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace BookStoreApp.Controllers
{
    [RoutePrefix("livros")]
    public class BookController : Controller
    {

        private IRepository<Book> _bookRepository;
        private IRepository<Category> _categoryRepository;

        public BookController(IRepository<Book> bookRepository,
                              IRepository<Category> categoryRepository)
        {
            this._bookRepository = bookRepository;
            this._categoryRepository = categoryRepository;
        }

        [Route("listar")]
        public ActionResult Index()
        {
            return View(_bookRepository.List());
        }

        [Route("criar")]
        public ActionResult Create()
        {
            var categories = _categoryRepository.List();

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
            _bookRepository.Create(book);

            return RedirectToAction("Index");
        }


        [Route("editar")]
        public ActionResult Edit(int id)
        {
            var categories = _categoryRepository.List();
            var book = _bookRepository.Get(id);

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
            var book = _bookRepository.Get(model.Id);
            book.Name = model.Name;
            book.ISBN = model.ISBN;
            book.ReleaseDate = model.ReleaseDate;
            book.CategoryId = model.CategoryId;

            _bookRepository.Update(book);

            return RedirectToAction("Index");
        }
    }
}