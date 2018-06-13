using System;
using System.Dynamic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LoggerBot.Actions;
using LoggerBot.Utilities.Interfaces;
using Microsoft.Bot;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Core.Extensions;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Bot.Schema;

namespace LoggerBot
{
    public class LoggerBot : IBot
    {
        public static MicrosoftAppCredentials MicrosoftAppCredentials { get; set; }

        private readonly IMessageHandler _messageHandler;

        public LoggerBot(IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
        }

        /// <summary>
        /// Every Conversation turn for our LoggerBot will call this method.
        /// </summary>
        /// <param name="context">Turn scoped context containing all the data needed
        /// for processing this conversation turn. </param>        
        public async Task OnTurn(ITurnContext inputContext)
        {
            var context = new LoggerBotContext(inputContext);

            switch (context.Activity.Type)
            {
                case ActivityTypes.Message:
                    await _messageHandler.Handle(context);
                    break;
            }

            ////context.Services.Get<IMessageHandler>();

            ////await new LogPromptAction().Do(context);

            ////var x = new Regex(@"test", RegexOptions.IgnoreCase);

            ////switch ("hi")
            ////{
            ////    case x:
            ////        await context.SendActivity("hi");
            ////        break;
            ////}
        }
    }    
}
