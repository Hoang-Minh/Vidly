using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Vidly.App_Start;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : BaseApiController
    {
        // GET api/Customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return MyDbContext.Customers.ProjectTo<CustomerDto>().ToList();
        }

        // GET api/Customers/id
        public CustomerDto GetCustomer(int id)
        {
            var customer = MyDbContext.Customers.Single(x => x.Id == id);
            var mapperProfile = new MappingProfile();
            var dest = mapperProfile.Mapper.Map<Customer, CustomerDto>(customer);

            return dest ?? throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        // POST api/Customers
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if(!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);

            var mapperProfile = new MappingProfile();
            var customer = mapperProfile.Mapper.Map<CustomerDto, Customer>(customerDto);
            MyDbContext.Customers.Add(customer);
            MyDbContext.SaveChanges();

            customerDto.Id = customer.Id;
            return customerDto;
        }

        // PUT api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = MyDbContext.Customers.SingleOrDefault(x => x.Id == id);

            if(customerInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            var mapperProfile = new MappingProfile();
            mapperProfile.Mapper.Map(customerDto, customerInDb);

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
