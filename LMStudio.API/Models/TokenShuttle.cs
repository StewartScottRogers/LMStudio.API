﻿using AutoGen.Core;
using AutoGen.OpenAI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LMStudio.API.Models
{
    public class TokenShuttle : IEnumerable<string>
    {
        private IEnumerable<string> Tokens;

        private StringBuilder StringBuilder = new StringBuilder();

        public TokenShuttle(
            IEnumerable<string> tokens
        )
        {
            Tokens = tokens;
        }
        public IEnumerator<string> GetEnumerator()
        {
            foreach (var token in Tokens)
            {
                StringBuilder.Append(token.ToString());
                yield return token;
            }
        }

        public IEnumerable<string> ToCodeBlocks(string codeBlockPrefix = @"```csharp", string codeBlockSuffix = @"```")
        {
            string text = ToString();
            if (string.IsNullOrWhiteSpace(text))
                yield break;

            string pattern
                = (codeBlockPrefix + "([\\s\\S]*?)" + codeBlockSuffix)
                    .Trim();

            IEnumerable<string> matchCollection
                = Regex
                    .Matches(text, pattern)
                        .Select(
                            match =>
                                match.Groups[0].Value
                                    .TrimStart(codeBlockPrefix.ToCharArray())
                                        .TrimEnd(codeBlockSuffix.ToCharArray())
                        );

            foreach (string match in matchCollection)
                yield return match.Trim();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var token in Tokens)
            {
                StringBuilder.Append(token.ToString());
                yield return token;
            }
        }

        override public string ToString()
        {
            return StringBuilder.ToString();
        }
    }
}
