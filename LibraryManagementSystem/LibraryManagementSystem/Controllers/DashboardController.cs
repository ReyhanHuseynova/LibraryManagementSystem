using LibraryManagementSystem.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;

namespace LibraryManagementSystem.Controllers
{
	public class DashboardController : Controller
	{
		private readonly AppDbContext _db;
        public DashboardController(AppDbContext db)
        {
			_db = db;
        }
        public IActionResult Index()
		{
			ViewBag.BookCount = _db.IssueBooks.Count();
			ViewBag.Rack = _db.Racks.Count();
			ViewBag.Cat = _db.Categories.Count();
			ViewBag.Pub = _db.Publisers.Count();
			return View();
		}

		
	}
}
