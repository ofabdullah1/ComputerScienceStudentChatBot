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

        private string sqlGetJobByTitle = "SELECT TOP 3 * FROM open_positions WHERE job_title Like '%@job_title%' ORDER BY newid();";

        private string sqlGetJobByLocation = "SELECT TOP 3 * FROM open_positions WHERE @city_state Like '%' + city_state + '%' ORDER BY newid();";



        public JobDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<JobPosition> GetJobPostingsByTitle(UserMessage message)
        {
            List<JobPosition> jobs = new List<JobPosition>();

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
                        JobPosition job = new JobPosition();
                        job = ReaderToJobPosting(reader);
                        jobs.Add(job);

                    }

                }


            }
            catch (Exception ex)
            {
                JobPosition job = new JobPosition();
            }
            return jobs;

        }

        public List<JobPosition> GetJobPostingsByLocation(UserMessage message)
        {
            List<JobPosition> jobs = new List<JobPosition>();

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
                        JobPosition job = new JobPosition();
                        job = ReaderToJobPosting(reader);
                        jobs.Add(job);

                    }

                }


            }
            catch (Exception ex)
            {
                JobPosition job = new JobPosition();
            }
            return jobs;

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
