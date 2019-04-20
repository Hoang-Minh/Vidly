using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        List<Customer> customers = new List<Customer>
        {
            new Customer{Id = 1, Name = "John Smith"},
            new Customer{Id = 2, Name = "Mary William"}
        };

        // GET: Customer
        public ActionResult Index()
        {
            var customerViewModel = new CustomerViewModel {Customers = customers};

            return View(customerViewModel);
        }

        public ActionResult Details(int id)
        {
            var customer = customers.Find(x => x.Id == id);

            if (customer == null) return HttpNotFound();
            var customerViewModel = new CustomerViewModel{Customer = customer};

            return View(customerViewModel);
        }
    }
}