using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using CitizenScience.Models;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace CitizenScience.Controllers
{
    
    public class CollectionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string name, IFormFile picture, string description, int height,  int length, string color, string latitude, string longitude, DateTime date)
         {
            byte[] newPicture = new byte[0];
            if (picture != null)
            {
                using (Stream fileStream = picture.OpenReadStream())
                using (MemoryStream ms = new MemoryStream())
                {
                    fileStream.CopyTo(ms);
                    newPicture = ms.ToArray();
                }
            }
            Fauna newFauna = new Fauna(newPicture, name, description, length, height, color, latitude, longitude, date);
            newFauna.UserId = User.Identity.Name; 
            db.Faunas.Add(newFauna);
            db.SaveChanges();
            return RedirectToAction("Index", "Account");

        }
        [HttpPost ]
        public IActionResult SelectForm()
        {
            return PartialView("collect_form.cshtml");
        }
        public IActionResult MapLocation()
        {
            return View();
        }
    }
}
