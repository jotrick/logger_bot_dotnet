using LoggerBot.Actions;
using LoggerBot.Utilities.Interfaces;
using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LoggerBot.Handlers.Message
{
    public class MessageHandler: IMessageHandler
    {
        private IDictionary<Regex, ILoggerBotAction> TextTriggers { get; set; }

        private IDictionary<string, ILoggerBotAction> AdaptiveTriggers { get; set; }

        public MessageHandler()
        {
            this.AdaptiveTriggers = this.SetupAdaptiveTriggers();
            this.TextTriggers = this.SetupTextTriggers();
        }

        public async Task Handle(LoggerBotContext context)
        {
            // If Text is null, then the payload is from an adaptive card submission
            if (context.Activity.Text == null)
            {
                await this.HandleAdaptiveMessage(context);
            }
            else
            {
                await this.HandleTextMessage(context);
            }
        }

        private async Task HandleAdaptiveMessage(LoggerBotContext context)
        {
            dynamic value = context.Activity.Value;

            var adaptiveTrigger = value.AdaptiveTrigger;

            // Get the first trigger's Action whose trigger matches the incoming flag
            var triggeredAction = this.AdaptiveTriggers.FirstOrDefault(
                trigger => trigger == adaptiveTrigger).Value;

            // Answer with the default action if no trigger match was found
            triggeredAction = triggeredAction ?? new AdaptiveDefaultAction();

            await triggeredAction.Do(context);
        }

        private async Task HandleTextMessage(LoggerBotContext context)
        {
            var msgText = context.Activity.Text;

            // Get the first trigger's Action whose Regex matches the incoming text
            var triggeredAction = this.TextTriggers.FirstOrDefault(
                trigger => trigger.Key.Match(msgText).Success).Value;

            // Answer with the default action if no trigger match was found
            triggeredAction = triggeredAction ?? new DefaultAction();

            await triggeredAction.Do(context);
        }

        private IDictionary<string, ILoggerBotAction> SetupAdaptiveTriggers()
        {
            var triggers = new Dictionary<string, ILoggerBotAction>();

            triggers.Add("test", new HelloAction());

            return triggers;
        }

        private IDictionary<Regex, ILoggerBotAction> SetupTextTriggers()
        {
            var triggers = new Dictionary<Regex, ILoggerBotAction>();

            triggers.Add(HelloAction.Trigger, new HelloAction());
            triggers.Add(LogPromptAction.Trigger, new LogPromptAction());
            triggers.Add(AdaptiveCardAction.Trigger, new AdaptiveCardAction());

            return triggers;
        }
    }
}
