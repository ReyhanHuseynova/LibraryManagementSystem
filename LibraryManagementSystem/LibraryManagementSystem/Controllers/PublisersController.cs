using LibraryManagementSystem.DAL;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Controllers
{
    public class PublisersController : Controller
    {
        private readonly AppDbContext _db;
        public PublisersController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Publiser> pub = await _db.Publisers.ToListAsync();
            return View(pub);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Publiser pub)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            await _db.Publisers.AddAsync(pub);
            await  _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Publiser dbPub = await _db.Publisers.FirstOrDefaultAsync(x=>x.Id==id);
            if(dbPub == null)
            {
                return BadRequest();
            }
            return View(dbPub); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Publiser pub ,int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Publiser dbPub = await _db.Publisers.FirstOrDefaultAsync(x => x.Id == id);
            if (dbPub == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            dbPub.FirstName = pub.FirstName;
            dbPub.LastName = pub.LastName;
            await _db.SaveChangesAsync();   
           return RedirectToAction("Index");
        }

        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Publiser dbPub = await _db.Publisers.FirstOrDefaultAsync(x => x.Id == id);
            if (dbPub == null)
            {
                return BadRequest();
            }

            if(dbPub.IsDeactive)
            {
                dbPub.IsDeactive = false;
            }
            else
            {
                dbPub.IsDeactive = true;
            }

            await _db.SaveChangesAsync();   
            return RedirectToAction("Index");   
        }
    }
}
