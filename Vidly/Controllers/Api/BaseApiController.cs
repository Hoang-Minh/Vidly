using System.Web.Http;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class BaseApiController : ApiController
    {
        public MyDbContext MyDbContext { get; }

        public BaseApiController()
        {
            MyDbContext = new MyDbContext();
        }
    }
}