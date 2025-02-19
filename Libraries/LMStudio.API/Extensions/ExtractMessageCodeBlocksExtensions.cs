using AutoGen.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LMStudio.Extensions
{
    public static class ExtractMessageCodeBlocksExtensions
    {
        public static IEnumerable<string> ToMessageCodeBlocks(this IMessage message, string codeBlockPrefix, string codeBlockSuffix)
        {
            string text = message.GetContent() ?? string.Empty;
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
                yield return match;
        }
    }
}
