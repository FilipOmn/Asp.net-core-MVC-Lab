using Lab4_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4_MVC.ViewModels
{
    public class CustomerBookViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<CustomerBook> CustomerBooks { get; set; }
    }
}
