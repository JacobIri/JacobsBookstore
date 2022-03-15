using JacobsBookstore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using JacobsBookstore.Models;

namespace JacobsBookstore.Controllers
{
    public class HomeController : Controller
    {
        private IJacobsBookstoreRepository repo;
        public HomeController (IJacobsBookstoreRepository temp)
        {
            repo = temp;
        }



        public IActionResult Index()
        {
            var meh = repo.Books.ToList(); //BookstoreContext line 23
            return View(meh);
        }
        //SAME AS ABOVE
        //public IActionResult Index() => View();
        


        //OLD
        //private BookstoreContext context { get; set; }

        
        //public HomeController(BookstoreContext temp)
        //{
        //    context = temp;
        //}
        ////SAME AS ABOVE
        ////public HomeController(BookstoreContext temp) => context = temp;

    }
}
