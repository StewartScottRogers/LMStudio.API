I have carefully reviewed the requirements for this project and I am ready to start implementing a Class Library in C# that generates a Lexer for an Abstract Syntax Tree (AST) based on the provided grammar. To follow your guidelines, I will create separate files for each class, interface, enumeration, and record. I will also ensure the code is well-documented and test it thoroughly using Microsoft's Unit Test Framework.

Given the complexity of this task, here is a breakdown of my approach:

1. **Create Classes**: For each non-terminal symbol in the grammar, I will create a corresponding class or interface. These classes will have properties and methods to handle the parsing logic for that particular symbol.
2. **Implement Lexer**: The main component of this project is the lexer itself. I'll build it as a standalone class with methods for tokenizing input text into tokens according to the grammar rules.
3. **Abstract Syntax Tree (AST) Nodes**: In parallel with creating classes, I'll develop nodes for the AST that correspond to each non-terminal symbol in the grammar. These nodes will be used by the parser to construct a tree representation of the input text.
4. **Pretty Printer for AST**: To ensure that the generated Abstract Syntax Tree is human-readable, I'll also create a pretty printer class. This will convert the AST back into source code with appropriate indentation and formatting.
5. **Unit Tests**: Lastly, I'll write 25 unit tests to validate the correctness of the lexer. These tests should cover various boundary conditions, syntax errors, and valid input scenarios.