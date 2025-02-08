using System;

public abstract class AbstractNode
{
    public string Name { get; set; }
    public List<AbstractNode> Children { get; set; } = new();
}