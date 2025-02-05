using AiPrompts;
using Compiler.CSharp;
using Compiler.CSharp.Extensions;
using LMStudio.API;
using LMStudio.API.Models;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;

// "mistral-small-24b-instruct-2501"
// "phi-4"
// "qwen2.5-coder-32b-instruct"
// "deepseek-r1-distill-llama-8b"


IEnumerable<string> solutionPrompts
    = EmbeddedPrompts.GetAllPaths()
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

    ConsoleColor InitialBackgroundColor = Console.BackgroundColor;
    try
    {
        long index = 0;
        foreach (string token in tokenShuttle)
            ProcessToken(index++, token, InitialBackgroundColor);
    }
    finally
    {
        Console.BackgroundColor = InitialBackgroundColor;
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

static void ProcessToken(long index, string token, ConsoleColor initialBackgroundColor)
{
    string strippedToken = RemoveTrailingNewlines(token);
    if (strippedToken.Count() < token.Count())
    {
        WriteColerizedToken(index, strippedToken);

        int trailingNewLineLength = token.Length - strippedToken.Length;
        string newLines = new string('\n', trailingNewLineLength);
        Console.BackgroundColor = initialBackgroundColor;
        Console.Write(newLines);
    }
    else
    {
        WriteColerizedToken(index, token);
    }
}

static string RemoveTrailingNewlines(string token)
{
    while (token.EndsWith("\n"))
        return RemoveTrailingNewlines(token.Substring(0, token.Length - 1));
    return token;
}

static void WriteColerizedToken(long index, string token)
{
    bool oddNumber = (index % 2 == 0);
    if (oddNumber)
        Console.BackgroundColor = ConsoleColor.DarkBlue;
    else
        Console.BackgroundColor = ConsoleColor.DarkGreen;
    Console.Write(token);
}
