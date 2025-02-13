using System;
using System.Collections.Generic;

public abstract class AstNode
{
    public AstNode()
    {
    }

    public virtual void PrettyPrint(int indentLevel)
    {
        Console.WriteLine(new string(' ', indentLevel * 4));
    }
}