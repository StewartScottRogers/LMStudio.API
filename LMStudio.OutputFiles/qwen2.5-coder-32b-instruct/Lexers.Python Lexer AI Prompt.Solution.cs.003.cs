using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PythonLexer
{
    public class Lexer
    {
        private readonly TextReader reader;
        private char currentChar;
        private int position = 0;
        private int lineNumber = 1;
        private int columnNumber = 0;

        public Lexer(TextReader reader)
        {
            this.reader = reader;
            NextChar();
        }

        private void NextChar()
        {
            if (currentChar == '\n')
            {
                lineNumber++;
                columnNumber = 0;
            }
            else
            {
                columnNumber++;
            }

            currentChar = (char)reader.Read();
            position++;
        }

        public IEnumerable<Token> Tokenize()
        {
            while (true)
            {
                if (currentChar == '\0')
                    break;

                switch (currentChar)
                {
                    case ' ':
                    case '\t':
                        NextChar();
                        continue;
                    // ... handle other tokens
                }
            }

            yield return new Token(TokenType.EndMarker, string.Empty);
        }
    }
}