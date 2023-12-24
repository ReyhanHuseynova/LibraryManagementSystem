using LibraryManagementSystem.DAL;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Controllers
{
	public class CategoriesController : Controller
	{
		private readonly AppDbContext _db;
        public CategoriesController(AppDbContext db)
        {
			_db = db; 
        }
        public async Task<IActionResult> Index()
		{
			List<Category> categories = await _db.Categories.ToListAsync();
			return View(categories);
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Category category)
		{
			if(!ModelState.IsValid)
			{
				return View();
			}

			bool isExist = await _db.Categories.AnyAsync(x => x.CategoryName == category.CategoryName);
			if(isExist)
			{
				ModelState.AddModelError("CategoryName", "This category already exist");
				return View();
			}
			
			await _db.Categories.AddAsync(category);
			await _db.SaveChangesAsync();
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Update(int? id)
		{
            if (id == null)
			{
				return NotFound();
			}
           
			Category dbCategory= await _db.Categories.FirstOrDefaultAsync(x=>x.Id==id);
            if (dbCategory==null)
            {
				return BadRequest();
            }
            return View(dbCategory);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]

		public async Task<IActionResult> Update(Category category, int? id)
		{
		
			if (id == null)
			{
				return NotFound();
			}

			Category dbCategory = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
			if (dbCategory==null)
			{
				return BadRequest();
			}

            if (!ModelState.IsValid)
            {
                return View();
            }

			bool isExist = await _db.Categories.AnyAsync(x => x.CategoryName == category.CategoryName && x.Id!=id);
			if (isExist)
			{
				ModelState.AddModelError("CategoryName", "This category already exist");
				return View();
			}

            dbCategory.Description=category.Description;
			dbCategory.CategoryName=category.CategoryName;	
			await _db.SaveChangesAsync();
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Activity(int? id)
		{
			if(id == null)
			{
				return NotFound();
			}

			Category dbCategory = await _db.Categories.FirstOrDefaultAsync(x=>x.Id==id);
			if(dbCategory==null)
			{
				return BadRequest();
			}

			if (dbCategory.IsDeactive)
			{
				dbCategory.IsDeactive = false;
			}
			else
			{
				dbCategory.IsDeactive = true;
			}
			await _db.SaveChangesAsync();
			return RedirectToAction("Index");	
		}

		
	}
}
