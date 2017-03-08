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
                List<Fauna> allList = db.Faunas.ToList();
                return View(allList);
            }
            else
            {
                return View();
            }
            
        }
        [HttpPost]
        public IActionResult Index(string name) {
            List<Fauna> result = new List<Fauna>();
            var thisList = db.Faunas.ToList();
            foreach(Fauna li in thisList)
            {
                if(name == li.FaunaDescripton)
                {
                    result.Add(li);
                }
            }
            Console.WriteLine("This is result: " + result);
            return View(result);

        }
    }
}
