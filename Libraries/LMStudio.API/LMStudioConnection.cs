using AutoGen.Core;
using AutoGen.DotnetInteractive;
using AutoGen.DotnetInteractive.Extension;
using AutoGen.OpenAI;
using AutoGen.OpenAI.Extension;
using Google.Cloud.AIPlatform.V1;
using LMStudio.API.Extensions;
using LMStudio.API.Models;
using Microsoft.DotNet.Interactive;
using OpenAI;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace LMStudio.API
{
    public static class LMStudioConnection
    {
        public static TokenShuttle FetchAiReplies(string endpoint, string aiModel, string prompt, string apiKey = "api-key-does-not-mater-for-lmstudio")
        {
            OpenAIClient openAIClient
               = new OpenAIClient(
                   new ApiKeyCredential(apiKey),
                   new OpenAIClientOptions { Endpoint = new Uri(endpoint), }
               );

            MiddlewareStreamingAgent<OpenAIChatAgent> openAIChatAgent =
                new OpenAIChatAgent(
                    name: "Software Engineer",
                    systemMessage: "You Write Code.",
                    chatClient: openAIClient.GetChatClient(aiModel)
                ).RegisterMessageConnector();



            MiddlewareAgent<MiddlewareStreamingAgent<OpenAIChatAgent>> dotnetInteractiveMiddlewareAgent =
                openAIChatAgent
                    .RegisterMiddleware(async (message, generateReplyOptions, innerAgent, cancellationToken) =>
                        {
                            IMessage lastMessage
                               = message.LastOrDefault();

                            if (lastMessage == null)
                                return await innerAgent.GenerateReplyAsync(message, generateReplyOptions, cancellationToken);

                            if (lastMessage.GetContent() is null)
                                return await innerAgent.GenerateReplyAsync(message, generateReplyOptions, cancellationToken);

                            string[] codeBlocks
                                = lastMessage
                                    .ToMessageCodeBlocks(@"```csharp", @"```")
                                        .ToArray();

                            if (codeBlocks.Length > 0)
                            {
                                CompositeKernel compositeKernel
                                   = DotnetInteractiveKernelBuilder
                                       .CreateDefaultInProcessKernelBuilder() // add C# and F# kernels
                                           .Build();

                                Collection<string> collection = new Collection<string>();

                                foreach (string codeBlock in codeBlocks)
                                {
                                    string result
                                        = await compositeKernel
                                            .RunSubmitCodeCommandAsync(
                                                codeBlock,
                                                "csharp",
                                                cancellationToken
                                            );

                                    collection.Add(result);
                                }


                                string results
                                    = string.Join('\n', collection);

                                return new TextMessage(Role.Assistant, results, from: openAIChatAgent.Name);
                            }

                            // no code block found, invoke next agent
                            return await innerAgent.GenerateReplyAsync(message, generateReplyOptions, cancellationToken);

                        }
                    );


            IEnumerable<IMessage> messages
                = openAIChatAgent
                    .GenerateStreamingReplyAsync(
                        new[] {
                            new TextMessage(Role.User, prompt)
                        }
                    ).ToBlockingEnumerable();

            return new TokenShuttle(
                ExtractContentFromMessages(messages)
            );
        }

        private static IEnumerable<string> ExtractContentFromMessages(IEnumerable<IMessage> messages)
        {
            if (messages is null)
            {
                yield return "[MESSAGE STREAM NULL]";
                yield break;
            }

            using (IEnumerator<IMessage> messageEnumerator = messages.GetEnumerator())
            {
                while (true)
                {
                    string content
                        = ExtractContentFromMessage(messageEnumerator);

                    if (content is null)
                        yield break;

                    yield return content;
                }
            }
        }


        private static string ExtractContentFromMessage(IEnumerator<IMessage> messageEnumerator)
        {
            try
            {
                if (!messageEnumerator.MoveNext())
                    return null;

                IMessage message
                    = messageEnumerator.Current;

                if (message is null)
                    return "[NULL '.Current' MESSAGE]";

                string messageContent;
                try
                {
                    messageContent = message.GetContent();
                }
                catch (Exception exception)
                {
                    return $"[MESSAGE '.GetContent()' EXCEPTION: {exception.Message}]";
                }

                if (messageContent is null)
                    return "[NULL MESSAGE CONTENT]";
                else
                    return messageContent.ToString();

            }
            catch (Exception exception)
            {
                return $"[ 'LM Studios Context Window is probably to small. Increase The Context Window Size!' MESSAGE EXCEPTION: {exception.Message}]";
            }
        }
    }
}