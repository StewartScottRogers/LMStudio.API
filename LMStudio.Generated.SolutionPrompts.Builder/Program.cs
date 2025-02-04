using AiPrompt.Library;
using AiPrompt.Library.ProjectPrompts;
using System;

string targetDirectory
     = BuildSolutionPrompts
        .SearchForDirectory("LMStudio.Generated.SolutionPrompts", 6);

Console.WriteLine($"{nameof(targetDirectory)}: {targetDirectory}");

string directivesPrompt
    = PromptCompositionBuilder
        .CreateDirectivesPrompt();

Console.WriteLine($"{nameof(directivesPrompt)}: {directivesPrompt}");

