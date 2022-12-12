using Capstone.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class JobDAO : IJobDAO
    {
        private string connectionString;

        private string sqlGetJobByTitle = "SELECT position_id, job_title, company_name, application_link FROM " +
            "open_positions WHERE @job_title like '%' + job_title + '%'";

        private string sqlGetJobByLocation = "SELECT Top 3 * FROM open_positions Where city_state like '@city_state%' " +
            "OR city_state like '%@city_state' OR @city_state LIKE '%' + city_state + '%' ORDER BY newid();";

        public JobDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public JobPosition GetJobPostingByTitle(UserMessage message)
        {
            JobPosition response = new JobPosition();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetJobByTitle, conn);
                    cmd.Parameters.AddWithValue("@job_title", message.Message);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        response = ReaderToJobPosting(reader);

                    }

                }


            }
            catch (Exception ex)
            {
                response = new JobPosition();
            }
            return response;

        }

        public JobPosition GetJobPostingByLocation(UserMessage message)
        {
            JobPosition response = new JobPosition();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetJobByLocation, conn);
                    cmd.Parameters.AddWithValue("@city_state", message.Message);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        response = ReaderToJobPosting(reader);

                    }

                }


            }
            catch (Exception ex)
            {
                response = new JobPosition();
            }
            return response;

        }


        private JobPosition ReaderToJobPosting(SqlDataReader reader)
        {
            JobPosition job = new JobPosition();
            job.Id = Convert.ToInt32(reader["position_id"]);
            job.Title = Convert.ToString(reader["job_title"]);
            job.Company = Convert.ToString(reader["company_name"]);
            job.Link = Convert.ToString(reader["application_link"]);
            job.Location = Convert.ToString(reader["city_state"]);

            return job;

        }

    }
}
