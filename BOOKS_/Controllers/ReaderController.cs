using BOOKS_.Models;
using BOOKS_.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BOOKS_.Controllers
{
    public class ReaderController : Controller
    {
        IReaderRepository readerRepository;
        IBookReaderRepository bookReaderRepository;
        public ReaderController(IReaderRepository readerRepository , IBookReaderRepository bookReaderRepository)
        {
            this.readerRepository = readerRepository;
            this.bookReaderRepository = bookReaderRepository;
        }
        public JsonResult Limit(int Age)
        {
            if (Age >= 18)
            {
                return Json(true);
            }
            else { return Json(false); }
        }
        public IActionResult Index()
        {
            List<Reader> readers = readerRepository.GetAll();
            return View(readers);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult SaveCreate(Reader reader)
        {
            if(ModelState.IsValid)
            {
                readerRepository.Insert(reader);
                return RedirectToAction("Index");
            }
            return View("Create", reader);
        }
        public IActionResult Details(int id)
        {
            Reader reader = readerRepository.GetById(id);
            return View(reader);
        }
        public IActionResult Edit(int id )
        {
            Reader reader = readerRepository.GetById(id);
            return View(reader);

        }
        public IActionResult SaveEdit(int id,Reader reader)
        {
            if(ModelState.IsValid)
            {
                readerRepository.Update(id, reader);
                return RedirectToAction("Index");
            }
            return View("Edit", reader);
        }
        public IActionResult Delete(int id)
        {
            readerRepository.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult GetDetailsReaderWithRelatedBook()
        {
            List<ReaderBook> readerBooks = bookReaderRepository.DetailsReadersWithBooks();
            return View(readerBooks);

		}
        public IActionResult ShowPhoto(int id)
        {
            Reader reader = readerRepository.GetById(id);
            return View(reader);
        }
    }
}
