using AutoGen.Core;
using AutoGen.OpenAI;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LMStudio.API.Models
{
    public class TokenShuttle : IEnumerable<string>
    {
        private IEnumerable<string> Tokens;
        private MiddlewareAgent<MiddlewareStreamingAgent<OpenAIChatAgent>> DotnetInteractiveMiddlewareAgent;

        private StringBuilder StringBuilder = new StringBuilder();

        public TokenShuttle(
            IEnumerable<string> tokens,
            MiddlewareAgent<MiddlewareStreamingAgent<OpenAIChatAgent>> dotnetInteractiveMiddlewareAgent
        )
        {
            Tokens = tokens;
            DotnetInteractiveMiddlewareAgent = dotnetInteractiveMiddlewareAgent;
        }
        public IEnumerator<string> GetEnumerator()
        {
            foreach (var token in Tokens)
            {
                StringBuilder.Append(token.ToString());
                yield return token;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var token in Tokens)
            {
                StringBuilder.Append(token.ToString());
                yield return token;
            }
        }
        public string Compile()
        {
            string content = StringBuilder.ToString();

            IMessage message
                = DotnetInteractiveMiddlewareAgent
                    .SendAsync(new TextMessage(Role.User, content))
                        .Result;

            return message.GetContent();

        }
        override public string ToString()
        {
            return StringBuilder.ToString();
        }
    }
}
