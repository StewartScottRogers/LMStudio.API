using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PythonLexer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Python Lexer and AST Pretty Printer");
            // Entry point for the application
            // You can add more code here to test the lexer and pretty printer
        }

To create a .NET 9.0 Solution that meets all the specified requirements, we need to follow these steps:

1. **Initialize a new Solution in Visual Studio.**
2. **Define the project structure ensuring each class, interface, enumeration, and record is in its own file.**
3. **Develop unit tests using Microsoft's Unit Test Framework.**
4. **Include comprehensive comments for any non-trivial logic or structure to enhance understanding.**

Here's a step-by-step implementation of the solution:

### Step 1: Initialize a new Solution in Visual Studio

Create a new .NET 9.0 Class Library project in Visual Studio 2022.

### Step 2: Define the Project Structure

Create separate files for each class, interface, enumeration, and record as per the given coding style guidelines.

### Step 3: Implement the Lexer

We will start by defining the necessary classes and records to represent the tokens and nodes in the Abstract Syntax Tree (AST).

#### File: Token.cs