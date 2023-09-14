using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public UsersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;    
        }
        public async Task<IActionResult> Index()
        {
            List<AppUser> appUsers = await _userManager.Users.ToListAsync();
            List<UserVM> userVMs = new List<UserVM>();
            foreach (AppUser user in appUsers)
            {
                UserVM userVM = new UserVM
                {
                    Id = user.Id,
                    FullName = user.Name + user.Surname,
                    Username= user.UserName,    
                    Email = user.Email,
                    IsDeactive = user.IsDeactive,
                    Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault()
                };
                userVMs.Add(userVM);
            }

            return View(userVMs);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegisterVM registerVM, string roleName)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            AppUser appUser = new AppUser
            {
                Name= registerVM.Name,
                Surname= registerVM.Surname,
                Email= registerVM.Email,
                UserName=registerVM.Username
            };

           IdentityResult identityResult= await _userManager.CreateAsync(appUser);
            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            await _userManager.AddToRoleAsync(appUser, roleName);   
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

           
            AppUser appUser= await _userManager.FindByIdAsync(id);  
            if (appUser == null)
            {
                return BadRequest();
            }
           
            UpdateVM updateVM = new UpdateVM()
            {
              Email=appUser.Email,
              Username=appUser.UserName,
              Name=appUser.Name,
              Surname= appUser.Surname,
              Role = (await _userManager.GetRolesAsync(appUser)).First()
            };

            return View(updateVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string id,UpdateVM updateVM, string roleName)
        {
            if (id == null)
            {
                return NotFound();
            }
             AppUser appUser = await _userManager.FindByIdAsync(id);
            if (appUser == null)
            {
                return BadRequest();
            }

            string oldRole = (await _userManager.GetRolesAsync(appUser)).First();

            UpdateVM dbUpdateVM = new UpdateVM()
            {
                Email = appUser.Email,
                Username = appUser.UserName,
                Name = appUser.Name,
                Surname = appUser.Surname,
                Role = oldRole
            };
            appUser.Surname = updateVM.Surname;
            appUser.Name = updateVM.Name;
            appUser.UserName = updateVM.Username;
            appUser.Email = updateVM.Email;

         IdentityResult redidentityResult= await _userManager.RemoveFromRoleAsync(appUser,roleName);
            if (!redidentityResult.Succeeded)
            {
                foreach (IdentityError error in redidentityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
         IdentityResult adddidentityResult= await _userManager.AddToRoleAsync(appUser,roleName);
            if (!adddidentityResult.Succeeded)
            {
                foreach (IdentityError error in adddidentityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            await _userManager.UpdateAsync(appUser);
            return RedirectToAction("Index");
        }
          public async Task<IActionResult> Activity(string id)
        {
            if(id == null)
            {
                return NotFound();
            }

            AppUser appUser= await _userManager.FindByIdAsync(id);  
            if (appUser == null)
            {
                return BadRequest();
            }
            if(appUser.IsDeactive)
            {
                appUser.IsDeactive = false;
            }
            else
            {
                appUser.IsDeactive = true;
            }
            await _userManager.UpdateAsync(appUser);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ResetPassword(string id)
        {
            if(id == null)
            {
                return NotFound();
            }
            AppUser appUser = await _userManager.FindByIdAsync(id);
            if (appUser == null)
            {
                return BadRequest();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(string id, ResetPasswordVM reset)
        {
            if (id == null)
            {
                return NotFound();
            }
            AppUser appUser = await _userManager.FindByIdAsync(id);
            if (appUser == null)
            {
                return BadRequest();
            }
         string token= await _userManager.GeneratePasswordResetTokenAsync(appUser);
           IdentityResult ıdentityResult= await _userManager.ResetPasswordAsync(appUser,token,reset.Password);
            if (!ıdentityResult.Succeeded)
            {
                foreach (IdentityError error in ıdentityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            return RedirectToAction("Index");
        }



    }
}
