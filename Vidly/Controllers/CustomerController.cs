using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : BaseController
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customers = MyDbContext.Customers.Include(x => x.MembershipType).ToList();
            var customerViewModel = new CustomerViewModel {Customers = customers};

            return View(customerViewModel);
        }

        public ActionResult Details(int id)
        {
            var customer = MyDbContext.Customers.Include(x => x.MembershipType).SingleOrDefault(y => y.Id == id);
            

            if (customer == null) return HttpNotFound();
            var customerViewModel = new CustomerViewModel { Customer = customer };

            return View(customerViewModel);
        }

        public ActionResult New()
        {
            var membershipTypes = MyDbContext.MembershipTypes.ToList();
            var newCustomerViewModel = new CustomerFormViewModel{MembershipTypes = membershipTypes};


            return View("CustomerForm", newCustomerViewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            MyDbContext.Customers.Add(customer);
            MyDbContext.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = MyDbContext.Customers.Find(id);
            if (customer == null) return HttpNotFound("Customer not found");

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = MyDbContext.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}