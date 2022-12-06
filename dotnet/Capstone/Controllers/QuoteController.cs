using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Capstone.DAO.Interfaces;
using Capstone.DAO;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class QuoteController : Controller
    {
        private IQuoteDAO quoteDAO;

        public QuoteController(IQuoteDAO quoteDAO)
        {
            this.quoteDAO = quoteDAO;
        }
        [HttpGet]
        public ActionResult<List<Quote>> GetQuotes()
        {
            return Ok(quoteDAO.GetQuotes());
        }
    }
}
