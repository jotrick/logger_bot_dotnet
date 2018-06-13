using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerBot.Utilities.Interfaces
{
    public interface ILoggerBotAction
    {
        Task Do(LoggerBotContext context);
    }
}
