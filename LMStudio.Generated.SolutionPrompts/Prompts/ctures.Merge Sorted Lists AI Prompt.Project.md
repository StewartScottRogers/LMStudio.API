# ctures: Merge Sorted Lists AI Prompt
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

	- Create an in-memory library that Merges sorted lists of integers. 
	- The library should provide a method that takes N sorted lists of generics and returns a single sorted list of integers that contains all elements from the input lists. The output list should not contain any duplicates.
	- The library should be able to handle large lists efficiently.
	- The library should be able to handle a large number of input lists.
	- The library should be able to handle a large number of elements in the input lists.
	- The library should be able to handle null or empty input lists.
	- The library should be made available as a fluent interface to allow for easy chaining of operations.
	- The library should be well-documented with comments explaining the logic and structure of the code.
	- The library should be comparable with LINQ and other standard C# libraries.
