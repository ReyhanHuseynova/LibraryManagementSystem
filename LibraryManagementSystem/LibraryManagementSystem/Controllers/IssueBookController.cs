using LibraryManagementSystem.DAL;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Controllers
{
    public class IssueBookController : Controller
    {
        private readonly AppDbContext _db;
        public IssueBookController(AppDbContext db)
        {
                _db=db;
        }
        public async Task<IActionResult> Index()
        {
            List<IssueBook> issues = await _db.IssueBooks.Include(x=>x.Author).ToListAsync();
            return View(issues);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Author = await _db.Authors.ToListAsync();
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IssueBook s, int authorSelect)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            ViewBag.Author = await _db.Authors.ToListAsync();
            s.AuthorId = authorSelect;
            await _db.IssueBooks.AddAsync(s);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Update(int? id)
        {
            ViewBag.Author = await _db.Authors.ToListAsync();

            if (id == null)
            {
                return NotFound();
            }

            IssueBook dbIssue = await _db.IssueBooks.FirstOrDefaultAsync(x => x.Id == id);
            if (dbIssue == null)
            {
                return BadRequest();
            }

            return View(dbIssue);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int? id, IssueBook s, int authorSelect)
        {
            ViewBag.Author = await _db.Authors.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }

            IssueBook dbIssue = await _db.IssueBooks.FirstOrDefaultAsync(x => x.Id == id);
            if (dbIssue == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            dbIssue.IssueDate = s.IssueDate;
            dbIssue.ReturnDate = s.ReturnDate;
            dbIssue.AuthorId =authorSelect;
           await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IssueBook dbIssue = await _db.IssueBooks.FirstOrDefaultAsync(x => x.Id == id);
            if (dbIssue == null)
            {
                return BadRequest();
            }
            if (dbIssue.IsDeactive)
            {
                dbIssue.IsDeactive = false;
            }
            else
            {
                dbIssue.IsDeactive = true;
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
