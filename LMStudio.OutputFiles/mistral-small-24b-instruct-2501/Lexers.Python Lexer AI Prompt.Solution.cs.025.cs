using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexerGrammar
{
    public enum StatementType
    {
        Compound,
        Simple
    }

    public abstract class Statement
    {
        public readonly string Text;
        public readonly StatementType Type;

        protected Statement(string text, StatementType type)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Type = type;
        }
    }

### File Structure

1. **Lexer.cs**
2. **AstNode.cs**
3. **AbstractSyntaxTree.cs**
4. **AstPrettyPrinter.cs**
5. **UnitTests.cs**

### Lexer.cs