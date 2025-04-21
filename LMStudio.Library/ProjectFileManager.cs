using Compiler.CSharp;
using Compiler.CSharp.Extensions;
using LMStudio.Consoles;
using LMStudio.Libraries;
using LMStudio.Models;
using Microsoft.CodeAnalysis;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LMStudio
{
    public static class ProjectFileManager
    {
        public static void BuildProjectFiles(string directivesPromptContent, string projectPromptFilePath, string outputFolder, string aiModelFolder)
        {
            Console.WriteLine(new string('=', 80));
            Console.WriteLine(projectPromptFilePath);

            outputFolder = Path.Combine(outputFolder, aiModelFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string cropedAiModelFolder
                = Path
                    .GetFileNameWithoutExtension(
                        Path.GetFileNameWithoutExtension(projectPromptFilePath)
                    ).Remove(0, "LMStudio.ProjectPrompts.".Length);

            outputFolder = Path.Combine(outputFolder, cropedAiModelFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            Console.WriteLine(new string('=', 80));

            string projectPromptContent = GetPrompt(projectPromptFilePath);
            string inputPromptContent
                = directivesPromptContent
                + Environment.NewLine
                + projectPromptContent;


            string inputPromptContentFilePath
                = Path.Combine(outputFolder, "input.md");

            FileSystemManagement.WriteAllText(inputPromptContentFilePath, inputPromptContent);

            TokenShuttle tokenShuttle
                = LMStudioConnection
                    .FetchAiReplies(
                        endpoint: "http://192.168.1.3:1232",
                        aiModel: aiModelFolder,
                        prompt: inputPromptContent
                    );

            using (TokenConsole tokenConsole = new TokenConsole(Console.BackgroundColor))
            {
                foreach (string token in tokenShuttle)
                    tokenConsole.ProcessToken(token);
            }

            Console.WriteLine(new string('-', 80));
            string promptOutputContent = tokenShuttle.PromptOutputContent();
            Console.WriteLine(promptOutputContent);

            string embeddedOutputFileName = "output.md";

            string embeddedOutputFilePath
                = Path.Combine(outputFolder, embeddedOutputFileName);

            FileSystemManagement.WriteAllText(embeddedOutputFilePath, promptOutputContent);

            Console.WriteLine("");
            Console.WriteLine(new string('-', 80));

            string[] codeBlocks
                = tokenShuttle
                    .ToCodeBlocks()
                        .ToArray();

            BuildCodeBlocks(
                outputFolder: outputFolder,
                codeBlocks: codeBlocks
            );

            Console.WriteLine(new string('-', 80));
        }

        private static void BuildCodeBlocks(string outputFolder, string[] codeBlocks)
        {
            int index = 0;
            foreach (string codeBlock in codeBlocks)
            {
                CompileCodeBlock(
                    codeBlock: codeBlock
                );

                SaveCodeBlockToFile(
                    codeBlockOutputFilePath: Path.Combine(outputFolder, $"CodeBlock.{index++:000}" + ".cs"),
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
            FileSystemManagement.WriteAllText(codeBlockOutputFilePath, codeBlock);
            Console.WriteLine(new string('-', 80));
        }

        private static string GetPrompt(string path)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path))
            using (var reader = new StreamReader(stream))
                return reader.ReadToEnd();
        }
    }
}