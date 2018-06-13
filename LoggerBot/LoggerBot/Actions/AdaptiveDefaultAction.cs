using LoggerBot.Storage.State;
using LoggerBot.Utilities.Interfaces;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LoggerBot.Utilities;

namespace LoggerBot.Actions
{
    public class AdaptiveDefaultAction : ILoggerBotAction
    {
        public async Task Do(LoggerBotContext context)
        {
            await context.SendActivity("Sorry, I didn't understand.");
        }
    }
}
