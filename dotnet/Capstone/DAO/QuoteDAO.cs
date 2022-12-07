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

        private string sqlGetQuote = "SELECT TOP 1 FROM quotes ORDER BY newid();";

        public QuoteDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public Quote GetQuote()
        {
            Quote quote = new Quote();
            try
            {
                using (SqlConnection conn= new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetQuote, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        quote = ReaderToQuote(reader);

                    }

                }
                
            }
            catch (Exception ex)
            {
                quote = new Quote();
            }
            return quote;
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
