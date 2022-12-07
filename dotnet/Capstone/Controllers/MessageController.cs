using Capstone.DAO.Interfaces;
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
        private IQuoteDAO quoteDAO;

        public MessageController(IQuoteDAO quoteDAO)
        {
            this.quoteDAO = quoteDAO;
        }

        [HttpPost()]
        public ActionResult<string> RetrieveMessage(UserMessage message)
        {


            return message.Message; //"Hello World";
        }
    }
}
