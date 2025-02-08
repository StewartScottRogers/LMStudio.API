using AiPrompt.Library;
using AiPrompt.Library.ProjectPrompts;
using System;
using System.IO;
using System.Linq;

string targetDirectory
     = BuildSolutionPrompts
        .SearchForDirectory("LMStudio.Generated.SolutionPrompts", 6);

string directivesPrompt
    = PromptCompositionBuilder
        .CreateDirectivesPrompt();

var projectPromptTuples
    = PromptCompositionBuilder
        .CreateProjectPrompt().ToArray();

string promptsDirectoryPath = Path.Combine(targetDirectory, "Prompts");
if (!Directory.Exists(promptsDirectoryPath))
    Directory.CreateDirectory(promptsDirectoryPath);

foreach (var projectPromptTuple in projectPromptTuples)
{
    Console.WriteLine($"{nameof(projectPromptTuple.ProjectPromptName)}: {projectPromptTuple.ProjectPromptName}");
    Console.WriteLine($"{projectPromptTuple.ProjectPromptContent}");


    int prefixLength = "AiPrompt.Library.ProjectPrompts.".Count();
    string projectPromptName = projectPromptTuple.ProjectPromptName;
    string projectPromptNameTrimmed = projectPromptName.Remove(0, prefixLength);

    string contentOutputPartialFilePath
        = Path.Combine(promptsDirectoryPath, projectPromptNameTrimmed);

    string contentOutputFilePath
        = Path
            .ChangeExtension(contentOutputPartialFilePath, ".md");

    string contentOutputHeader
        = Path.GetFileNameWithoutExtension(
            Path.GetFileNameWithoutExtension(projectPromptNameTrimmed)
         ).Replace(".", ": ");

    string contentOutput
        = $"# {contentOutputHeader}" + Environment.NewLine
        + new string('-', 120) + Environment.NewLine
        + directivesPrompt
        + Environment.NewLine
        + new string('-', 120) + Environment.NewLine
        + projectPromptTuple.ProjectPromptContent
        + Environment.NewLine;

    BuildSolutionPrompts.WriteAllText(contentOutputFilePath, contentOutput);

}