using AiPrompt.Library;
using AiPrompt.Library.ProjectPrompts;
using System;
using System.IO;

string targetDirectory
     = BuildSolutionPrompts
        .SearchForDirectory("LMStudio.Generated.SolutionPrompts", 6);

string directivesPrompt
    = PromptCompositionBuilder
        .CreateDirectivesPrompt();

var projectPromptTuples
    = PromptCompositionBuilder
        .CreateProjectPrompt();

string promptsFolder = Path.Combine(targetDirectory, "Prompts");
if (!Directory.Exists(promptsFolder))
    Directory.CreateDirectory(promptsFolder);

foreach (var projectPromptTuple in projectPromptTuples)
{
    Console.WriteLine($"{nameof(projectPromptTuple)}: \r\n{directivesPrompt}/r/n{projectPromptTuple.ProjectPromptContent}");

    var targetFileParth
        = Path.Combine(promptsFolder, projectPromptTuple.ProjectPromptName);

    BuildSolutionPrompts.WriteAllText(targetFileParth, directivesPrompt + projectPromptTuple.ProjectPromptContent);

}