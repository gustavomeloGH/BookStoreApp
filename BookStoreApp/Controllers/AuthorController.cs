using BookStorage.Models;
using System.Web.Mvc;

namespace BookStoreApp.Controllers
{

    [RoutePrefix("autores")]
    //[LogActionFilters()]
    public class AuthorController : Controller
    {
        private IRepository<Author> _repository;    

        public AuthorController(IRepository<Author> repository)
        {
            _repository = repository;
        }

        [Route("")]
        [Route("listar")]
        public ActionResult Index()
        {
            var authorList = _repository.List();
            return View(authorList);
        }

        [Route("criar")]
        [HttpPost]
        public ActionResult Create(Author author)
        {
            if (_repository.Create(author))
            {
                return RedirectToAction("Index");
            }
            return View(author);
        }
        
        [Route("editar/{id:int}")]
        public ActionResult Edit(int id)
        {
            var author = _repository.Get(id);
            return View(author);
        }

        [Route("excluir/{id:int}")]
        public ActionResult Delete(int id)
        {
            var author = _repository.Get(id);
            return View(author);
        }


        [Route("excluir/{id:int}")]
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}