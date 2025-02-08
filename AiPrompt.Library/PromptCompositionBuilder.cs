using AiPrompts;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AiPrompt.Library.ProjectPrompts
{
    public static class PromptCompositionBuilder
    {
        public static string CreateDirectivesPrompt()
        {
            IEnumerable<string> embeddedPrompts
                = EmbeddedPrompts.GetAllPaths("Directives.md");

            StringBuilder stringBuilder = new StringBuilder();
            foreach (string embeddedPrompt in embeddedPrompts)
            {
                Debug.WriteLine(embeddedPrompt);
                string prompt = EmbeddedPrompts.GetPrompt(embeddedPrompt);
                stringBuilder.AppendLine(prompt);
            }

            return stringBuilder.ToString();
        }

        public static IEnumerable<(string ProjectPromptName, string ProjectPromptContent)> CreateProjectPrompt()
        {
            IEnumerable<string> embeddedPrompts
                = EmbeddedPrompts.GetAllPaths("Project.md");

            foreach (string embeddedPrompt in embeddedPrompts)
            {
                Debug.WriteLine(embeddedPrompt);
                string prompt = EmbeddedPrompts.GetPrompt(embeddedPrompt);
                yield return (embeddedPrompt, prompt);
            }
        }
    }
}