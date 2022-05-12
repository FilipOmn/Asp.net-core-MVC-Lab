using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4_MVC.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers { get; }

        Customer GetCustomerById(int customerId);

        Customer CreateCustomer(Customer newCustomer);

        Customer EditCustomer(Customer customerToEdit);

        Customer DeleteCustomer(Customer customerToDelete);
    }
}
