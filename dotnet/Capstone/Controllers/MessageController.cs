using Capstone.DAO.Interfaces;
using Capstone.Models;
using Capstone.Utilities;
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
            message = ResponseMethods.SetLowerCase(message);
            message = ResponseMethods.SetContext(message);
            
            UserMessage returnMessage = new UserMessage();

            switch(message.Context)
            {
                case "greet":
                    returnMessage.Message = ResponseMethods.ReturnGreeting(message);
                    break;
                case "help":
                    returnMessage.Message = ResponseMethods.ReturnHelp(message);
                    break;
                case "quote":
                    Quote quote = quoteDAO.GetQuote();
                    returnMessage.Message = $"{quote.Message} - {quote.Author}";
                    break;
            }
            return returnMessage.Message;
        }
    }
}
