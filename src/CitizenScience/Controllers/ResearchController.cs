using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CitizenScience.Models;
using System.Diagnostics;

namespace CitizenScience.Controllers
{
    public class ResearchController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.listPopulate  = db.Faunas.ToList();
                List<Fauna> allList = db.Faunas.ToList();
                return View();
            }

            else
            {
                return View();
            }
            
        }
        [HttpPost]
        public IActionResult Result(string search) {
            Debug.WriteLine("#############" + search);
            var results = from FaunaName in db.Faunas
                         select FaunaName;

            if (!String.IsNullOrEmpty(search))
            {
               
                results = results.Where(s => s.FaunaName.Contains(search));
            }
            //List<Fauna> result = new List<Fauna>();
            //var thisList = db.Faunas.ToList();
            //foreach(Fauna li in thisList)
            //{
            //    if(name == li.FaunaName)
            //    {
            //        result.Add(li);
            //    }
            //}
            ViewBag.listPopulate = db.Faunas.ToList();
            Console.WriteLine("This is result: " + results);
            return View(results);
        }
        [HttpPost]
        public IActionResult API(string name) 
        {
            
            List<Fauna> resultAPI = new List<Fauna>();
            var thisList = db.Faunas.ToList();
            foreach (Fauna li in thisList)
            {
                if (name == li.FaunaName)
                {
                    resultAPI.Add(li);
                }
            }
            Console.WriteLine("This is result: " + resultAPI);
            return Json(resultAPI);
        }
    }
}
