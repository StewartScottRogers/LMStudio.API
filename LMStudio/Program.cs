using AiPrompts;
using Compiler.CSharp;
using Compiler.CSharp.Extensions;
using LMStudio.API;
using LMStudio.API.Models;
using LMStudio.Consoles;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;

// "mistral-small-24b-instruct-2501"
// "phi-4"
// "qwen2.5-coder-32b-instruct"
// "deepseek-r1-distill-llama-8b"

Random randomizer = new Random();
IEnumerable<string> solutionPrompts
    = EmbeddedPrompts.GetAllPaths()
        .OrderBy((item) => randomizer.NextDouble()).ToArray()
            .Select(path => EmbeddedPrompts.GetPrompt(path));

foreach (string solutionPrompt in solutionPrompts)
{
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

    string input
        = tokenShuttle.ToString();

    Console.WriteLine(input);
    Console.WriteLine(new string('-', 80));

    IEnumerable<string> codeBlocks
        = tokenShuttle.ToCodeBlocks();

    foreach (string codeBlock in codeBlocks)
    {
        Console.WriteLine(codeBlock);

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

