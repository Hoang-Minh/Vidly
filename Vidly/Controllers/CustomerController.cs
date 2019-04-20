using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private readonly MyDbContext _context;

        public CustomerController()
        {
            _context = new MyDbContext();
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(x => x.MembershipType).ToList();
            var customerViewModel = new CustomerViewModel {Customers = customers};

            return View(customerViewModel);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null) return HttpNotFound();
            var customerViewModel = new CustomerViewModel { Customer = customer };

            return View(customerViewModel);
        }
    }
}