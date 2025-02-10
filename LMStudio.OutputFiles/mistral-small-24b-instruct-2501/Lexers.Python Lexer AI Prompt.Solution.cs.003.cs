using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public readonly record class Statements(List<Statement> StatementList)
    {
        public Statements(Tuple<Statement, Statements> tuple) : this(new List<Statement>(tuple.StatementList))
        {
            var statements = new List<Statement>();
            Statements.Append(statements);
            var statementTuple = tuple;
            while (statementTuple != null)
            {
                statements.Add(statementTuple.Statement);
                statementTuple = statementTuple.Statements;
            }
            return statements;
        }

        private static void Append(List<Statement> statements, Statement statement)
        {
            if (statements == null)
            {
                throw new ArgumentNullException(nameof(statements));
            }

            if (statement == null)
            {
                throw new ArgumentNullException(nameof(statement));
            }

            statements.Add(statement);
    }

    public void AddStatement(ReadOnlyCollection<Statement> statements)
    {
        if (statements == null)
        {
            throw new ArgumentNullException(nameof(statements), "Statements cannot be null.");
        }

        foreach (var statement in statements)
        {
            this.statements.Add(statement);
        }
    }


### Solution Structure

The solution will include the following projects and files:

1. **LexerLibrary**
   - `ClassDefNode.cs`
   - `CompoundStmtNode.cs`
   - `FunctionDefNode.cs`
   - `ImportNameNode.cs`
   - `ImportFromNode.cs`
   - `IfStmtNode.cs`
   - `StatementNode.cs`
   - `SyntaxTreeBuilder.cs` (The Lexer class)
   - `SyntaxTreePrettyPrinter.cs` (The Pretty Printer class)
   - `TestLexer.cs` (Unit Tests)

Here's a step-by-step guide to creating the solution as per your requirements:

### Step 1: Initialize the Solution

1. Open Visual Studio 2022.
2. Create a new `.NET` Class Library project.
3. Name the project `PythonLexer`.

### Step 2: Define the Project Structure

Create separate files for each class, interface, enumeration, and record as follows:

- `Lexer.cs`
- `AstNode.cs`
- `AstPrettyPrinter.cs`
- `TokenType.cs` (Enumeration)
- `Token.cs` (Record)
- `AstNodeType.cs` (Enumeration)

### Lexer.cs