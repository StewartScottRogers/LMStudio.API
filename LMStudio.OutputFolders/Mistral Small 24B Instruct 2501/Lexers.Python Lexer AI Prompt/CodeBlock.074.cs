// File: Lexer.cs
using System;
using System.Collections.Generic;
using System.IO;

namespace LexerLibrary
{
    public static class TokenType
    {
        public const string Keyword = "Keyword";
        public const string Identifier = "Identifier";
        public const string Literal = "Literal";
        public const string Operator = "Operator";
        public const string Punctuation = "Punctuation";
        public const string Whitespace = "Whitespace";
        public const string EndMarker = "EndMarker";
        # Add other token types as necessary
#

To create a Class Library in C# that lexes the given grammar and generates an Abstract Syntax Tree (AST), we need to follow these steps:

1. **Initialize a new Solution in Visual Studio.**
2. **Create separate files for each class, interface, enumeration, and record.**
3. **Develop unit tests using Microsoft's Unit Test Framework.**
4. **Include a .README or documentation summarizing the project and key points of logic.**

### Project Structure

1. **LexerProject.sln**
   - LexerLibrary
     - Lexer.cs
     - AstNode.cs
     - AbstractSyntaxTreePrettyPrinter.cs
     - NodeVisitor.cs
     - Tokenizer.cs
     - Interfaces
       - IToken.cs
       - IAbstractSyntaxTreeNode.cs
     - Enumerations
       - TokenType.cs

To create a complete .NET 9.0 Solution for lexing the provided grammar, generating an Abstract Syntax Tree (AST), and creating a Pretty Printer for the AST, we need to follow these steps:

1. **Initialize a new Solution in Visual Studio.**
2. **Define the project structure** ensuring each class, interface, enumeration, and record is in its own file.
3. **Develop the lexer, abstract syntax tree (AST) nodes, and pretty printer.**
4. **Write unit tests using Microsoft's Unit Test Framework.**

Below is a complete .NET 9.0 Solution that meets all the requirements specified. The solution includes a class library for lexing the given grammar, generating an AST, and pretty-printing it. It also includes unit tests using Microsoft's Unit Test Framework.

### Solution Structure