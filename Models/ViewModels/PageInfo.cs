using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JacobsBookstore.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }

        //Figure out how many pages we need
        public int TotalPages => (int) Math.Ceiling((double) TotalNumBooks / BooksPerPage); //looks like a property, but it takes the formula as accessed 
        //Notice how we put double in front to CAST the int to a double
        //Notice how we need to put Math.Ceiling to ensure the page number is 5 if the equation is 4.3 to get all results
    }
}
