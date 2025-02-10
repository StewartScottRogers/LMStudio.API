using System;
using System.Collections.Generic;
using System.Linq;

public record Token<T> 
{
    public T Value { get; }
    public int Position { get; }
}

public enum TokenTypes
{
    Identifier,
    Number,
    String,
    Constant,
    Label,
    Function,
    Variable,
    Operator,
    Keyword,
    EndOfInput
}