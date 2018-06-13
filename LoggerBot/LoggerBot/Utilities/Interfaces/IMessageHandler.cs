using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LoggerBot.Utilities.Interfaces
{
    public interface IMessageHandler
    {
        Task Handle(LoggerBotContext context);
    }
}
