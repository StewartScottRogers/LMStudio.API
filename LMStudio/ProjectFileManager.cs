using AiPrompts;
using Compiler.CSharp;
using Compiler.CSharp.Extensions;
using LMStudio.API;
using LMStudio.API.Models;
using LMStudio.Consoles;
using Microsoft.CodeAnalysis;
using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;

namespace LMStudio
{
    public static class ProjectFileManager
    {
        public static string GetOutputFolder(string directoryName = "LMStudio.OutputFiles", int levelsUp = 6)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            for (int index = 0; index < levelsUp; index++)
            {
                string targetDirectory = Path.Combine(currentDirectory, directoryName);
                if (Directory.Exists(targetDirectory))
                    return targetDirectory;

                currentDirectory = Directory.GetParent(currentDirectory)?.FullName;
                if (currentDirectory == null)
                    break;
            }

            return string.Empty;
        }

        public static void BuildProjectFiles(string projectFilePath, string outputFolder, string aiModel)
        {
            outputFolder = Path.Combine(outputFolder, aiModel);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            Console.WriteLine(new string('=', 80));
            Console.WriteLine(projectFilePath);

            string embeddedPartialSolutionOutputFileName
                = Path
                    .GetFileNameWithoutExtension(
                        Path.GetFileNameWithoutExtension(projectFilePath)
                    ) + ".Solution.cs";

            Console.WriteLine(embeddedPartialSolutionOutputFileName);
            Console.WriteLine(new string('=', 80));

            string inputContentFileNameTrimmed
                = embeddedPartialSolutionOutputFileName.Remove(0, "LMStudio.Prompts.".Count());

            string inputContent
                = EmbeddedPrompts.GetPrompt(projectFilePath);

            string inputContentFileName
                = Path.GetFileNameWithoutExtension(inputContentFileNameTrimmed) + ".input.md";

            string inputContentFilePath
                = Path.Combine(outputFolder, inputContentFileName);

            WriteAllText(inputContentFilePath, inputContent);

            TokenShuttle tokenShuttle
                = LMStudioConnection
                    .FetchAiReplies(
                        endpoint: "http://192.168.1.7:1232",
                        aiModel: aiModel,
                        prompt: inputContent
                    );

            using (TokenConsole tokenConsole = new TokenConsole(Console.BackgroundColor))
            {
                foreach (string token in tokenShuttle)
                    tokenConsole.ProcessToken(token);
            }

            Console.WriteLine(new string('-', 80));
            string promptOutputContent = tokenShuttle.PromptOutputContent();
            Console.WriteLine(promptOutputContent);

            string embeddedOutputFileName
                = Path.GetFileNameWithoutExtension(inputContentFileNameTrimmed) + ".output.md";

            string embeddedOutputFilePath
                = Path.Combine(outputFolder, embeddedOutputFileName);

            WriteAllText(embeddedOutputFilePath, promptOutputContent);

            Console.WriteLine("");
            Console.WriteLine(new string('-', 80));

            string[] codeBlocks
                = tokenShuttle
                    .ToCodeBlocks()
                        .ToArray();

            BuildCodeBlocks(
                outputFolder: outputFolder,
                outputFileName: inputContentFileNameTrimmed,
                codeBlocks: codeBlocks
            );

            Console.WriteLine(new string('-', 80));
        }

        private static void BuildCodeBlocks(string outputFolder, string outputFileName, string[] codeBlocks)
        {
            int index = 0;
            foreach (string codeBlock in codeBlocks)
            {
                CompileCodeBlock(
                    codeBlock: codeBlock
                );

                SaveCodeBlockToFile(
                    codeBlockOutputFilePath: Path.Combine(outputFolder, outputFileName + $".{index++:000}" + ".cs"),
                    codeBlock: codeBlock
                );
            }
        }

        private static void CompileCodeBlock(string codeBlock)
        {
            Console.WriteLine(new string('.', 80));
            SyntaxTree syntaxTree = codeBlock.CompileSyntaxTree();
            string formattedSyntaxTree = syntaxTree.GetRoot().ToFormattedSyntaxTree().Trim();
            Console.WriteLine(formattedSyntaxTree);
        }

        private static void SaveCodeBlockToFile(string codeBlockOutputFilePath, string codeBlock)
        {
            Console.WriteLine(new string('*', 80));
            Console.WriteLine(codeBlockOutputFilePath);
            Console.WriteLine(codeBlock);
            Console.WriteLine(new string('*', 80));
            WriteAllText(codeBlockOutputFilePath, codeBlock);
            Console.WriteLine(new string('-', 80));
        }

        private static void WriteAllText(string path, string contents)
        {
            {
                Contract.Requires(path != null);
                Contract.Requires(path.Length > 0);
                using StreamWriter streamWriter = new StreamWriter(path, false, Encoding.UTF8);
                streamWriter.Write(contents);
            }
        }
    }
}