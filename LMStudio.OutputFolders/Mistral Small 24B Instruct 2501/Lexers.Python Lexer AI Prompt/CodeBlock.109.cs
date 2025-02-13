using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public class GrammarLexer
    {
        private readonly string input;
        private int position = 0;

        public GrammarLexer(string input)
        {
            this.input = input;
        }

        public void Tokenize()
        {
            var tokens = new List<string>();
            while (position < input.Length)
            {
                char currentChar = input[position];
                if (char.IsWhiteSpace(currentChar))
                {
                    position++;
                    continue;
                }
                else if (currentChar == '#')
                {
                    // Skip comments
                    while (position < input.Length && input[position] != '\n')
                    {
                        position++;
                    }
                }
                else if (char.IsLetterOrDigit(char) || char == '_' )
                {
                    // Identify keywords, names, etc.
                    var keyword = ReadIdentifier(input);
                    switch(keyword)
                    {
                        case "import":
                            HandleImportStatement(input);
                            break;
                        case "from":
                            HandleFromImportStatement(input);
                            break;

                    }
                }

Creating a comprehensive .NET 9.0 solution for lexing the given grammar, generating an Abstract Syntax Tree (AST), and creating a pretty printer involves several steps. Below is a step-by-step guide to achieve this:

### Step 1: Initialize a New Solution in Visual Studio
1. Open Visual Studio 2022.
2. Create a new .NET Core Class Library project named `LexerLibrary`.
3. Ensure the solution targets .NET 9.0.

### Step 2: Define the Project Structure
Create separate files for each class, interface, enumeration, and record as specified.

#### File: Statements.cs