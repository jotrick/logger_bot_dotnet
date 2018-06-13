using LoggerBot.Storage.State;
using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerBot.Utilities.Interfaces
{
    interface ILoggerBotContext : ITurnContext
    {
        IList<LogCategoryState> LogCategories { get; }
    }
}
