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

string promptsFolder = Path.Combine(targetDirectory, "Prompts");
if (!Directory.Exists(promptsFolder))
    Directory.CreateDirectory(promptsFolder);

foreach (var projectPromptTuple in projectPromptTuples)
{
    Console.WriteLine($"{nameof(projectPromptTuple)}: \r\n{directivesPrompt}/r/n{projectPromptTuple.ProjectPromptContent}");

    int prefixLength = "AiPrompt.Library.ProjectPrompts.".Count();
    string projectPromptName = projectPromptTuple.ProjectPromptName;
    string projectPromptNameTrimmed = projectPromptName.Remove(0, prefixLength);

    string targetFileParth
        = Path.Combine(promptsFolder, projectPromptNameTrimmed);

    BuildSolutionPrompts.WriteAllText(targetFileParth, directivesPrompt + projectPromptTuple.ProjectPromptContent);

}