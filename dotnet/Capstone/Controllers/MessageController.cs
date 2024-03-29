﻿using Capstone.DAO.Interfaces;
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
        private ICurriculumDAO curriculumDAO;
        private IPathwayDAO pathwayDAO;
        private IJobDAO jobDAO;


        public MessageController(IQuoteDAO quoteDAO, ICurriculumDAO curriculumDAO, IPathwayDAO pathwayDAO, IJobDAO jobDAO)
        {
            this.quoteDAO = quoteDAO;
            this.curriculumDAO = curriculumDAO;
            this.pathwayDAO = pathwayDAO;
            this.jobDAO = jobDAO;
        }

        [HttpPost()]
        public ActionResult<UserMessage> RetrieveMessage(UserMessage message)
        {
            message = ResponseMethods.SetLowerCase(message);
            message = ResponseMethods.SetContext(message);

            UserMessage returnMessage = new UserMessage();

            switch (message.Context)
            {
                case "greet":
                    returnMessage.Message = ResponseMethods.ReturnGreeting(message);
                    break;
                case "help":
                    returnMessage.Message = ResponseMethods.ReturnHelp(message) + ResponseMethods.ReturnCategories();  
                    break;
                case "quote":
                    Quote quote = quoteDAO.GetQuote();
                    returnMessage.Message = $"{quote.Message} - {quote.Author}<br>" +
                        ResponseMethods.ReturnCategories();
                    break;
                case "curriculum1":
                    returnMessage = ResponseMethods.StartCurriculumHelp(message);
                    break;
                case "curriculum2":
                    BotMessage curriculum = curriculumDAO.GetCurriculumResponse(message);
                    if (message.Message.Contains("done"))
                    {
                        returnMessage.Message = ResponseMethods.ReturnCategories();
                    }
                    else if (curriculum.Response == null)
                    {
                        returnMessage.Message = ResponseMethods.ErrorMessage(message);
                    }
                    else
                    {
                        returnMessage.Message = $"{curriculum.Response} " +
                            $"<p>What else would you like to know about curriculum? " +
                            $"Tell me \"done\" at any point to stop learning about curriculum.</p>";
                    }
                    returnMessage.Context = ResponseMethods.StopCurriculumHelp(message);
                    break;
                case "pathway1":
                    returnMessage = ResponseMethods.StartPathwayHelp(message);
                    break;
                case "pathway2":
                    BotMessage pathway = pathwayDAO.GetPathwayResponse(message);
                    if (message.Message.Contains("done"))
                    {
                        returnMessage.Message = ResponseMethods.ReturnCategories();
                    }
                    else if (pathway.Response == null)
                    {
                        returnMessage.Message = ResponseMethods.ErrorMessage(message);
                    }
                    else
                    {
                        returnMessage.Message = $"{pathway.Response} " +
                            $"<p>What else would you like to know about pathway? " +
                            $"Tell me \"done\" at any point to stop learning about pathway.</p>";
                    }
                    returnMessage.Context = ResponseMethods.StopPathwayHelp(message);
                    break;
                case "positions1":
                        returnMessage = ResponseMethods.StartJobSearch(message);
                    break;
                case "positionsLocation":
                    if (message.Message.Contains("done"))
                    {
                        returnMessage.Context = ResponseMethods.StopJobSearch(message);
                        returnMessage.Message = ResponseMethods.ReturnCategories();
                    }
                    else
                    {
                        returnMessage = ResponseMethods.AskForLocation(message);
                    }
                    break;
                case "getJobsLocation":
                    if (message.Message.Contains("done"))
                    {
                        returnMessage.Context = ResponseMethods.StopJobSearch(message);
                        returnMessage.Message = ResponseMethods.ReturnCategories();
                    }
                    else
                    {
                        List<JobPosition> jobs = jobDAO.GetJobPostingsByLocation(message);
                        returnMessage = ResponseMethods.ReturnJobs(jobs);
                        returnMessage.Message += ResponseMethods.ReturnCategories();
                    }
                    break;
                case "positionsTitle":
                    if (message.Message.Contains("done"))
                    {
                        returnMessage.Context = ResponseMethods.StopJobSearch(message);
                        returnMessage.Message = ResponseMethods.ReturnCategories();
                    }
                    else
                    {
                        returnMessage = ResponseMethods.AskForJobTitle(message);
                    }
                    break;
                case "getJobsTitle":
                    if (message.Message.Contains("done"))
                    {
                        returnMessage.Context = ResponseMethods.StopJobSearch(message);
                        returnMessage.Message = ResponseMethods.ReturnCategories();
                    }
                    else
                    {
                        List<JobPosition> jobs = jobDAO.GetJobPostingsByTitle(message);
                        returnMessage = ResponseMethods.ReturnJobs(jobs);
                        returnMessage.Message += ResponseMethods.ReturnCategories();
                    }
                    break;
                case "error":
                    returnMessage.Message = ResponseMethods.ErrorMessage(message);
                    break;
            }
            return returnMessage;
        }
    }
}
