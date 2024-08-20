using BOOKS_.Models;
using BOOKS_.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BOOKS_.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            List<Category> categories = categoryRepository.GetAll();
            return View(categories);
        }
        public IActionResult Delete(int id)
        {
            categoryRepository.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult SaveCreate(Category category)
        {
            if(ModelState.IsValid)
            {
				categoryRepository.Insert(category);
				return RedirectToAction("Index");
			}
            return View("Create", category);
        }
    }
}
