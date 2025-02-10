// TokenDefinitions.cs
using System;

public enum TokenType
{
    // Keywords
    Name,
    Number,
    StringLiteral,
    Comment,
    EndMarker,

    // Operators
    Plus, Minus, Star, Slash, DoubleStar, At, Percent,
    DoubleSlash, Ampersand, Pipe, Caret, LeftShift,
    RightShift, Equal, NotEqual, LessThanOrEqual,
    GreaterThanOrEqual, LessThan, GreaterThan, In,
    Is, IsNot, NotIn, AssignmentExpression,

# Project Structure

Let's create the project structure based on the given requirements.