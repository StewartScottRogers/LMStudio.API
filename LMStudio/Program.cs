using AiPrompts;
using Compiler.CSharp;
using Compiler.CSharp.Extensions;
using LMStudio;
using LMStudio.API;
using LMStudio.API.Models;
using LMStudio.Consoles;
using Microsoft.CodeAnalysis;
using System;
using System.IO;
using System.Linq;


internal class Program
{
    private static void Main(string[] args)
    {
        string aiModel = "qwen2.5-coder-32b-instruct";

        string[] projectFilePaths = EmbeddedPrompts.GetAllPaths(endsWith: ".Project.md").ToArray();

        string outputFolder = BuildOutputFiles.SearchForDirectory("LMStudio.OutputFiles", 6);

        outputFolder = Path.Combine(outputFolder, aiModel);
        if (!Directory.Exists(outputFolder))
            Directory.CreateDirectory(outputFolder);

        foreach (string projectFilePath in projectFilePaths)
            BuildProjectFiles(projectFilePath, outputFolder, aiModel);
    }

    private static void BuildProjectFiles(string projectFilePath, string outputFolder, string aiModel)
    {
        Console.WriteLine(new string('=', 80));
        Console.WriteLine(projectFilePath);

        string embeddedPartialSolutionOutputFileName = Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(projectFilePath)) + ".Solution.cs";

        Console.WriteLine(embeddedPartialSolutionOutputFileName);
        Console.WriteLine(new string('=', 80));

        string inputContentFileNameTrimmed = embeddedPartialSolutionOutputFileName.Remove(0, "LMStudio.Prompts.".Count());

        string inputContent = EmbeddedPrompts.GetPrompt(projectFilePath);

        string inputContentFileName = Path.GetFileNameWithoutExtension(inputContentFileNameTrimmed) + ".input.md";

        string inputContentFilePath = Path.Combine(outputFolder, inputContentFileName);

        BuildOutputFiles.WriteAllText(inputContentFilePath, inputContent);

        TokenShuttle tokenShuttle = LMStudioConnection.FetchAiReplies(endpoint: "http://192.168.1.7:1232", aiModel: aiModel, prompt: inputContent);

        using (TokenConsole tokenConsole = new TokenConsole(Console.BackgroundColor))
        {
            foreach (string token in tokenShuttle)
                tokenConsole.ProcessToken(token);
        }

        Console.WriteLine(new string('-', 80));

        string promptOutputContent = tokenShuttle.PromptOutputContent();

        Console.WriteLine(promptOutputContent);

        string embeddedOutputFileName = Path.GetFileNameWithoutExtension(inputContentFileNameTrimmed) + ".output.md";

        string embeddedOutputFilePath = Path.Combine(outputFolder, embeddedOutputFileName);

        BuildOutputFiles.WriteAllText(embeddedOutputFilePath, promptOutputContent);

        Console.WriteLine("");
        Console.WriteLine(new string('-', 80));

        string[] codeBlocks = tokenShuttle.ToCodeBlocks().ToArray();

        int index = 0;
        foreach (string codeBlock in codeBlocks)
        {
            string embeddedSolutionOutputFileName = inputContentFileNameTrimmed + $".{index++:000}" + ".cs";

            string embeddedSolutionOutputFilePath = Path.Combine(outputFolder, embeddedSolutionOutputFileName);

            Console.WriteLine(new string('*', 80));
            Console.WriteLine(embeddedSolutionOutputFilePath);
            Console.WriteLine(codeBlock);
            Console.WriteLine(new string('*', 80));

            BuildOutputFiles.WriteAllText(embeddedSolutionOutputFilePath, codeBlock);

            SyntaxTree syntaxTree = codeBlock.CompileSyntaxTree();

            Console.WriteLine(new string('.', 80));

            string formattedSyntaxTree = syntaxTree.GetRoot().ToFormattedSyntaxTree().Trim();

            Console.WriteLine(formattedSyntaxTree);

            Console.WriteLine(new string('-', 80));
        }

        Console.WriteLine(new string('-', 80));
    }
}
