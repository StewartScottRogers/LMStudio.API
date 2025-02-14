Below is a skeleton of a .NET Core 9.0 solution that fits your specifications. It includes a Class Library project for the Lexer, an Interface for the AST printer and Pretty Printer, Record types to represent nodes in the Abstract Syntax Tree (AST), and unit tests using MSTest.

Please note, as this is a complex task requiring a detailed understanding of compiler theory, grammar parsing, and specific business logic, only a basic skeleton has been provided here.

**Solution Structure:**

1. LexerProject
    - LexerLibrary
        - Classes
            - ProgramLexer.cs
            - StmtListLexer.cs
            - StmtLexer.cs
            - AssignStmtLexer.cs
            - IfStmtLexer.cs
            - WhileStmtLexer.cs
            - PrintStmtLexer.cs
        - Interfaces
            - IAstPrettyPrinter.cs
            - IAstPrettyPrintVisitor.cs
        - Records
            - IdRecord.cs
            - NumberRecord.cs
            - ExprRecord.cs
            - TermRecord.cs
            - FactorRecord.cs
        - Property
            - Tokens.cs
    - LexerProject.Tests
        - ProgramLexerTest.cs
        - StmtListLexerTest.cs
        - StmtLexerTest.cs
        - AssignStmtLexerTest.cs
        - IfStmtLexerTest.cs
        - WhileStmtLexerTest.cs
        - PrintStmtLexerTest.cs

**Files Content (Skeletons):**

`ProgramLexer.cs`:
```csharp
public class ProgramLexer {
    public Token[] Lex(string input) { /* ... */ }
}
```

`IdRecord.cs`:
```csharp
public record Id(string Value);
```

`IAstPrettyPrinter.cs`:
```csharp
public interface IAstPrettyPrinter {
    string PrettyPrint(IAstNode node);
}
```

`ProgramLexerTest.cs`:
```csharp
[TestClass]
public class ProgramLexerTest {
    [TestMethod]
    public void Lex_ValidInput_ReturnsTokens() { /* ... */ }
}
```

**Comments**: 

- The `LexerLibrary` project contains all classes related to lexing the input string and tokenizing it based on the given grammar.
- The `Records` namespace holds record types for each node in the AST, representing different parts of the grammar.
- `IAstPrettyPrinter` interface is intended for pretty printing the AST. This could be implemented in a separate project or as part of the same project if needed.
- `LexerProject.Tests` contains unit tests for each lexer class using MSTest. Each test method should verify that the lexer can correctly tokenize valid input strings according to the grammar.

This is just a starting point; each class and method will require detailed implementation based on your specific requirements, especially around the lexing logic and AST node construction. Please adapt this skeleton as per your needs.