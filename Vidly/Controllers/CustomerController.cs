using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
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
            return View();
        }
    }
}