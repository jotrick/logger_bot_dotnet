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
using AdaptiveCards;
using System.Dynamic;
using Microsoft.Bot.Schema;

namespace LoggerBot.Actions
{
    public class AdaptiveCardAction : ILoggerBotAction
    {
        public static Regex Trigger { get; } = new Regex("adaptive", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public async Task Do(LoggerBotContext context)
        {
            var response = context.Activity.CreateReply();

            var attachment = this.Card2();

            response.Attachments = new List<Attachment>() { attachment };

            await context.SendActivity(response);
        }

        private Attachment Card1()
        {
            var card = new AdaptiveCard();

            // Specify speech for the card.
            card.Speak = "<s>Your  meeting about \"Adaptive Card design session\"<break strength='weak'/> is starting at 12:30pm</s><s>Do you want to snooze <break strength='weak'/> or do you want to send a late notification to the attendees?</s>";

            // Add text to the card.
            card.Body.Add(new AdaptiveTextBlock()
            {
                Text = "Adaptive Card design session",
                Size = AdaptiveTextSize.Large,
                Weight = AdaptiveTextWeight.Bolder
            });

            // Add text to the card.
            card.Body.Add(new AdaptiveTextBlock()
            {
                Text = "Conf Room 112/3377 (10)"
            });

            // Add text to the card.
            card.Body.Add(new AdaptiveTextBlock()
            {
                Text = "12:30 PM - 1:30 PM"
            });

            // Add list of choices to the card.
            card.Body.Add(new AdaptiveChoiceSetInput()
            {
                Id = "snooze",
                Style = AdaptiveChoiceInputStyle.Compact,
                ////Value = "5", // used for default?
                Choices = new List<AdaptiveChoice>()
                {
                    new AdaptiveChoice() { Title = "5 minutes", Value = "5" },
                    new AdaptiveChoice() { Title = "15 minutes", Value = "15" },
                    new AdaptiveChoice() { Title = "30 minutes", Value = "30" }
                }
            });

            dynamic buttonData = new ExpandoObject();
            buttonData.HelloText = "hello";

            // Add buttons to the card.
            card.Actions.Add(new AdaptiveSubmitAction()
            {
                Title = "Submit",
                ////DataJson = "{\"x\":\"hello\"}"
                Data = buttonData
            });

            card.Actions.Add(new AdaptiveOpenUrlAction()
            {
                Url = new Uri("http://foo.com"),
                Title = "Dismiss"
            });

            // Create the attachment.
            return new Attachment()
            {
                ContentType = AdaptiveCard.ContentType,
                Content = card
            };
        }

        private Attachment Card2()
        {
            var card = new AdaptiveCard();

            // Specify speech for the card.
            card.Speak = "<s>Your  meeting about \"Adaptive Card design session\"<break strength='weak'/> is starting at 12:30pm</s><s>Do you want to snooze <break strength='weak'/> or do you want to send a late notification to the attendees?</s>";

            card.BackgroundImage = new Uri("http://messagecardplayground.azurewebsites.net/assets/Mostly%20Cloudy-Background-Dark.jpg");

            // Add text to the card.
            card.Body.Add(new AdaptiveTextBlock()
            {
                Text = "Adaptive Card design session",
                Size = AdaptiveTextSize.Large,
                Weight = AdaptiveTextWeight.Bolder
            });

            // Add text to the card.
            card.Body.Add(new AdaptiveTextBlock()
            {
                Text = "Conf Room 112/3377 (10)",
                HorizontalAlignment = AdaptiveHorizontalAlignment.Center
            });

            // Add text to the card.
            card.Body.Add(new AdaptiveTextBlock()
            {
                Text = "12:30 PM - 1:30 PM",
                HorizontalAlignment = AdaptiveHorizontalAlignment.Right
            });

            card.Body.Add(new AdaptiveTextBlock()
            {
                Text = "12:30 PM - 1:30 PM",
                Separator = true,
                Spacing = AdaptiveSpacing.Medium
            });

            // Add list of choices to the card.
            card.Body.Add(new AdaptiveChoiceSetInput()
            {
                Id = "snooze",
                Style = AdaptiveChoiceInputStyle.Compact,
                Value = "15",
                Choices = new List<AdaptiveChoice>()
                {
                    new AdaptiveChoice() { Title = "5 minutes", Value = "5" },
                    new AdaptiveChoice() { Title = "15 minutes", Value = "15" },
                    new AdaptiveChoice() { Title = "30 minutes", Value = "30" }
                }
            });

            dynamic buttonData = new ExpandoObject();
            buttonData.HelloText = "hello";

            // Add buttons to the card.
            card.Actions.Add(new AdaptiveSubmitAction()
            {
                Title = "Submit - Hello",
                ////DataJson = "{\"x\":\"hello\"}"
                Data = buttonData
            });

            card.Actions.Add(new AdaptiveOpenUrlAction()
            {
                Url = new Uri("http://foo.com"),
                Title = "Dismiss"
            });

            var cardToShow = new AdaptiveCard();
            cardToShow.Body.Add(new AdaptiveTextBlock()
            {
                Text = "NEAT!",
                HorizontalAlignment = AdaptiveHorizontalAlignment.Center
            });

            cardToShow.Actions.Add(new AdaptiveSubmitAction()
            {
                Title = "Submit - Hello",
                ////DataJson = "{\"x\":\"hello\"}"
                Data = buttonData
            });

            card.Actions.Add(new AdaptiveShowCardAction()
            {
                Title = "Show Card",
                Card = cardToShow
            });

            // Create the attachment.
            return new Attachment()
            {
                ContentType = AdaptiveCard.ContentType,
                Content = card
            };
        }
    }
}
