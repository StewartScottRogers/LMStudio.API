[TestClass]
    public class CodeAnalyzerTests 
    {
        private readonly CodeAnalyzer _analyzer;

        public CodeAnalyzerTests() 
        {
            _analyzer = new CodeAnalyzer();
        }
        
        [TestMethod]
        public void AnalyzeCode_ValidInput_ShouldReturnAstAndNoDiagnostics() 
        {
            // Arrange
            var validCode = @"class Program { }";

            // Act
            var result = _analyzer.AnalyzeCode(validCode);
            
            // Assert
            Assert.IsNotNull(result.Item1);
            Assert.IsFalse(result.Item2.Any());
        }
    }