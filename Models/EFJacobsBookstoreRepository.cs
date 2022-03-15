using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JacobsBookstore.Models
{
    public class EFJacobsBookstoreRepository : IJacobsBookstoreRepository
    {
        private BookstoreContext context { get; set; }
        

        //constructor
        public EFJacobsBookstoreRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
