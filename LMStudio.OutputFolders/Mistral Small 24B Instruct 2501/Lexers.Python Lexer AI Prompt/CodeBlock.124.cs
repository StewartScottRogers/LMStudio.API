using System;
using System.Collections.Generic;
using System.Linq;

namespace LexerLibrary
{
    public enum TokenType
    {
        // Define token types based on the grammar
        Number,
        Name,
        String,
        Newline,
        Indent,
        Dedent,
        EndMarker,
        Comment,
        // Add other token types as needed
    }

To create a Class Library in C# for lexing the provided grammar, generating an Abstract Syntax Tree (AST), and creating an AST Pretty Printer, we need to follow these steps:

1. **Initialize a New Solution**:
   - Create a new .NET 9.0 solution in Visual Studio 2022.
   - Ensure the solution is fully compilable and executable.

2. **Define Project Structure**:
   - Create separate files for each class, interface, enumeration, and record.
   - Follow the coding style guidelines provided.

3. **Lexer Implementation**:
   - Implement a lexer to tokenize the grammar rules.
   - Generate tokens based on the given grammar.

4. **Abstract Syntax Tree (AST) Generation**:
   - Create nodes for each element in the AST.
   - Implement methods to generate an AST from the tokenized input.

5. **Pretty Printer**:
   - Develop a class to pretty print the AST.

6. **Unit Tests**:
   - Write unit tests using Microsoft's Unit Test Framework to cover various lexing scenarios and edge cases.

Here is a step-by-step guide to creating the solution:

### Step 1: Initialize a New Solution in Visual Studio

1. Open Visual Studio 2022.
2. Create a new Class Library project named `LexerLibrary`.
3. Ensure the target framework is .NET 9.0.

### Step 2: Define Project Structure

Create separate files for each class, interface, enumeration, and record as specified in the grammar.

#### File: `AbstractSyntaxTreeNode.cs`