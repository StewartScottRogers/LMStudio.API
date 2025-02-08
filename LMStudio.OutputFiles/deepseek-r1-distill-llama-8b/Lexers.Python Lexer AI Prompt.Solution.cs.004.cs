using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PythonLexer.Tests
{
    [TestClass]
    public class LexerTests
    {
        private readonly Tokenizer tokenizer = new Tokenizer(@"#comment\ndef foo: bar = 42");

        private List<Token> tokens;

        [TestInitialize]
        public void Initialize()
        {
            tokens = tokenizer.Tokens;
        }

        [TestMethod]
        public void TestTokenization()
        {
            Assert.AreEqual(8, tokens.Count);
            
            var expectedTokens = new List<Tuple<string, string>>
            {
                Tuple.Create("def", "def"),
                Tuple.Create("Identifier", "foo"),
                Tuple.Create("Colon", ":"),
                Tuple.Create("Space", " "),
                Tuple.Create("AssignOp", "="),
                Tuple.Create("Space", " "),
                Tuple.Create("Number", "42")
            };

            foreach (var expected in expectedTokens)
                Assert.AreEqual(expected.Item1, tokens.Find(t => t.Type == expected.Item1 && t.Value == expected.Item2));
        }
    }
}