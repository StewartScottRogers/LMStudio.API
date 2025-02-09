public enum TokenType { Identifier, IntegerLiteral, StringLiteral, Keyword, Operator, Delimiter, ... }
  
  public class Token {
      public string Value { get; set; }
      public TokenType Type { get; set; }
      public int LineNumber { get; set; }

      // Constructor and other methods
  }