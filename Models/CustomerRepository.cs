using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4_MVC.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BookDbContext _bookDbContext;

        public CustomerRepository(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public IEnumerable<Customer> GetAllCustomers
        {
            get
            {
                return _bookDbContext.Customers;
            }
        }

        public Customer CreateCustomer(Customer newCustomer)
        {
            _bookDbContext.Add(newCustomer);
            _bookDbContext.SaveChanges();

            return newCustomer;
        }

        public Customer DeleteCustomer(Customer customerToDelete)
        {
            _bookDbContext.Remove(customerToDelete);
            _bookDbContext.SaveChanges();

            return customerToDelete;
        }

        public Customer EditCustomer(Customer customerToEdit)
        {
            _bookDbContext.Entry(customerToEdit).State = EntityState.Modified;
            _bookDbContext.SaveChanges();

            return (customerToEdit);
        }

        public Customer GetCustomerById(int customerId)
        {
            return _bookDbContext.Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }
    }
}
