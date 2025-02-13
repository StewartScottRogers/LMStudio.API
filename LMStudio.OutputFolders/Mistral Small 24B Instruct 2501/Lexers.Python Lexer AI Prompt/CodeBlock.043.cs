using System;
using System.Collections.Generic;

namespace PythonLexerLibrary
{
    public class Lexer
    {
        private readonly string input;
        private int position;
        private List<Token> tokens;

        public Lexer(string input)
        {
            this.input = input;
            this.position = 0;
            this.tokens = new List<Token>();
        }

        public List<Token> Tokenize()
        {
            while (this.position < this.input.Length)
            {
                char currentChar = this.input[this.position];
                if (char.IsWhiteSpace(currentChar))
                {
                    this.position++;
                    continue;
                }

                if (currentChar == '#')
                {
                    // Skip comments
                    while (this.position < input.Length && input[this.position] != '\n')
                    {
                        this.position++;
                    }
                    continue;
                }

                if (char.IsLetter(currentChar) || currentChar == '_')
                {
                    // Handle identifiers (NAME)
                    var identifier = new StringBuilder();
                    while (this.position < input.Length && (char.IsLetterOrDigit(input[this.position]) || input[this.position] == '_'))
                    {
                        identifier.Append(input[this.position]);
                        this.position++;
                    }
                    return new IdentifierToken(identifier.ToString());
                }

The task is to create a .NET 9.0 solution that includes a class library for lexing the given grammar, generating an Abstract Syntax Tree (AST), and providing a pretty printer for the AST. Additionally, you will need to generate unit tests using Microsoft's Unit Test Framework.

### Solution Structure

1. **LexerLibrary**
   - **Lexer.cs**: Contains the Lexer class.
   - **Token.cs**: Defines the Token enumeration.
   - **AbstractSyntaxTree.cs**: Defines the AST nodes.
   - **AstPrettyPrinter.cs**: Pretty Printer for AST.
   - **GrammarRules.cs**: Contains grammar rules.

- **Unit Tests**
  - **LexerTests.cs**

Here is a high-level overview of the solution:

1. **Initialize a new Solution in Visual Studio:**
   - Create a new .NET 9.0 Class Library project.
   - Ensure the project is named appropriately (e.g., `LexerLibrary`).

2. **Define the Project Structure:**
   - Create separate files for each class, interface, enumeration, and record.

3. **Develop the Lexer:**
   - Implement a lexer that can tokenize the given grammar.
   - Use Fluent Interfaces where possible.
   - Utilize LINQ for processing streams of tokens.

4. **Generate Abstract Syntax Tree (AST):**
   - Create an AST representing the parsed statements and expressions.
   - Ensure each node type in the AST is represented by a separate class or record.

5. **Abstract Syntax Tree Pretty Printer:**
   - Develop a pretty printer to convert the AST back into a readable format.

6. **Unit Tests:**
   - Write unit tests covering various scenarios, including boundary conditions and edge cases.

Here is a step-by-step guide to creating the solution:

### Step 1: Initialize a new Solution in Visual Studio
1. Open Visual Studio 2022.
2. Create a new Class Library project named `LexerLibrary`.
3. Ensure the target framework is .NET 9.0.

### Step 2: Define the Project Structure

#### File System Structure: