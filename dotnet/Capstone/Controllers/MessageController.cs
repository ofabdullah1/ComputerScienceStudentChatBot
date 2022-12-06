using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessageController : Controller
    {
        [HttpPost()]
        public ActionResult<string> RetrieveMessage(string message)
        { 
            return Ok(message);
        }
    }
}
