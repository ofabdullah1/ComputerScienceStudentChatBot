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
                $"<li style=\"list-style:none\">Curriculum</li> " +
                $"<li style=\"list-style:none\">Pathway</li>" +
                $"<li style=\"list-style:none\">Motivation</li>" +
                $"<li style=\"list-style:none\">Positions</li>" +
                $"<p>At any point you can type \"help\" for additional assistance.</p>";

        }

        public static string ReturnHelp(UserMessage message)
        {
            message.Context = "";
            return $"<p>Ok, Here are some ways you can phrase your questions:" +
                $" <li style=\"list-style:none\">I need help with X</li>  " +
                $"<li style=\"list-style:none\">Where can I learn about X</li>" +
                $"<li style=\"list-style:none\">I don’t understand X</li> " +
                $"<li style=\"list-style:none\">What is X</li> </br>" +
                $"or you can try using words or phrases.</p> ";
        }

        public static UserMessage StartCurriculumHelp(UserMessage message)
        {
            UserMessage returnMessage = new UserMessage();
            returnMessage.Message = $"<p>Ok! Here are some things you can ask about:</p>" +
                $"<li style=\"list-style:none\">Bools</li> " +
                $"<li style=\"list-style:none\">Strings</li>" +
                $"<li style=\"list-style:none\">Data types</li>" +
                $"<li style=\"list-style:none\">Methods</li>" +
                $"<li style=\"list-style:none\">Void</li>" +
                $"<li style=\"list-style:none\">Casting</li>" +
                $"<li style=\"list-style:none\">Variables</li>" +
                $"<li style=\"list-style:none\">Constants</li>";
            returnMessage.Context = message.Context;
            return returnMessage;
        }

        public static string ErrorMessage(UserMessage message)
        {
            return $"I'm sorry I don't understand.</br>Please try again.";
        }

    }
}
