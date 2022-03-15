using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JacobsBookstore.Models
{
    //Interface is not a class       must implement certain methods
    public interface IJacobsBookstoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}
