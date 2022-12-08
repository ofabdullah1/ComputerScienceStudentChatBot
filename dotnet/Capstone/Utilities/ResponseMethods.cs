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
            else if (message.Message == "help")
            {
                message.Context = "help";
            }
            else if (message.Message.Contains("quote") || message.Message.Contains("motivation"))
            {
                message.Context = "quote";
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
                $"<ul> <li>Curriculum</li>  </br>" +
                $"<li>Pathway</li> </br>" +
                $"<li>Motivation</li>  </br>" +
                $"<li>Positions</li>  </ul>" +
                $"<p>At any point you can type \"help\" for additional assistance.</p>";

        }

        public static string ReturnHelp(UserMessage message)
        {
            return $"<p>Ok, Here are some ways you can phrase your questions:" +
                $"<ul> <li>I need help with X</li>  " +
                $"<li>Where can I learn about X</li>" +
                $"<li>I don’t understand X</li> " +
                $"<li>What is X</li> </ul></br>" +
                $"or you can try using words or phrases.</p> ";
        }

        public static string ErroMessage (UserMessage message)
        {
            return $"I'm sorry I don't understand.</br>Please try again.";
        }

    }
}
