﻿using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;     
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        
        public AccountController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager; 
            _signInManager = signInManager; 
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            AppUser appUser = new AppUser
            {
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                UserName = registerVM.Username,
                Email = registerVM.Email,

            };

          IdentityResult identityResult = await _userManager.CreateAsync(appUser, registerVM.Password);
            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();  
            }

            await _userManager.AddToRoleAsync(appUser,"Member");
            await _signInManager.SignInAsync(appUser, true);
            return RedirectToAction("Index","Dashboard");
        }

        //public async Task CreateRoles()
        //{
        //    if(!await _roleManager.RoleExistsAsync("Admin"))
        //    {
        //       await _roleManager.CreateAsync(new IdentityRole { Name= "Admin"});
        //    }
        //   if(! await _roleManager.RoleExistsAsync("Member"))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });
        //    }
        //}

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            AppUser appUser = await _userManager.FindByNameAsync(loginVM.Username);
            if (appUser == null)
            {
                ModelState.AddModelError("Username", "Username or Password is wrong!");
                return View();
            }
            if(appUser.IsDeactive)
            {
                ModelState.AddModelError("Username", "Blocked!");
                return View();
            }
          Microsoft.AspNetCore.Identity.SignInResult signInResult= await _signInManager
                .PasswordSignInAsync(appUser,loginVM.Password,true,true); 
            if(signInResult.IsLockedOut)
            {
                ModelState.AddModelError("Username", "Blocked one minutes!");
                return View();
            }
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("Username", "Username or Password is wrong!");
                return View();
            }
            return RedirectToAction("Index","Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
