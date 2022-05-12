using Lab4_MVC.Models;
using Lab4_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4_MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerBookRepository _customerBookRepository;
        private readonly IBookRepository _bookRepository;

        public CustomerController(ICustomerRepository customerRepo, ICustomerBookRepository customerBookRepository, IBookRepository bookRepository)
        {
            _customerRepository = customerRepo;
            _customerBookRepository = customerBookRepository;
            _bookRepository = bookRepository;
        }


        public IActionResult List()
        {
            return View(_customerRepository.GetAllCustomers);
        }

        [Route("Customer/{id:int}")]
        public IActionResult Details(int id)
        {
            var viewmodel = new CustomerBookViewModel();
            viewmodel.Customers = _customerRepository.GetAllCustomers;
            viewmodel.CustomerBooks = _customerBookRepository.GetCustomerBooks;
            viewmodel.Books = _bookRepository.GetAllBooks;
            viewmodel.Customer = _customerRepository.GetCustomerById(id);

            if(viewmodel.Customer != null)
            {
                return View(viewmodel);
            }

            return NotFound();
        }

        public IActionResult Edit(int id)
        {
            var cust = _customerRepository.GetCustomerById(id);

            if(cust != null)
            {
                return View(cust);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit_(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerRepository.EditCustomer(customer);
                return RedirectToAction("List");
            }
            return View(customer);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create_(Customer customer)
        {
            _customerRepository.CreateCustomer(customer);

            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            var cust = _customerRepository.GetCustomerById(id);

            if(cust != null)
            {
                return View(cust);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Delete_(Customer customer)
        {
            _customerRepository.DeleteCustomer(customer);

            return RedirectToAction("List");
        }
    }
}
