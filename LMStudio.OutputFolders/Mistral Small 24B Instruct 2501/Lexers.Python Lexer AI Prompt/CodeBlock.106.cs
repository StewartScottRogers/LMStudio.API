using System;
using System.IO;

namespace Lexer
{
    public class AbstractSyntaxTreePrinter : IAbstractSyntaxTreePrinter
    {
        private readonly StreamWriter streamWriter;

        public AbstractSyntaxTreePrinter(Stream outputStream)
        {
            this.streamWriter = new StreamWriter(outputStream);
        }

        public void Print(AbstractSyntaxTreeNode node)
        {
            // Implement the logic to print the Abstract Syntax Tree (AST) node.
            // This is a placeholder for the actual printing logic.

            // Example:
            if (node == null)
                return;

            Console.WriteLine(node.ToString());
        }

To implement this project, we need to create a .NET 9.0 solution with a class library that can lex the given grammar and generate an Abstract Syntax Tree (AST). We will also create a pretty printer for the AST and unit tests using Microsoft's Unit Test Framework.

### Project Structure
1. **LexerLibrary**
   - `Lexer.cs`
   - `AstNode.cs`
   - `AbstractSyntaxTreePrettyPrinter.cs`
   - `UnitTests.cs`

### Step-by-Step Implementation

#### 1. Initialize a new Solution in Visual Studio

Create a new .NET 9.0 Class Library project named `LexerLibrary`.

#### 2. Define the Project Structure

Create separate files for each class, interface, enumeration, and record.

#### 3. Implement the Lexer

Create a lexer class that will tokenize the input based on the given grammar.

#### Token.cs