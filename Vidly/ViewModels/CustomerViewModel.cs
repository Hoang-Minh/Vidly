using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public IList<Customer> Customers { get; set; }
    }
}