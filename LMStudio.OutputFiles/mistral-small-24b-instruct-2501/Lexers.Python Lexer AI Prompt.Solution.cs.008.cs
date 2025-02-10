using System;

namespace LexerLibrary
{
    /// <summary>
    /// Represents the root node of an Abstract Syntax Tree (AST).
    /// </summary>
    public sealed class AbstractSyntaxTree : Record
    {
        private readonly Node RootNode;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractSyntaxTree"/> class.
        /// </summary>
        /// <param name="rootNode">The root node of the AST.</param>
        public AbstractSyntaxTree(ReadOnlyCollection<Node> rootNode)
        {
            RootNode = rootNode;
        }

        private readonly ReadOnlyCollection<Node> RootNode;

        // The PrettyPrinter class will handle printing the AST in a readable format.
        internal static class PrettyPrinter
        {
            public static void Print(StreamWriter writer, Node node)
            {
                if (node is Statement statement)
                {
                    writer.WriteLine(statement.ToString());
                }
                else if (node is Expression expression)
                {
                    writer.WriteLine(expression.ToString());
                }
                // Add other node types as needed
            }
        }

        // Helper methods for pretty-printing specific nodes can be added here

    }

    public enum TokenType
    {
        Identifier,
        Keyword,
        Operator,
        Literal,
        Punctuation,
        Whitespace,
        Newline,
        EndMarker
    }

    public record Token (TokenType Type, string Value);

    public class Lexer
    {
        private readonly string input;
        private int position;

        public Lexer(string input)
        {
            this.input = input;
            this.position = 0;
        }

        public IEnumerable<Token> Lex()
        {
            while (this.position < this.input.Length)
            {
                if (char.IsWhiteSpace(this.input[this.position]))
                {
                    this.SkipWhitespace();
                }
                else
                {
                    var token = this.ReadToken();
                    yield return token;
                }
            }
        }

To create a Lexer for the given grammar and an Abstract Syntax Tree (AST) Pretty Printer, we need to follow these steps:

1. **Initialize a new Solution in Visual Studio.**
2. **Create separate files for each class, interface, enumeration, and record.**
3. **Develop the lexer and AST nodes based on the provided grammar.**
4. **Implement the AST pretty printer.**
5. **Write unit tests using Microsoft's Unit Test Framework.**

Below is a solution that adheres to the given specifications. The solution includes the lexer, AST nodes, pretty printer, and unit tests.

### Solution Structure

1. **Lexer Library**
   - `Lexer.cs`
   - `Token.cs`

2. **Abstract Syntax Tree (AST) Nodes**
   - Each node type in its own file (e.g., `StatementNode.cs`, `AssignmentNode.cs`, etc.)

3. **Pretty Printer for AST**
   - `AstPrinter.cs`

4. **Unit Tests**
   - `LexerTests.cs` with at least 25 unit tests.

Let's start by setting up the project structure and then implementing each component step-by-step.

### Project Structure