using AiPrompt.Library.ProjectPrompts;
using AiPrompts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AiPrompt.Library
{
    [TestClass]
    public sealed class GetAllEmbeddedPrompts
    {
        [TestMethod]
        public void GetAllDirectivesPathsUnitTest()
        {

            IEnumerable<string> embeddedPrompts
                = EmbeddedPrompts.GetAllPaths("Directives.txt");

            foreach (string embeddedPrompt in embeddedPrompts)
            {
                Console.WriteLine(embeddedPrompt);
                Assert.IsTrue(embeddedPrompt.EndsWith(".txt"));
            }
        }

        [TestMethod]
        public void GetAllProjectPathsUnitTest()
        {

            IEnumerable<string> embeddedPrompts
                = EmbeddedPrompts.GetAllPaths("Project.txt");

            foreach (string embeddedPrompt in embeddedPrompts)
            {
                Console.WriteLine(embeddedPrompt);
                Assert.IsTrue(embeddedPrompt.EndsWith(".txt"));
            }
        }

        [TestMethod]
        public void GetAllDirectivesPromptContentUnitTest()
        {

            string prompt =
                PromptCompositionBuilder.CreateDirectivesPrompt();

            Console.WriteLine(prompt);

            Assert.IsTrue(prompt.Length > 0);
        }


        [TestMethod]
        public void GetAllProjectPromptContentUnitTest()
        {
            IEnumerable<string> embeddedPrompts
                = EmbeddedPrompts.GetAllPaths("Project.txt");

            foreach (string embeddedPrompt in embeddedPrompts)
            {
                Debug.WriteLine(embeddedPrompt);
                string prompt = EmbeddedPrompts.GetPrompt(embeddedPrompt);
                Console.WriteLine(prompt);
                Assert.IsTrue(prompt.Length > 0);
            }
        }
    }
}
