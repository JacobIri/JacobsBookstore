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



        public IActionResult Index(int pageNum = 0) //Why page 1 not page 0   //Page is specified word by asp.net
        {
            int pageSize = 5;

            var meh = repo.Books
                .OrderBy(b => b.Title)
                //.Skip(pageNum*pageSize)
                //.Take(5);              //References BookstoreContext.cs line 23
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
