using LibraryManagementSystem.DAL;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly AppDbContext _db;
        public AuthorsController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Author> authorList = await _db.Authors.ToListAsync();
            return View(authorList);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Publiser= await _db.Publisers.ToListAsync();
            ViewBag.Rack= await _db.Racks.ToListAsync();
            ViewBag.Cat = await _db.Categories.ToListAsync();

            return View();      
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author author,int publiserSelect, int rackSelect, int catSelect)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            ViewBag.Publiser = await _db.Publisers.ToListAsync();
            ViewBag.Rack = await _db.Racks.ToListAsync();
            ViewBag.Cat = await _db.Categories.ToListAsync();
            author.PubliserId = publiserSelect;
            author.RackId = rackSelect; 
            author.CategoryId= catSelect;   
            await _db.Authors.AddAsync(author);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");   
        }

        public async Task<ActionResult> Update(int? id)
        {
            ViewBag.Publiser = await _db.Publisers.ToListAsync();
            ViewBag.Rack = await _db.Racks.ToListAsync();
            ViewBag.Cat = await _db.Categories.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }

            Author dbAuthor= await _db.Authors.FirstOrDefaultAsync(x=>x.Id==id);
            if(dbAuthor == null)
            {
                return BadRequest();
            }

            return View(dbAuthor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int? id,Author author, int publiserSelect, int rackSelect, int catSelect)
        {
            ViewBag.Publiser = await _db.Publisers.ToListAsync();
            ViewBag.Rack = await _db.Racks.ToListAsync();
            ViewBag.Cat = await _db.Categories.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }

            Author dbAuthor = await _db.Authors.FirstOrDefaultAsync(x => x.Id == id);
            if (dbAuthor == null)
            {
                return BadRequest();
            }
            if(!ModelState.IsValid)
            {
                return View();
            }
            dbAuthor.BookName = author.BookName;
            dbAuthor.LastName = author.LastName;
            dbAuthor.FirstName = author.FirstName;
            dbAuthor.CategoryId= catSelect;
            dbAuthor.RackId= rackSelect;
            dbAuthor.PubliserId= publiserSelect;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Activity(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Author dbAuthor= await _db.Authors.FirstOrDefaultAsync(x=>x.Id==id);
            if (dbAuthor == null)
            {
                return BadRequest();
            }
            if(dbAuthor.IsDeactive)
            {
                dbAuthor.IsDeactive = false;
            }
            else
            {
                dbAuthor.IsDeactive = true;
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Search(string bookname)
        {
           List<Author> a = _db.Authors.Where(a => a.BookName.Trim().ToUpper().Contains(bookname.Trim().ToUpper())).ToList();
            if(a!=null)
            {
                return View("SearchDetail",a);

            }
            else
            {
                return NotFound("Bele bir kitab yoxdur!");  
            }

        }

        public IActionResult SearchDetail()
        {
            return View();
        }
    }
}
