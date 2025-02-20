using LMStudio;
using LMStudio.Libraries;
using System;
using System.IO;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        string directivesPrompt
            = EmbeddedResourceManagement
                .GetDirectivesPrompt(".Directives.md");

        var projectPromptTuples
            = EmbeddedResourceManagement
                .SelectProjectPromptTuples(".Project.md")
                    .ToArray();

        string promptsOutputDirectoryPath
            = Path
                .Combine(
                    FileSystemManagement
                        .GetSiblingFolder("AiPrompt.Projects", 6),
                    "Prompts"
                );

        if (!Directory.Exists(promptsOutputDirectoryPath))
            Directory.CreateDirectory(promptsOutputDirectoryPath);

        foreach (var projectPromptTuple in projectPromptTuples)
        {
            Console.WriteLine($"{nameof(projectPromptTuple.ProjectPromptName)}: {projectPromptTuple.ProjectPromptName}");
            Console.WriteLine($"{projectPromptTuple.ProjectPromptContent}");

            string projectPromptOutputName
                = projectPromptTuple
                    .ProjectPromptName
                        .Remove(0, "LMStudio.ProjectPrompts.".Count());

            string contentOutputPartialFilePath
                = Path.Combine(promptsOutputDirectoryPath, projectPromptOutputName);

            string contentOutputFilePath
                = Path
                    .ChangeExtension(contentOutputPartialFilePath, ".md");

            string contentOutputHeader
                = Path.GetFileNameWithoutExtension(
                    Path.GetFileNameWithoutExtension(projectPromptOutputName)
                 ).Replace(".", ": ");

            string contentOutput
                = $"# {contentOutputHeader}" + Environment.NewLine
                + new string('-', 120) + Environment.NewLine
                + directivesPrompt
                + Environment.NewLine
                + new string('-', 120) + Environment.NewLine
                + projectPromptTuple.ProjectPromptContent
                + Environment.NewLine;

            FileSystemManagement.WriteAllText(contentOutputFilePath, contentOutput);
        }

        string[] aiModels
            = {
                 "Qwen2.5 Coder 32B Instruct"                
                 //,
                 //"Mistral Small 24B Instruct 2501"
                 //,
                 //"DeepSeek R1 Distill Llama 8B"
                 //,
                 //"deepseek-coder-v2-lite-instruct"
                 //,
                 //"deephermes-3-llama-3-8b-preview@f16"
                 //,
                 //"openthinker-32b"
            };

        foreach (string aiModel in aiModels)
        {
            string[] projectFilePaths
                = EmbeddedResourceManagement
                    .GetAllPaths(".Project.md")
                        .ToArray();

            string outputFolder
                = FileSystemManagement
                    .GetSiblingFolder("AiPrompt.Solutions");

            foreach (string projectFilePath in projectFilePaths)
                ProjectFileManager
                    .BuildProjectFiles(directivesPrompt, projectFilePath, outputFolder, aiModel);
        }

    }
}
