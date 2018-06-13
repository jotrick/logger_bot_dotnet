using LoggerBot.Actions;
using LoggerBot.Storage.State;
using LoggerBot.Utilities.Interfaces;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerBot.Middleware
{
    public class LogCategoriesMiddleware : IMiddleware
    {
        public async Task OnTurn(ITurnContext context, MiddlewareSet.NextDelegate next)
        {
            BotAssert.ContextNotNull(context);

            var logCategoryStates = new List<LogCategoryState>();
            logCategoryStates.Add(new LogCategoryState { Name = "Working out" });
            logCategoryStates.Add(new LogCategoryState { Name = "Biking" });
            logCategoryStates.Add(new LogCategoryState { Name = "Reading" });

            context.Services.Add<IList<LogCategoryState>>(logCategoryStates);

            await next().ConfigureAwait(false);
        }
    }
}
