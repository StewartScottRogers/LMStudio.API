using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LexerLibrary
{
    public class Lexer
    {
        private readonly string input;
        private readonly List<Token> tokens = new();
        private int currentPosition = 0;

        public Lexer(string input)
        {
            this.input = input;
            Tokenize();
        }

        public IEnumerable<Token> Tokens => tokens.AsReadOnly();

        private void Tokenize()
        {
            var lexer = new Lexer(input);
            foreach (var token in lexer.Lex())
            {
                tokens.Add(token);
            }
        }

        // This is the main class to handle lexing of the given grammar.
        public class Lexer
        {
            private readonly string input;
            private int position;

            public Lexer(string input)
            {
                this.input = input;
                this.position = 0;
            }

            public List<Tuple> Tokenize()
            {
                var tokens = new List<Tuple>();

                while (position < input.Length)
                {
                    if (char.IsWhiteSpace(input[position]))
                    {
                        position++;
                        continue;
                    }

                    if (char.IsLetterOrDigit(input[position]) || input[position] == '_')
                    {
                        var identifierStartPosition = position;
                        while (position < input.Length && (char.IsLetterOrDigit(input[position]) || input[position] == '_'))
                        {
                            position++;
                        }
                        var identifierLength = position - identifierStartPosition;
                        var identifier = new string(new[] { input[identifierStartPosition] }).ToString();
                        yield return identifier;
                    }

                    private static IEnumerable<string> ParseKeywords(string input)
                    {
                        var keywords = new HashSet<string>(new StringComparer(CaseInsensitiveComparer.Default))
                        {
                            "False", "None", "True",
                            "and", "as", "assert", "async",
                            "await", "break", "class", "continue",
                            "def", "del", "elif", "else",
                            "except", "finally", "for", "from",
                            "global", "if", "import", "in",
                            "is", "lambda", "match", "nonlocal",
                            "not", "or", "pass", "raise", "return",
                            "try", "while", "with", "yield"
The solution will be structured as follows:

1. **Project Structure**:
   - LexerLibrary
     - Classes
       - AbstractSyntaxTree.cs
       - Lexer.cs
       - Node.cs
     - Interfaces
       - ILexer.cs
       - INodeVisitor.cs
     - Enums
       - TokenType.cs
     - Records
       - TokenRecord.cs
     - UnitTests
       - LexerUnitTests.cs

To create a complete .NET 9.0 solution for the provided Python grammar lexer, we'll follow these steps:

1. **Initialize the Solution in Visual Studio:**
   - Create a new Class Library project.
   - Ensure it uses .NET 9.0 and is compatible with Visual Studio 2022.

2. **Project Structure:**