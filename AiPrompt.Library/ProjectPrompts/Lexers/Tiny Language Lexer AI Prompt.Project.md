
# Application Description

	- Create a Class Library to Lexer the Grammar listed below.

	- Generate a Lexer for the Abstract Syntax Tree.
	- Generate a Abstract Syntax Tree Pretty Printer.
	- Generate all nodes in the Abstract Syntaxes Tree.
	- Generate 25 Unit Tests for lexing the Abstract Syntax Tree.


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