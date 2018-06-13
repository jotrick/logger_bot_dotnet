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
    public class HelloAction : ILoggerBotAction
    {
        public static Regex Trigger { get; } = new Regex("hello|" + "hi".CreateGenericRegexPattern(), RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public async Task Do(LoggerBotContext context)
        {
            ////await context.SendActivity("Hello! (From HelloAction)");

            var response = "";

            foreach (var category in context.LogCategories)
            {
                response += category.Name + "\n";
            }

            await context.SendActivity(response);
        }
    }
}
