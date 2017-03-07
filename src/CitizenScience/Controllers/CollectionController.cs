using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using CitizenScience.Models;

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
        public IActionResult Create(IFormFile picture, string name, string description, int length, int height, string color, string location)
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
            Fauna newFauna = new Fauna(newPicture, name, description, length, height, color, location);
            db.Faunas.Add(newFauna);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult MapLocation()
        {
            return View();
        }
    }
}
