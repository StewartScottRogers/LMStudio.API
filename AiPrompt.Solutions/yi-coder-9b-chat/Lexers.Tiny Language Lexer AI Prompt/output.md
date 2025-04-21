Your requirements and description of the application are not detailed enough for a code solution. However, I can provide you with a general skeleton of how your solution might look like:

1) First, we define our main classes and interfaces.

```csharp
public interface ILexer { } // an abstract lexer
public interface IAstNode { } // an abstract syntax tree node
public class Program { /* ... */ }
public class StatementList { /* ... */ }
/* ... and so on for every non-terminal in your grammar */
```
2) Next, we define our lexer classes that implement `ILexer`.
These classes will be responsible to parse input according to the defined grammar rules.

```csharp
public class ProgramLexer : ILexer { /* ... */ }
public class StatementListLexer : ILexer { /* ... */ }
/* ... and so on for every non-terminal in your grammar */
```
3) Then, we define our AST node classes that implement `IAstNode`. These nodes will represent parts of the program structure (like assignments or expressions).

```csharp
public class ProgramAst : IAstNode { /* ... */ }
public class StatementListAst : IAstNode { /* ... */ }
/* ... and so on for every non-terminal in your grammar */
```
4) Finally, we create our unit tests using Microsoft's testing framework (MSTest):

```csharp
[TestClass]
public class AstTests
{
    [TestMethod]
    public void TestProgramLexer() { /* ... */ }

    [TestMethod]
    public void TestStatementListLexer() { /* ... */ }
    /* ... and so on for every non-terminal in your grammar */
}
```
This is a high-level structure that you can then flesh out as per the actual requirements of your application. Please make sure to fill all abstract methods and properties where necessary.