using LoggerBot.Storage.State;
using LoggerBot.Utilities.Interfaces;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Adapters;
using Microsoft.Bot.Builder.Core.Extensions;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerBot.Actions
{
    public class ProactiveMessageAction : ILoggerBotAction
    {
        public async Task Do(LoggerBotContext context)
        {
            var userId = context.Activity.From.Id;
            var serviceUrl = context.Activity.ServiceUrl;
            var botId = "28:" + LoggerBot.MicrosoftAppCredentials.MicrosoftAppId;
            var botName = "PlaceholderName";

            var connectorClient = new ConnectorClient(
                baseUri: new Uri(serviceUrl),
                microsoftAppId: LoggerBot.MicrosoftAppCredentials.MicrosoftAppId,
                microsoftAppPassword: LoggerBot.MicrosoftAppCredentials.MicrosoftAppPassword);

            dynamic channelDataNew = new ExpandoObject();
            dynamic tenantObj = new ExpandoObject();
            tenantObj.id = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            channelDataNew.tenant = tenantObj;

            var parameters = new ConversationParameters
            {
                Bot = new ChannelAccount(botId, botName),
                Members = new ChannelAccount[] { new ChannelAccount(userId) },
                ChannelData = channelDataNew,
            };

            ConversationResourceResponse conversationResource = await connectorClient.Conversations.CreateConversationAsync(parameters);

            if (conversationResource != null)
            {
                var createdActivity = new Activity
                {
                    From = new ChannelAccount(userId),
                    Recipient = new ChannelAccount(botId, botName),
                    Conversation = new ConversationAccount(
                        id: conversationResource.Id,
                        isGroup: false,
                        name: "PlaceholderName"),
                    ChannelId = "msteams",
                    ServiceUrl = serviceUrl,
                };

                ConversationReference conversationReference = TurnContext.GetConversationReference(createdActivity);
                await context.Adapter.ContinueConversation(
                    LoggerBot.MicrosoftAppCredentials.MicrosoftAppId,
                    conversationReference,
                    async (ctx) =>
                    {
                        await ctx.SendActivity("Proactive Message");
                    });
            }
        }
    }
}
