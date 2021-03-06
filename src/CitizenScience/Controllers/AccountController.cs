﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CitizenScience.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
using CitizenScience.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CitizenScience.Controllers
{

    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }



        public IActionResult Index()
        {
          
            if (User.Identity.IsAuthenticated)
            {
                List <Fauna> userSubmitted = new List<Fauna>();
                var thisList = _db.Faunas.ToList();
                foreach(Fauna li in thisList)
                {
                    if (li.UserId == User.Identity.Name)
                    {
                        userSubmitted.Add(li);
                    }
                }
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                return View(userSubmitted);

            }
            else
            {
                return View();
            }
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            //add list of usernames, check against them for user name
            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else 
            {
                return View();
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

    }
}