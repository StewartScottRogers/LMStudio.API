using Microsoft.VisualBasic;
using System;

[Serializable]
public class Token
{
    public Token(Type tokenType, string value)
    {
        Type = tokenType;
        Value = value;
    }

    public Type Type { get; set; }
    public string Value { get; set; }
}