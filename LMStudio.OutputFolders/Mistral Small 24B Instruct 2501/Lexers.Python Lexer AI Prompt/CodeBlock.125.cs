using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    public abstract class Statement
    {
        // Common properties and methods for statements can be defined here.
    }

    public class CompoundStmt : Statement
    {
        public List<Statement> Statements { get; set; }
    }

    public class SimpleStmts : Statement
    {
        public List<SimpleStmt> Statements { get; set; }
    }

    public class SimpleStmt : Statement
    {
        // This can be one of the simple statements like assignment, return_stmt, etc.
    }