using AiPrompts;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LMStudio
{
    public static class PromptCompositionBuilder
    {
        public static string GetDirectivesPrompt(string endsWith)
        {
            IEnumerable<string> embeddedPrompts
                = EmbeddedPrompts.GetAllPaths(endsWith);

            StringBuilder stringBuilder = new StringBuilder();
            foreach (string embeddedPrompt in embeddedPrompts)
            {
                Debug.WriteLine(embeddedPrompt);
                string prompt = EmbeddedPrompts.GetPrompt(embeddedPrompt);
                stringBuilder.AppendLine(prompt);
            }

            return stringBuilder.ToString();
        }

        public static IEnumerable<(string ProjectPromptName, string ProjectPromptContent)> SelectProjectPromptTuples(string endsWith)
        {
            IEnumerable<string> embeddedPrompts
                = EmbeddedPrompts.GetAllPaths(endsWith);

            foreach (string embeddedPrompt in embeddedPrompts)
            {
                Debug.WriteLine(embeddedPrompt);
                string prompt = EmbeddedPrompts.GetPrompt(embeddedPrompt);
                yield return (embeddedPrompt, prompt);
            }
        }
    }
}