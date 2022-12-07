using Capstone.Models;
using System;
using System.Collections.Generic;
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
            if (message.Message == "help")
            {
                message.Context = "help";
            }
            else if (message.Message.Contains("quote") || message.Message.Contains("motivation"))
            {
                message.Context = "quote";
            }
            else
            {
                message.Context = "greet";
            }
            return message;
        }
        public static string ReturnGreeting(UserMessage message)
        {
            return $"Hello {message.Message}!\n" +
                $"I’m TE-bot and I’m here to help you with your Tech Elevator needs. \n" +
                $"What can I help you with today: \n" +
                $"\"Curriculum\", \n" +
                $"\"Pathway\", \n" +
                $"\"Motivation\", \n" +
                $"or \"Positions\"? \n" +
                $"At any point you can type \"help\" for additional assistance.";
        }

        public static string ReturnHelp(UserMessage message)
        {
            return $"Ok, Here are some ways you can phrase your questions: " +
                $"I need help with X." +
                $"Where can I learn about X?" +
                $"I don’t understand X." +
                $"What is X?" +
                $"or you can try using words or phrases.";
        }

    }
}
