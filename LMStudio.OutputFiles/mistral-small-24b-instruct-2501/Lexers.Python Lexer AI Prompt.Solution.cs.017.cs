// Lexer.cs
using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public class Lexer
    {
        private readonly string input;
        private int position = 0;

        public Lexer(string input)
        {
            this.input = input;
        }

        public TokenTuple NextToken()
        {
            SkipWhitespace();
            if (position >= input.Length)
            {
                return new TokenTuple(null, null);
            }

            var currentChar = Peek();

            // Example token matching logic
            switch (currentChar)
            {
                case '(':
                    return new TokenTuple("LEFT_PAREN", "(");
                case ')':
                    return new TokenTuple("RIGHT_PAREN", ")");
                case '{':
                    return new TokenTuple("LEFT_CURLY", "{");
                case '}':
                    return new TokenTuple("RIGHT_CURLY", "}");
                // Add more token definitions as needed
            }

Below is a step-by-step guide to create the .NET 9.0 Solution in C# with the specified requirements:

### Step 1: Initialize a New Solution in Visual Studio

1. Open Visual Studio 2022.
2. Create a new solution and name it `PythonLexerSolution`.
3. Add a new Class Library project to the solution and name it `PythonLexer`.

### Step 2: Define the Project Structure

Create separate files for each class, interface, enumeration, and record as specified.

#### File: `PythonLexer.cs`