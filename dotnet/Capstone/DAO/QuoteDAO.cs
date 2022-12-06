using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO.Interfaces;
using Capstone.Models;

namespace Capstone.DAO
{
    public class QuoteDAO: IQuoteDAO
    {
        private string connectionString;

        private string sqlGetQuotes = "SELECT * FROM quotes;";

        public QuoteDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<Quote> GetQuotes()
        {
            List<Quote> quotes = new List<Quote>();
            try
            {
                using (SqlConnection conn= new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetQuotes, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Quote quote = ReaderToQuote(reader);
                        quotes.Add(quote);

                    }

                }
                
            }
            catch (Exception ex)
            {
                quotes = new List<Quote>();
            }
            return quotes;
        }
        private Quote ReaderToQuote(SqlDataReader reader)
        {
            Quote quote = new Quote();
            quote.Id = Convert.ToInt32(reader["quote_id"]);
            quote.Message = Convert.ToString(reader["motivational_quote"]);
            quote.Author = Convert.ToString(reader["author"]);

            return quote;

        }
    }
}
