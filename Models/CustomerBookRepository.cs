using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4_MVC.Models
{
    public class CustomerBookRepository : ICustomerBookRepository
    {
        private readonly BookDbContext _bookDbContext;

        public CustomerBookRepository(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public IEnumerable<CustomerBook> GetCustomerBooks 
        {
            get
            {
                return _bookDbContext.CustomerBooks;
            }
        }
    }
}
