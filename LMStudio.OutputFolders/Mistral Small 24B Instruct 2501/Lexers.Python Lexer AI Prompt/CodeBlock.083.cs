using System;
using System.Collections.Generic;

public class Lexer
{
    private readonly string input;
    private int position;
    private char currentCharacter;

    public Lexer(string input)
    {
        this.input = input;
        this.position = 0;
        this.currentCharacter = input[position];
    }

    public void Advance()
    {
        if (this.position < input.Length - 1)
        {
            this.position++;
            this.currentCharacter = input[this.position];
        }
        else
        {
            this.currentCharacter = '\0';
        }
    }

Let's break down the solution steps to create a .NET 9.0 Solution for the described Lexer and Abstract Syntax Tree (AST) pretty printer:

### Step-by-Step Solution

1. **Initialize a New Solution in Visual Studio**:
   - Create a new Class Library project.
   - Name the project `PythonLexerLibrary`.

2. **Define the Project Structure**:
   - Ensure each class, interface, enumeration, and record is in its own file.

3. **Develop the Lexer**:
   - Create a class `PythonLexer` to handle the lexing of Python code based on the provided grammar.

4. **Generate Abstract Syntax Tree (AST) Nodes**:
   - Define classes for each node type in the AST.

5. **Generate an AST Pretty Printer**:
   - Create a class `AstPrettyPrinter` that can print the AST nodes in a readable format.

6. **Unit Tests**:
   - Write unit tests to ensure the lexer, AST generation, and pretty printing work correctly.

Below is the structure of the .NET 9.0 Solution with the specified requirements. This solution includes the lexer, abstract syntax tree (AST) nodes, AST pretty printer, and unit tests.

### File System Structure