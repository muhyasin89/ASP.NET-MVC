﻿using Microsoft.AspNetCore.Mvc;
using MvcNet6.Data;

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

			var objCategoryList = _db.Categories.ToList();
			return View(objCategoryList);
		}
	}
}
