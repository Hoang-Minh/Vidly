using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : BaseApiController
    {
        // GET api/Customers
        public IEnumerable<Customer> GetCustomers()
        {
            return MyDbContext.Customers.ToList();
        }

        // GET api/Customers/id
        public Customer GetCustomer(int id)
        {
            var customer = MyDbContext.Customers.Single(x => x.Id == id);
            return customer == null ? throw new HttpResponseException(HttpStatusCode.NotFound) : customer;
        }

        // POST api/Customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if(!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);
            MyDbContext.Customers.Add(customer);
            MyDbContext.SaveChanges();

            return customer;
        }

        // PUT api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = MyDbContext.Customers.SingleOrDefault(x => x.Id == id);

            if(customerInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            MyDbContext.Customers.AddOrUpdate(customer);
            MyDbContext.SaveChanges();
        }

        // DELETE api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = MyDbContext.Customers.SingleOrDefault(x => x.Id == id);
            if(customerInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            MyDbContext.Customers.Remove(customerInDb);
            MyDbContext.SaveChanges();
        }
    }
}
