using Microsoft.AspNetCore.Mvc;
using System.Data;
using BOOKS_.Models.Repository;
using BOOKS_.Models;
using BOOKS_.ViewModels;
namespace BOOKS_.Controllers
{
    public class BookController : Controller
    {
        IBookRepository bookRepository;
        ICategoryRepository categoryRepository;
        IBookDetailsRepository bookDetailsRepository;
        public BookController(IBookRepository bookRepository , ICategoryRepository categoryRepository , IBookDetailsRepository bookDetailsRepository)
        {
            this.bookRepository = bookRepository;
            this.categoryRepository = categoryRepository;
            this.bookDetailsRepository = bookDetailsRepository;
        }

        public IActionResult Index()
        {
            List<Book> books = bookRepository.GetAll().ToList();
            return View(books);
        }
        public IActionResult Create()
        {
            ViewData["categories"] = categoryRepository.GetAll();
            return View();
        }
        public IActionResult SaveCreate(Book book)
        {
			// ViewData["categories"] = categoryRepository.GetAll();
			if (ModelState.IsValid)
            {
				bookRepository.Insert(book);
				return RedirectToAction("Index");
			}
            return View("Create",book);
                      
        }

        public IActionResult Edit(int id)
        {
			ViewData["categories"] = categoryRepository.GetAll();
			Book book = bookRepository.GetById(id);
            return View(book);
        }
        public IActionResult SaveEdit(int id , Book book)
        {
			ViewData["categories"] = categoryRepository.GetAll();
			if (ModelState.IsValid)
            {
				bookRepository.Update(id, book);
				return RedirectToAction("Index");
			}
            return View("Edit",book);
        }
        public IActionResult Details(int id)
        {
            var details = bookDetailsRepository.GetById(id);
            return View(details);
		}
        public IActionResult Delete(int id)
        {
            bookRepository.Delete(id); 
            return RedirectToAction("Index");
        }
    }
}
