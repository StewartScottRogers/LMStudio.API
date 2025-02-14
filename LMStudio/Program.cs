using LMStudio;
using System;
using System.IO;
using System.Linq;


internal class Program
{
    private static void Main(string[] args)
    {
        string directivesPrompt
            = PromptCompositionBuilder
                .GetDirectivesPrompt(".Directives.md");

        var projectPromptTuples
            = PromptCompositionBuilder
                .SelectProjectPromptTuples(".Project.md")
                    .ToArray();

        string promptsOutputDirectoryPath
            = Path
                .Combine(
                    GenerateSolutionPrompts
                        .SearchForDirectoryRootPath("LMStudio.Generated.SolutionPrompts", 6),
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

            GenerateSolutionPrompts.WriteSolutionText(contentOutputFilePath, contentOutput);
        }

        string[] aiModels
            = {
                // "Qwen2.5 Coder 32B Instruct"
                // ,
                // "mistral-7b-instruct-v0.3"
                // ,
                // "Mistral Small 24B Instruct 2501"
                // ,
                "granite-3.1-8b-instruct"
            };

        foreach (string aiModel in aiModels)
        {
            string[] projectFilePaths
                = PromptCompositionBuilder
                    .GetAllPaths(".Project.md")
                        .ToArray();

            string outputFolder
                = ProjectFileManager
                    .GetProjectOutputFolder("LMStudio.OutputFolders");

            foreach (string projectFilePath in projectFilePaths)
                ProjectFileManager
                    .BuildProjectFiles(directivesPrompt, projectFilePath, outputFolder, aiModel);
        }

    }
}
