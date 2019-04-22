using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class BaseController : Controller
    {
        public MyDbContext MyDbContext { get; }

        public BaseController()
        {
            MyDbContext = new MyDbContext();
        }
    }
}