using LoggerBot.Storage.State;
using LoggerBot.Utilities.Interfaces;
using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerBot
{
    public class LoggerBotContext : TurnContextWrapper, ILoggerBotContext
    {
        public LoggerBotContext(ITurnContext context) : base(context)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public IList<LogCategoryState> LogCategories
        {
            get { return this.Services.Get<IList<LogCategoryState>>(); }
        }
    }
}
