Based on the given prompt and specifications, let's outline the structure of the solution, followed by a high-level breakdown of the code components we'll create:

### Solution Structure

**Solution Name:** `TinyLexerAndParser`

**Projects:**
1. **`TinyLexer`**: Contains the lexer implementation.
2. **`SyntaxTree`**: Defines Abstract Syntax Tree (AST) nodes and AST processing logic.
3. **`ASTPrettyPrinter`**: Responsible for pretty-printing the AST.
4. **`UnitTests`**: Contains unit tests covering all functionalities.

### Step-by-step Implementation

#### 1. `TinyLexer`

- **Lexer Class (`ILexer`)**:
    - Defines methods: `LexProgram`, `NextToken`.
    - Token types enumeration, e.g., `TokenType { Identifier, Keyword, Operator, Literal }`.

- **Tokenizer Class**:
    - Implements `ILexer` interface.
    - Method `LexProgram` to tokenize a given program string into tokens.

#### 2. `SyntaxTree`

- **AST Node Interfaces/Abstract Classes**:
    - `IASTNode`, `IStatement`, `IExpression`, etc.
    - Concrete classes for each grammar rule (`AssignStmtNode`, `IfStmtNode`, `WhileStmtNode`, `PrintStmtNode`, `ExprNode`, `TermNode`, `FactorNode`).

- **AST Builder Class**:
    - Transforms the sequence of tokens into an AST.

#### 3. `ASTPrettyPrinter`

- **Pretty Printer Class (`ASTPrettyPrinter`)**:
    - Method to visit each AST node and print it in a readable format.
    
#### 4. `UnitTests`

- **Unit Test Classes**:
    - `LexerTest`, `SyntaxTreeTest`, `ASTPrettyPrinterTest`.
    - Test cases include edge cases, invalid inputs, and valid program lexing and parsing.

### Code Snippets

Let's provide some conceptual code snippets for clarity:

#### Lexer (`TinyLexer` Project)

```csharp
public enum TokenType { Identifier, Keyword, Operator, Literal }

public interface ILexer
{
    IEnumerable<Token> LexProgram(string programText);
    Token NextToken();
}

public class Token
{
    public TokenType Type { get; set; }
    // Other properties as needed (e.g., Value for literals)
}

// Example of a simple lexer implementation
public class SimpleLexer : ILexer
{
    public IEnumerable<Token> LexProgram(string programText) => 
        Enumerable.Range(0, programText.Length).Select(index => NextToken());

    private Token NextToken()
    {
        // Pseudo code: implement tokenization logic here.
        throw new NotImplementedException();
    }
}
```

#### Abstract Syntax Tree (`SyntaxTree` Project)

```csharp
public interface IASTNode { }

public abstract class Statement : IASTNode { }
public class AssignStmtNode : Statement { /* fields and methods */ }

// Example AST Node Creation
var assignStatement = new AssignStmtNode() 
{
    Identifier = "x",
    ValueExpression = new ExprNode(/* ... */) // Created elsewhere
};
```

#### Unit Tests (`UnitTests` Project)

```csharp
[TestClass]
public class LexerTest
{
    [TestMethod]
    public void TestLexProgram()
    {
        var lexer = new SimpleLexer();
        var tokens = lexer.LexProgram("x := 5; if x > 3 then print x");

        // Asserts here for the expected token sequence.
    }
}
```

### Documentation

Each class should have clear XML documentation comments describing its purpose, usage, and important methods or properties.

```csharp
/// <summary>
/// Represents a basic token produced by the lexer.
/// </summary>
public class Token
{
    // Implementation details...
}
```

### Compilation and Execution Instructions

- Open Visual Studio 2022 and create a new solution (`TinyLexerAndParser`).
- Add projects as described above.
- Implement each component according to outlined plans.
- Run unit tests to ensure correctness.

This high-level plan provides a blueprint for creating the lexer, AST builder, pretty printer, and accompanying unit tests. Detailed implementation would involve filling in the actual logic (tokenization, AST construction, printing) and adding specific assertions in the test cases based on the expected outcomes for various inputs.

Remember to revisit each step multiple times for thorough testing and refinement. The aim is a robust solution that thoroughly covers all requirements and is well-documented for future maintenance or further enhancements.