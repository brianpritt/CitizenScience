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
                ViewBag.listPopulate = db.Faunas.ToList();
                List<Fauna> allList = db.Faunas.ToList();
                return View(allList);
            }

            else
            {
                return View();
            }
            
        }
        [HttpPost]
        public IActionResult Result(string name) {
            Console.WriteLine(name);
            List<Fauna> result = new List<Fauna>();
            var thisList = db.Faunas.ToList();
            foreach(Fauna li in thisList)
            {
                if(name == li.FaunaName)
                {
                    result.Add(li);
                }
            }
            ViewBag.listPopulate = db.Faunas.ToList();
            Console.WriteLine("This is result: " + result);
            return View(result);

        }
    }
}
