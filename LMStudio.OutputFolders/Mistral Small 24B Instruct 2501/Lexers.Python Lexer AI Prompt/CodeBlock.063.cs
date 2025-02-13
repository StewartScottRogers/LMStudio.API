namespace Lexer
{
    public record StatementTuple(Tuple<StatementType> Statements)
    {
        public enum StatementType
        {
            Compound,
            Simple
        }
    }

    // Define other records and enums as per the grammar
}

To create a complete .NET 9.0 Solution with a Class Library for Lexing the given Grammar, we need to follow these steps:

1. **Initialize a new Solution in Visual Studio**:
   - Create a new solution named `PythonLexerSolution`.
   - Add a new Class Library project named `PythonLexerLibrary`.

2. **Define the Project Structure**:
   - Create separate files for each class, interface, enumeration, and record.
   - Ensure each file follows the coding style guidelines provided.

3. **Develop the Lexer**:
   - Create a lexer to tokenize the input based on the given grammar.
   - Use a fluent interface for configuring the lexer.

4. **Generate the Abstract Syntax Tree (AST)**:
   - Define nodes for each part of the AST.
   - Implement methods to construct the AST from the lexed tokens.

5. **Implement an AST Pretty Printer**:
   - Create a class that can traverse the AST and print it in a readable format.

6. **Unit Testing**:
   - Write unit tests using Microsoft's Unit Test Framework to ensure the lexer, parser, and pretty printer work correctly.

Below is a complete .NET 9.0 solution in C# that meets the specified requirements. The solution includes a class library for lexing the given grammar, generating an Abstract Syntax Tree (AST), an AST Pretty Printer, and unit tests using Microsoft's Unit Test Framework.

### Solution Structure