using AiPrompts;
using Compiler.CSharp;
using Compiler.CSharp.Extensions;
using LMStudio;
using LMStudio.API;
using LMStudio.API.Models;
using LMStudio.Consoles;
using Markdig.Syntax;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Google.Rpc.Context.AttributeContext.Types;

// "mistral-small-24b-instruct-2501"
// "phi-4"
// "qwen2.5-coder-32b-instruct"
// "deepseek-r1-distill-llama-8b"

internal class Program
{
    private static void Main(string[] args)
    {
        Random randomizer = new Random();
        string[] embeddedProjectFilePaths
            = EmbeddedPrompts.GetAllPaths(endsWith: ".Project.txt")
                .OrderBy((item) => randomizer.NextDouble())
                    .ToArray();

        string targetDirectory
            = BuildCsFiles
                .SearchForDirectory("LMStudio.OutputFiles", 6);


        string solutionFolder = targetDirectory;
        if (!Directory.Exists(solutionFolder))
            Directory.CreateDirectory(solutionFolder);

        foreach (string embeddedProjectFilePath in embeddedProjectFilePaths)
        {
            Console.WriteLine(new string('=', 80));
            Console.WriteLine(embeddedProjectFilePath);

            string embeddedPartialSolutionFileName
                = Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(embeddedProjectFilePath)) + ".Solution.cs";

            Console.WriteLine(embeddedPartialSolutionFileName);
            Console.WriteLine(new string('=', 80));

            string solutionPrompt
                = EmbeddedPrompts.GetPrompt(embeddedProjectFilePath);

            TokenShuttle tokenShuttle
                = LMStudioConnection
                    .FetchAiReplies(
                        endpoint: "http://192.168.1.7:1232",
                        aiModel: "deepseek-r1-distill-llama-8b",
                        prompt: solutionPrompt
                    );

            using (TokenConsole tokenConsole = new TokenConsole(Console.BackgroundColor))
            {
                foreach (string token in tokenShuttle)
                    tokenConsole.ProcessToken(token);
            }

            Console.WriteLine(new string('-', 80));

            string content
                = tokenShuttle.Content();

            Console.WriteLine(content);

            string embeddedOutputFileName
                    = embeddedPartialSolutionFileName + ".output.txt";

            string embeddedOutputFilePath
                    = Path.Combine(solutionFolder, embeddedOutputFileName);

            BuildCsFiles.WriteAllText(embeddedOutputFilePath, content);

            Console.WriteLine("");
            Console.WriteLine(new string('-', 80));

            string[] codeBlocks
                = tokenShuttle.ToCodeBlocks()
                .ToArray();


            int index = 0;
            foreach (string codeBlock in codeBlocks)
            {
                string embeddedSolutionFileName
                    = embeddedPartialSolutionFileName + $".{index++:000}" + ".cs";

                string embeddedSolutionFilePath
                    = Path.Combine(solutionFolder, embeddedSolutionFileName);


                Console.WriteLine(embeddedSolutionFilePath);
                Console.WriteLine(new string('*', 80));
                Console.WriteLine(embeddedSolutionFilePath);
                Console.WriteLine(codeBlock);
                Console.WriteLine(new string('*', 80));

                BuildCsFiles.WriteAllText(embeddedSolutionFilePath, codeBlock);

                SyntaxTree syntaxTree
                    = codeBlock.CompileSyntaxTree();

                Console.WriteLine(new string('.', 80));

                string formattedSyntaxTree
                    = syntaxTree.GetRoot()
                        .ToFormattedSyntaxTree().Trim();

                Console.WriteLine(formattedSyntaxTree);

                Console.WriteLine(new string('-', 80));
            }


            Console.WriteLine(new string('-', 80));
        }
    }
}