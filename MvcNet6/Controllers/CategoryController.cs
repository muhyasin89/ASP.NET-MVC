using Microsoft.AspNetCore.Mvc;
using MvcNet6.Data;
using MvcNet6.Models;

namespace MvcNet6.Controllers
{
	public class CategoryController : Controller
	{

		private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
			_db = db;
        }
        public IActionResult Index()
		{

			IEnumerable<Category> objCategoryList = _db.Categories;
			return View(objCategoryList);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Category obj)
		{
			if(obj.Name == obj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("Custom Error", "The  display order cannot exactly match the name");
			}
			if(ModelState.IsValid)
			{
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category has been Created";
                return RedirectToAction("Index");
            }

			return View(obj);
			
		}

        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Custom Error", "The  display order cannot exactly match the name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category has been Edited";
                return RedirectToAction("Index");
            }

            return View(obj);

        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
            
            if (obj == null)
            {
                return NotFound();
            }
           
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category has been Deleted";
            return RedirectToAction("Index");

        }
    }
}
