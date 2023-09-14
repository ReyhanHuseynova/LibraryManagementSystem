using LibraryManagementSystem.DAL;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Controllers
{
    public class RacksController : Controller
    {
        private readonly AppDbContext _db;
        public RacksController(AppDbContext db)
        {
            _db = db;
        }
        public  async Task<IActionResult> Index()
        {
            List<Rack> racks = await _db.Racks.ToListAsync();
            return View(racks);
        }

        public async Task<IActionResult> Create()
        {
            return View();  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Rack rack)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            bool isExist =await _db.Racks.AnyAsync(x => x.RackNumber == rack.RackNumber);
            if (isExist)
            {
                ModelState.AddModelError("RackNumber", "This rack is already exist");
                return View();
            }
           await _db.Racks.AddAsync(rack);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            Rack dbRack=await _db.Racks.FirstOrDefaultAsync(r => r.Id==id);
            if(dbRack==null)
            {
                return BadRequest();
            }
            return View(dbRack);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Rack rack)
        {
            if(id==null)
            {
                return NotFound();
            }

            Rack dbRack= await _db.Racks.FirstOrDefaultAsync(r=>r.Id==id);
            if(dbRack==null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            bool isExist= await _db.Racks.AnyAsync(r=>r.RackNumber==rack.RackNumber &&  r.Id!=rack.Id);
            if (isExist)
            {
                ModelState.AddModelError("RackNumber","This rack is already exist");
                return View();
            }
            dbRack.RackNumber=rack.RackNumber;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");   
        }

        public async Task<IActionResult> Activity(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }

            Rack dbRack = await _db.Racks.FirstOrDefaultAsync(r=>r.Id==id);
            if (dbRack==null)
            {
                return BadRequest();
            }

            if(dbRack.IsDecative)
            {
                dbRack.IsDecative = false;
            }
            else
            {
                dbRack.IsDecative = true;
            }
           await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
