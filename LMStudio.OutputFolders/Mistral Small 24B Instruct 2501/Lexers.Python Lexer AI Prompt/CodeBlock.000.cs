using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PythonLexer
{
    public sealed class Lexer
    {
        private readonly StreamReader inputStream;
        private readonly char[] buffer = new char[1];
        private int currentChar = -1;
        private List<string> tokens = new List<string>();
        private string currentToken = string.Empty;

        public void InitializeLexer() { }
        public ReadOnlyCollection<string> Tokens => new ReadOnlyCollection<string>(tokens);

# Step 1: Initialize a new Solution in Visual Studio

Create a new .NET Class Library project in Visual Studio 2022. Name the project `PythonLexer`.

## File Structure