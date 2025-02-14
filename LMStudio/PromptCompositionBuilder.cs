using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LMStudio
{
    public static class PromptCompositionBuilder
    {
        public static string GetDirectivesPrompt(string endsWith)
        {
            IEnumerable<string> embeddedPrompts
                = GetAllPaths(endsWith);

            StringBuilder stringBuilder = new StringBuilder();
            foreach (string embeddedPrompt in embeddedPrompts)
            {
                Debug.WriteLine(embeddedPrompt);
                string prompt = GetPrompt(embeddedPrompt);
                stringBuilder.AppendLine(prompt);
            }

            return stringBuilder.ToString();
        }

        public static IEnumerable<(string ProjectPromptName, string ProjectPromptContent)> SelectProjectPromptTuples(string endsWith)
        {
            IEnumerable<string> embeddedPrompts
                = GetAllPaths(endsWith);

            foreach (string embeddedPrompt in embeddedPrompts)
            {
                Debug.WriteLine(embeddedPrompt);
                string prompt = GetPrompt(embeddedPrompt);
                yield return (embeddedPrompt, prompt);
            }
        }

        public static IEnumerable<string> GetAllPaths(string endsWith)
        {
            string[] embeddedResources
                = Assembly
                    .GetExecutingAssembly()
                        .GetManifestResourceNames()
                            .OrderBy(manifestResourceNames => manifestResourceNames.ToString())
                                .ToArray();

            foreach (string embeddedResource in embeddedResources)
                if (embeddedResource.EndsWith(endsWith))
                    yield return embeddedResource;
        }

        private static string GetPrompt(string path)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path))
            using (var reader = new System.IO.StreamReader(stream))
                return reader.ReadToEnd();
        }
    }
}