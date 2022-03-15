using JacobsBookstore.Models;
using JacobsBookstore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JacobsBookstore.Controllers
{
    public class HomeController : Controller
    {
        private IJacobsBookstoreRepository repo;
        public HomeController (IJacobsBookstoreRepository temp)
        {
            repo = temp;
        }



        public IActionResult Index(int pageNum = 1) //Page is specified word by asp.net
        {
            int pageSize = 10;

            //BECAUSE varaible need semicolon
            var x = new BooksViewModel
            {
                Books = repo.Books
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            return View(x);
        
        //REMOVED ONCE PUT INTO THE COMBINED FORM
        //    var meh = repo.Books              //repo is being grabbed from EFRepository and its the IQuerable
        //        .OrderBy(b => b.Title)
        //        .Skip((pageNum-1)*pageSize)
        //        .Take(pageSize);              //References BookstoreContext.cs line 23
        //       return View(meh);
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
