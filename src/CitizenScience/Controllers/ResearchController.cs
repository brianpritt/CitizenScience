using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CitizenScience.Models;


namespace CitizenScience.Controllers
{
    public class ResearchController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            { 
                return View(db.Faunas.ToList());
            }
            else
            {
                return View();
            }
            
        }
    }
}
