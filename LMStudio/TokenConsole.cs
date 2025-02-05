using System;
using System.Linq;

namespace LMStudio
{
    public class TokenConsole : IDisposable
    {
        private long index = 0;
        private readonly ConsoleColor DefaultBackgroundColor;
        private readonly ConsoleColor OddBackgroundColor;
        private readonly ConsoleColor EvenBackgroundColor;

        public TokenConsole(ConsoleColor defaultBackgroundColor, ConsoleColor oddBackgroundColor = ConsoleColor.DarkGreen, ConsoleColor evenBackgroundColor = ConsoleColor.DarkBlue)
        {
            index = 0;
            DefaultBackgroundColor = defaultBackgroundColor;
            OddBackgroundColor = oddBackgroundColor;
            EvenBackgroundColor = evenBackgroundColor;
        }

        public void ProcessToken(string token)
        {
            string strippedToken = RemoveTrailingNewlines(token);
            if (strippedToken.Count() < token.Count())
            {
                WriteColerizedToken(strippedToken);

                int trailingNewLineLength = token.Length - strippedToken.Length;
                string newLines = new string('\n', trailingNewLineLength);
                Console.BackgroundColor = DefaultBackgroundColor;
                Console.Write(newLines);
            }
            else
            {
                WriteColerizedToken(token);
            }

            index++;
        }

        private string RemoveTrailingNewlines(string token)
        {
            while (token.EndsWith("\n"))
                return RemoveTrailingNewlines(token.Substring(0, token.Length - 1));
            return token;
        }

        private void WriteColerizedToken(string token)
        {
            bool oddNumber = (index % 2 == 0);
            if (oddNumber)
                Console.BackgroundColor = OddBackgroundColor;
            else
                Console.BackgroundColor = EvenBackgroundColor;
            Console.Write(token);
        }

        public void Dispose()
        {
            Console.BackgroundColor = DefaultBackgroundColor;
        }
    }
}
