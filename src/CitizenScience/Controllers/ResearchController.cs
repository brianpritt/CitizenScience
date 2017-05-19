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

        public IActionResult Details(int id)
        {
            var thisFauna = db.Faunas.FirstOrDefault(fauna => fauna.FaunaId == id);
            return View(thisFauna);
        }

        [HttpPost]
        public IActionResult Result(string search) {
            var results = from FaunaName in db.Faunas
                         select FaunaName;

            if (!String.IsNullOrEmpty(search))
            {
               
                results = results.Where(s => s.FaunaName.Contains(search));
            }
            return View(results);
        }
        [HttpPost]
        public IActionResult API(string name) 
        {
            //string v = Request.QueryString["param"];
            //if (v != null)
            //{
            //    var results = from FaunaName in db.Faunas
            //                  select FaunaName;

            //    if (!String.IsNullOrEmpty(v))
            //    {

            //        results = results.Where(s => s.FaunaName.Contains(v));
            //    }
            //    return Json(results);
            //}

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
            return Json(null);
        }
    }
}
