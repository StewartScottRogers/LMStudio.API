# DataStructures: Stack Data Structure AI Prompt
------------------------------------------------------------------------------------------------------------------------
- **.NET Versioning**: 
  - Create a complete .NET 9.0 Solution
  - All solution coding will be C#. 
  - Solution must be usable in Visual Studio 2022
  - Ensure the solution is fully compilable and executable without additional coding.


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



- **Library Usage**:
	- Use only the Microsoft Basic Component Library.
	- Use defined value types from the Basic Component Library.
	- Use defined reference types from the Basic Component Library.
	- Use var types for Tuples.
	- Favor Records over Classes.

- **Programming Constructs**:
	- Utilize Fluent Interfaces wherever possible.
	- Implement LINQ where applicable.
	- Prefer 'foreach' statements instead of 'for' loops.
	- Use streams for all input/output operations.
	- Favor use of Tuples for returning multiple values from a method rather than Data Transport Objects, Structs, Or Records

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
	- Include many Unit tests for every entry point in Tested code.
	- Unit Test all bounding conditions
	- Write three times as many Unit tests as you thought you should.

- **Solution Steps**
	- Initialize a new Solution in Visual Studio.
	- Include comprehensive comments for any non-trivial logic or structure to enhance understanding.
	- Define the project structure ensuring each class, interface, enumeration, and record is in its own file.
	- Develop unit tests using Microsoft's Unit Test Framework.
	- include a .README or documentation summarizing the project and key points of logic for easy comprehension.
	- Rethink the solution steps multiple times to make sure it is as correct as possible
	- Think Harder.


------------------------------------------------------------------------------------------------------------------------

# Application Description	

	- Create a C# library that implements a stack data structure with push and pop operations.
	- Push: Add an element to the top of a stack.
	- Pop: Remove an element from the top of a stack.
	- IsEmpty: Check if the stack is empty.
	- IsFull: Check if the stack is full.
	- Peek: Get the value of the top element without removing it.

