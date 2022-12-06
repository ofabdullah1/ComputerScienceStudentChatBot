using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO.Interfaces
{
    public interface IQuoteDAO
    {
        List<Quote> GetQuotes();
       
    }
}
