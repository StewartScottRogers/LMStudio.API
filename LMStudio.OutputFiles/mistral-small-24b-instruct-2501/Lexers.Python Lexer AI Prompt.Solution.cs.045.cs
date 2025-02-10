using System;
using LexerLibrary;

namespace LexerSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lexer Library Test");

            // Example usage of the lexer
            var lexer = new Lexer();
            var input = "def foo(x): return x + 1";
            var tokens = lexer.Tokenize(input);

            foreach (var token in tokens)
            {
                System.Console.WriteLine(token);
            }
        }

To create a .NET 9.0 Solution for the described Lexer, Abstract Syntax Tree (AST) Pretty Printer, and Unit Tests, follow these steps:

### Step 1: Initialize the Solution

1. **Create a new .NET Class Library project in Visual Studio 2022.**
   - Name the solution `LexerProject`.
   - Create a new folder structure for different components:
     - `Lexer`
     - `AstNodes`
     - `PrettyPrinter`
     - `Tests`

### Step-by-Step Implementation

#### 1. Initialize the Solution
- Create a new .NET 9.0 solution in Visual Studio 2022.
- Ensure each class, interface, enumeration, and record is in its own file.

#### 2. Define the Project Structure
Create the following files:

1. **Lexer.cs**
2. **AstNodeBase.cs**
3. **StatementNodes.cs**
4. **ExpressionNodes.cs**
5. **ImportNodes.cs**
6. **FunctionNodes.cs**
7. **ClassNodes.cs**
8. **ControlFlowNodes.cs**
9. **PatternNodes.cs**
10. **LexerTests.cs**

Below is a structured approach to create a .NET 9.0 Solution in C# for the given grammar, adhering to your coding style and project structure guidelines.

### Step 1: Initialize the Solution
Create a new solution named `PythonLexerSolution` with a single Class Library project named `PythonLexerLibrary`.

### Step 2: Define Project Structure

#### Files:
1. **TokenType.cs**: Enumeration for token types.
2. **AbstractSyntaxTree.cs**: Abstract Syntax Tree (AST) nodes and classes.
3. **Lexer.cs**: Lexer class to tokenize the input.
4. **AstPrettyPrinter.cs**: Pretty printer for AST.
5. **UnitTests.cs**: Unit tests for lexing the abstract syntax tree.

Let's break down the solution into steps:

1. **Initialize a new Solution in Visual Studio**:
   - Create a new Class Library project targeting .NET 9.0.
   - Ensure it is usable in Visual Studio 2022.
   - Name the solution `PythonLexer`.

2. **Project Structure**:
   - Define separate files for each class, interface, enumeration, and record.

3. **Code Implementation**:

### Step 1: Define the Project Structure

Create a new .NET 9.0 Solution in Visual Studio 2022 named `PythonLexer`.

### Step 2: Define the Classes, Interfaces, Enumerations, and Records

#### Lexer.cs