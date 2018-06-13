using LoggerBot.Storage.State;
using LoggerBot.Utilities.Interfaces;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using LoggerBot.Utilities;
using Microsoft.Bot.Schema;
using System.IO;
using Newtonsoft.Json;
using AdaptiveCards;
using System.Dynamic;

namespace LoggerBot.Actions
{
    public class LogPromptAction : ILoggerBotAction
    {
        public static Regex Trigger { get; } = new Regex("card", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public async Task Do(LoggerBotContext context)
        {
            var logCategories = context.GetUserState<LoggerBotUserState>().FollowedLogCategories;

            var buttons = logCategories.Select(category =>
            {
                return new CardAction()
                {
                    Type = ActionTypes.ImBack,
                    Title = category,
                    DisplayText = "Log " + category,
                    Text = "Text Log " + category, 
                    Value = "Log " + category
                };
            }).ToList();

            var response = context.Activity.CreateReply();
            
            var attachment = new ThumbnailCard()
            {
                Title = "",
                Subtitle = "",
                Text = "",
                Buttons = buttons
            }.ToAttachment();

            response.Attachments = new List<Attachment>() { attachment };

            await context.SendActivity(response);
        }
    }
}
