﻿# iny Language Lexer AI Prompt
------------------------------------------------------------------------------------------------------------------------
- **.NET Version Requirements**: 
  - Create a complete .NET 9.0 Solution
  - All solution coding will be C#. 
  - Solution must be usable in Visual Studio 2022
  - Ensure the solution is fully compilable and executable without additional coding.
  - Do not use ImplicitUsings.
  - Do not use Nullable.

- **Coding Style**:
	- Never use leading underscores for any variable.
	- Use only explicit types.
	- Local variables should use lowerCamelCase.
	- Member variables should use UpperCamelCase.
	- Class properties should use UpperCamelCase.
	- Class names should use UpperCamelCase.
	- Interface names should use UpperCamelCase.
	- Enumeration names should use UpperCamelCase.
	- Record names should use UpperCamelCase.
	- Struct names should use UpperCamelCase.
	- Method names should use UpperCamelCase.
	- All Tuples should be named from the returning method.
	- All Tuples must be Post Fixed with the word 'Tuple'.
	- All Tuples must use a var type.
	- use a readonly on all variables whenever possible.
	- Local Variables should be named with complete nouns, appending a prefix or postfix for clarification if required.
	- Member Variables should be named with complete nouns, appending a prefix or postfix for clarification if required.
	- Properties should be named with complete nouns, appending a prefix or postfix for clarification if required.
	- Methods should be named with complete nouns, appending a prefix or postfix for clarification if required.
	- Classes should be named with complete nouns, appending a prefix or postfix for clarification if required.
	- Interfaces should be named with complete nouns, appending a prefix or postfix for clarification if required.
	- Structs should be named with complete nouns, appending a prefix or postfix for clarification if required.

- **Library Usage**:
	- Use only the Microsoft Basic Component Library.
	- Use defined value types from the Basic Component Library.
	- Use defined reference types from the Basic Component Library.

- **Programming Constructs**:
	- Favor use of Tuples for returning multiple values from a method rather than Data Transport Objects, Structs, Or Records
	- Use var types for Tuples.
	- Favor Records over Classes.

- **File System Structure**: 
	- Create separate files for each class.
	- Create separate files for each interface.
	- Create separate files for each enumeration.
	- Create separate files for each record.

 - **Code Documentation**: 
	- Add comments to explain complex code structures or logic in a way accessible to business analysts or entry-level programmers.

- **Unit Testing**: 
	- Use only the Microsoft Unit Test Framework.
	- Do not use XUnit or NUnit.
	- Unit Test all bounding conditions


------------------------------------------------------------------------------------------------------------------------

# Application Description

Create a Class Library to Lexer the Grammar listed below.

Generate a Lexer for the Abstract Syntax Tree.
Generate a Abstract Syntax Tree Pretty Printer.
Generate all nodes in the Abstract Syntaxes Tree.
Generate 25 Unit Tests for lexing the Abstract Syntax Tree.


Grammar:
```
	<program> ::= <stmt_list>
	<stmt_list> ::= <stmt> | <stmt> ";" <stmt_list>
	<stmt> ::= <assign_stmt> | <if_stmt> | <while_stmt> | <print_stmt>
	<assign_stmt> ::= <id> ":=" <expr>
	<if_stmt> ::= "if" <expr> "then" <stmt_list> "end"
	<while_stmt> ::= "while" <expr> "do" <stmt_list> "end"
	<print_stmt> ::= "print" <expr>
	<expr> ::= <term> | <term> "+" <expr> | <term> "-" <expr>
	<term> ::= <factor> | <factor> "*" <term> | <factor> "/" <term>
	<factor> ::= <id> | <number> | "(" <expr> ")"
	<id> ::= <letter> { <letter> | <digit> }
	<number> ::= <digit> { <digit> }
	<letter> ::= "a" | "b" | "c" | ... | "z" | "A" | "B" | "C" | ... | "Z"
	<digit> ::= "0" | "1" | "2" | "3" | "4" | "5" | "6" | "7" | "8" | "9"
```
