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

        // "mistral-small-24b-instruct-2501"
        // "phi-4"
        // "qwen2.5-coder-32b-instruct"
        // "deepseek-r1-distill-llama-8b"

        string aiModel = "qwen2.5-coder-32b-instruct";

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


        string outputFolder = Path.Combine(solutionFolder, aiModel);
        if (!Directory.Exists(outputFolder))
            Directory.CreateDirectory(outputFolder);


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
                        aiModel: aiModel,
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

            int prefixLength = "LMStudio.Prompts.".Count();
            string embeddedPartialSolutionFileNameTrimmed = embeddedPartialSolutionFileName.Remove(0, prefixLength);

            string embeddedOutputFileName
                    = Path
                        .GetFileNameWithoutExtension(
                            embeddedPartialSolutionFileNameTrimmed
                         ) + ".output.md";

            string embeddedOutputFilePath
                    = Path.Combine(outputFolder, embeddedOutputFileName);

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
                    = embeddedPartialSolutionFileNameTrimmed + $".{index++:000}" + ".cs";

                string embeddedSolutionFilePath
                    = Path.Combine(outputFolder, embeddedSolutionFileName);


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