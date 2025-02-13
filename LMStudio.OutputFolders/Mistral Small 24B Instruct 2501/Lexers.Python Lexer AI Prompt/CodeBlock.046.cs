using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public class PythonLexer
    {
        private readonly string input;
        private int position = 0;

        public PythonLexer(string input)
        {
            this.input = input;
        }

        public IEnumerable<TupleToken> Tokenize()
        {
            while (position < input.Length)
            {
                char currentChar = Peek();
                if (char.IsWhiteSpace(currentChar))
                {
                    SkipWhitespace();
                    continue;
                }
                else if (IsOperator(currentChar) || IsDelimiter(currentChar))
                {
                    yield return new TokenTuple { Type = TokenType.Operator, Value = ReadOperator() };
                }
                else if (CurrentCharacter == '(')
                {
                    yield return new TokenTuple { Type = TokenType.LeftParenthesis, Value = CurrentCharacter.ToString() };
                }
                else if (CurrentCharacter == ')')
                {
                    yield return new TokenTuple { Type = TokenType.RightParenthesis, Value = CurrentCharacter.ToString() };
                }

I'll provide a high-level overview of the solution structure and then dive into the code for each component.

### Solution Structure

1. **Project Initialization**:
   - Create a new .NET 9.0 solution in Visual Studio.
   - Add a Class Library project to the solution.

2. **File Structure**:
   - Each class, interface, enumeration, and record will be in its own file.

3. **Lexer Components**:
   - `Token`: Represents a token in the input.
   - `TokenType`: Enumeration of different token types.
   - `Lexer`: Class responsible for tokenizing the input.
   - `AbstractSyntaxTree`: Base class for all AST nodes.
   - `StatementNode`, `CompoundStmtNode`, etc.: Specific AST node classes.

- **Unit Tests**: Ensure comprehensive coverage using Microsoft's Unit Test Framework. Include tests for lexing and parsing various statements, expressions, and constructs defined in the grammar.

## Project Structure

1. **Solution File**: LexerSolution.sln
2. **Class Library Project**:
   - **LexerProject.csproj**
     - **Interfaces**: ILexer.cs, IAbstractSyntaxTreeNode.cs
     - **Enumerations**: TokenType.cs
     - **Records**: TokenRecord.cs
     - **Classes**:
       - Lexer.cs
       - AbstractSyntaxTreePrettyPrinter.cs
       - NodeFactory.cs
       - StatementNode.cs
       - SimpleStatementNode.cs
       - CompoundStatementNode.cs
       - AssignmentNode.cs
       - FunctionDefNode.cs
       - IfStmtNode.cs
       - ClassDefNode.cs
       - WithStmtNode.cs
       - ForStmtNode.cs
       - TryStmtNode.cs
       - WhileStmtNode.cs
       - MatchStmtNode.cs
       - ReturnStmtNode.cs
       - RaiseStmtNode.cs
       - GlobalStmtNode.cs
       - NonlocalStmtNode.cs
       - DelStmtNode.cs
       - YieldStmtNode.cs
       - AssertStmtNode.cs
       - BreakStmtNode.cs
       - ContinueStmtNode.cs

To create a Class Library for lexing the provided grammar and generating an Abstract Syntax Tree (AST) in C#, we need to follow several steps. Below is a structured approach to achieve this, including the creation of necessary classes, interfaces, enums, and records.

### Project Structure
1. **Solution**: LexerProject
   - **Class Library**: LexerLibrary
     - **Classes**:
       - `Lexer`
       - `Token`
       - `AstNode`
       - `AstPrettyPrinter`
       - Various AST Node Classes (e.g., `AssignmentNode`, `ExpressionNode`)
     - **Interfaces**:
       - `IAstNode`
     - **Enumerations**:
       - `TokenType`
     - **Records**:
       - `LexerResultTuple`

Below is a step-by-step guide to create the .NET solution as per your requirements. I'll provide the code for each file, ensuring it adheres to the coding style and structure you specified.

### Solution Structure