using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Capstone.DAO.Interfaces;
using Capstone.Models;

namespace Capstone.DAO
{
    public class CurriculumDAO : ICurriculumDAO
    {
        private string connectionString;

        private string sqlGetCurriculumResponse = "SELECT response FROM curriculum" +
            "JOIN curriculum_keywords ck ON ck.curriculum_id = curriculum.curriculum_id" +
            "JOIN keywords k ON k.keyword_id = ck.keyword_id" +
            "WHERE keyword= @keyword;";

        public CurriculumDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Curriculum GetCurriculumResponse()
        {
            Curriculum response = new Curriculum();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetCurriculumResponse, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        response = ReaderToCurriculumResponse(reader);

                    }

                }

            }
            catch (Exception ex)
            {
                response = new Curriculum();
            }
            return response;
        }
        private Curriculum ReaderToCurriculumResponse(SqlDataReader reader)
        {
            Curriculum curriculumResponse = new Curriculum();
            curriculumResponse.Id = Convert.ToInt32(reader["curriculum_id"]);
            curriculumResponse.Response = Convert.ToString(reader["response"]);
        
            return curriculumResponse;

        }

    }
}
