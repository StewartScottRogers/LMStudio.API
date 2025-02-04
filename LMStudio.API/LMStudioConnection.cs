using AutoGen.Core;
using AutoGen.DotnetInteractive;
using AutoGen.DotnetInteractive.Extension;
using AutoGen.OpenAI;
using AutoGen.OpenAI.Extension;
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
        public static TokenShuttle FetchAiReplies(string endpoint, string aiModel, string message, string apiKey = "api-key-does-not-mater-for-lmstudio")
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

            IEnumerable<string> tokens =
                openAIChatAgent
                    .GenerateStreamingReplyAsync(
                        new[] {
                            new TextMessage(Role.User, message)
                        }
                    ).ToBlockingEnumerable()
                        .Select(token => token.GetContent()
                    );

            return new TokenShuttle(
                tokens
            );
        }
    }
}