using LMStudio.API;
using LMStudio.API.Extensions;
using LMStudio.API.Models;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;

// "mistral-small-24b-instruct-2501"
// "phi-4"
// "qwen2.5-coder-32b-instruct"
// "deepseek-r1-distill-llama-8b"

TokenShuttle tokenShuttle
    = LMStudioConnection
        .FetchAiReplies(
            endpoint: "http://192.168.1.7:1232",
            aiModel: "qwen2.5-coder-32b-instruct",
            message: "Use C# to write out the Fibonacci series. "
        );

ConsoleColor InitalBackgoundColor = Console.BackgroundColor;
try
{

    long index = 0;
    foreach (string token in tokenShuttle)
    {
        WriteToken(index, token);
        index++;
    }
}
finally
{
    Console.BackgroundColor = InitalBackgoundColor;
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




static void WriteToken(long index, string token)
{
    bool oddNumber = (index % 2 == 0);
    if (oddNumber)
        Console.BackgroundColor = ConsoleColor.DarkBlue;
    else
        Console.BackgroundColor = ConsoleColor.DarkGreen;
    Console.Write(token);
}
