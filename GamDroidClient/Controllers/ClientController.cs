using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GamDroidClient.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        // GET: api/<controller>
        [HttpGet,Authorize]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
