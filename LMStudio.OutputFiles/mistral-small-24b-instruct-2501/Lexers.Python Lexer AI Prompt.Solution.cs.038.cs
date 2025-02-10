namespace LexerLibrary
{
    public class Token
    {
        public string Type { get; init; }
        public string Value { get; init; }

        public Token(string type, string value)
        {
            Type = type;
            Value = value;
        }

        // Override ToString method to provide a readable representation of the token.
        public override string ToString()
        {
            return $"Type: {Type}, Value: {Value}";
        }
    }
}

namespace LexerLibrary
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Defines an interface for lexing tokens from a given input stream.
    /// </summary>
    public interface ILexer
    {
        /// <summary>
        /// Tokenizes the input stream and returns a list of tokens.
        /// </summary>
        /// <param name="inputStream">The input stream to tokenize.</param>
        /// <returns>A list of tokens.</returns>
        var TokenListTuple { get; }
        public List<Token> GenerateTokens(StreamReader inputStream);

**Solution Structure**

1. **LexerProject.sln**: The main solution file.
2. **LexerLibrary**: Class Library Project
   - **LexerLibrary.csproj**
   - **AstNode.cs**
   - **AssignmentExpressionNode.cs**
   - **AssertStatementNode.cs**
   - **AsyncFunctionDefNode.cs**
   - **ClassDefNode.cs**
   - **CompoundStmtNode.cs**
   - **DelStmtNode.cs**
   - **ElseBlockNode.cs**
   - **ExceptBlockNode.cs**
   - **FinallyBlockNode.cs**
   - **ForStmtNode.cs**
   - **FunctionDefNode.cs**
   - **GlobalStatementNode.cs**
   - **ImportFromAsNameNode.cs**
   - **ImportFromAsNamesNode.cs**
   - **ImportFromTargetNode.cs**
  - **ImportNameNode.cs**

Given the requirements and grammar, I'll outline the steps to create a .NET 9.0 Solution in C# that includes a lexer for the given grammar, an Abstract Syntax Tree (AST) pretty printer, all nodes in the AST, and unit tests.

### Step-by-Step Solution

1. **Initialize the Project:**
   - Open Visual Studio 2022.
   - Create a new .NET 9.0 Class Library project named `LexerLibrary`.

2. **Define the Project Structure:**
   - Create separate files for each class, interface, enumeration, and record as per the coding style guidelines.

3. **Implement the Lexer:**
   - The lexer will tokenize the input based on the provided grammar.
   - Each token type should be defined in an enumeration.
   - The lexer should handle various tokens like NAME, NUMBER, STRING, etc.

# Solution Structure

## Project Structure