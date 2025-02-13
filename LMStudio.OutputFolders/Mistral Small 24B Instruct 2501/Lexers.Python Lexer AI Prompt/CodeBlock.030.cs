using System;
using System.Collections.Generic;

namespace PythonLexer
{
    public abstract class AstNode
    {
        protected List<AstNode> Children = new();

        public virtual void AddChild(AstNode node)
        {
            Children.Add(node);
        }

        public override string ToString()
        {
            return base.ToString() + " [" + GetType().Name + "]";
        }
    }
}