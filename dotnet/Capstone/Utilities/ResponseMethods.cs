using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Utilities
{
    public class ResponseMethods
    {
        public static UserMessage SetLowerCase(UserMessage message)
        {
            message.Message = message.Message.ToLower();
            return message;
        }
        public static UserMessage SetContext(UserMessage message)
        {
            if (message.Context == "greet")
            {
                message.Context = "greet";
            }
            else if (message.Message == "help" || message.Message == "help me" || message.Message == "i need help")
            {
                message.Context = "help";
            }
            else if (message.Message.Contains("quote") || message.Message.Contains("motivation") || message.Message.Contains("motivate"))
            {
                message.Context = "quote";
            }
            else if (message.Message.Contains("curriculum"))
            {
                message.Context = "curriculum1";
            }
            else if (message.Context == "curriculum1")
            {
                message.Context = "curriculum2";
            }
            else if (message.Message.Contains("pathway"))
            {
                message.Context = "pathway1";
            }
            else if (message.Context == "pathway1")
            {
                message.Context = "pathway2";
            }
            else
            {
                message.Context = "error";
            }
            return message;
        }
        public static string ReturnGreeting(UserMessage message)
        {
            message.Message = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(message.Message.ToLower());
            message.Context = "";

            return $"<p>Hello {message.Message}!</br>" +
                $"I’m TE-bot and I’m here to help you with your Tech Elevator needs. </br>" +
                $"What can I help you with today:  </p>" +
                $"<li>Curriculum</li> " +
                $"<li>Pathway</li>" +
                $"<li>Motivation</li>" +
                $"<li>Positions</li>" +
                $"<p>At any point you can type \"help\" for additional assistance.</p>";

        }

        public static string ReturnHelp(UserMessage message)
        {
            message.Context = "";
            return $"<p>Ok, Here are some ways you can phrase your questions:" +
                $" <li>I need help with X</li>  " +
                $"<li>Where can I learn about X</li>" +
                $"<li>I don’t understand X</li> " +
                $"<li>What is X</li> </br>" +
                $"or you can try using words or phrases.</p> ";
        }

        public static string ReturnCategories()
        {
            return $"<p>Ok! What else can I help you with?</p>" +
                             $"<li>Curriculum</li> " +
                             $"<li>Pathway</li>" +
                             $"<li>Motivation</li>" +
                             $"<li>Positions</li>";
        }

        public static UserMessage StartCurriculumHelp(UserMessage message)
        {
            UserMessage returnMessage = new UserMessage();
            returnMessage.Message = $"<p>What questions do you have related to curriculum?</p>";
            returnMessage.Context = message.Context;
            return returnMessage;
        }

        public static string StopCurriculumHelp(UserMessage message)
        {
            if (message.Message.Contains("done"))
            {
                message.Context = "";
            }
            else
            {
                message.Context = "curriculum1";
            }
            return message.Context;
        }

        public static UserMessage StartPathwayHelp(UserMessage message)
        {
            UserMessage returnMessage = new UserMessage();
            returnMessage.Message = $"<p>What questions do you have related to pathway?</p>";
            returnMessage.Context = message.Context;
            return returnMessage;
        }

        public static string StopPathwayHelp(UserMessage message)
        {
            if (message.Message.Contains("done"))
            {
                message.Context = "";
            }
            else
            {
                message.Context = "pathway1";
            }
            return message.Context;
        }

        public static string ErrorMessage(UserMessage message)
        {
            return $"I'm sorry I don't understand.</br>Please try again.";
        }

    }
}
