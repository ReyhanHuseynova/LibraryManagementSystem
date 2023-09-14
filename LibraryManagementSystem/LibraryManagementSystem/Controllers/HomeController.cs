using LibraryManagementSystem.DAL;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db=db;
        }

        public IActionResult Index()
		{
			HomeVM homeVM = new HomeVM
			{
				Authors= _db.Authors.Include(x=>x.Category).Include(x => x.Publiser)
				.Include(x => x.Rack).ToList(),
			};
			return View(homeVM);
		}

		

		
		public IActionResult Error()
		{
			return View();
		}
	}
}
