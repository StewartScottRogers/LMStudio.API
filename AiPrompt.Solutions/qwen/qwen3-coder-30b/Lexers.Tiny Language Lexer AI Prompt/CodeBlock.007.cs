using System;
using System.Collections.Generic;

namespace LexerLibrary
{
    /// <summary>
    /// Recursive descent parser for the given grammar.
    /// </summary>
    public class Parser
    {
        private readonly Lexer Lexer;
        private (TokenType TokenType, string Value) CurrentTokenTuple;

        /// <summary>
        /// Initializes a new instance of the Parser class with the given lexer.
        /// </summary>
        /// <param name="lexer">The lexer to use for tokenizing input.</param>
        public Parser(Lexer lexer)
        {
            Lexer = lexer;
            CurrentTokenTuple = lexer.NextTokenTuple();
        }

        /// <summary>
        /// Parses a program and returns the root AST node.
        /// </summary>
        /// <returns>The root ProgramNode of the parsed AST.</returns>
        public ProgramNode ParseProgram()
        {
            var statementList = ParseStatementList();
            return new ProgramNode(statementList);
        }

        /// <summary>
        /// Parses a list of statements.
        /// </summary>
        /// <returns>A list of AST nodes representing statements.</returns>
        private List<AstNode> ParseStatementList()
        {
            var statements = new List<AstNode>();
            
            while (CurrentTokenTuple.TokenType != TokenType.Eof && 
                   CurrentTokenTuple.TokenType != TokenType.End)
            {
                var statement = ParseStatement();
                statements.Add(statement);
                
                // Check for semicolon separator
                if (CurrentTokenTuple.TokenType == TokenType.Semicolon)
                {
                    CurrentTokenTuple = Lexer.NextTokenTuple();
                }
                else
                {
                    break;
                }
            }
            
            return statements;
        }

        /// <summary>
        /// Parses a single statement.
        /// </summary>
        /// <returns>An AST node representing the statement.</returns>
        private AstNode ParseStatement()
        {
            return CurrentTokenTuple.TokenType switch
            {
                TokenType.Identifier => ParseAssignmentStatement(),
                TokenType.If => ParseIfStatement(),
                TokenType.While => ParseWhileStatement(),
                TokenType.Print => ParsePrintStatement(),
                _ => throw new InvalidOperationException($"Unexpected token: {CurrentTokenTuple.TokenType}")
            };
        }

        /// <summary>
        /// Parses an assignment statement.
        /// </summary>
        /// <returns>An AST node representing the assignment.</returns>
        private AstNode ParseAssignmentStatement()
        {
            var identifier = CurrentTokenTuple.Value;
            CurrentTokenTuple = Lexer.NextTokenTuple();
            
            if (CurrentTokenTuple.TokenType != TokenType.Assign)
            {
                throw new InvalidOperationException("Expected := in assignment statement");
            }
            
            CurrentTokenTuple = Lexer.NextTokenTuple();
            var expression = ParseExpression();
            
            return new StatementNode
            {
                LineNumber = 0,
                StatementType = StatementType.Assign,
                Expression = expression
            };
        }

        /// <summary>
        /// Parses an if statement.
        /// </summary>
        /// <returns>An AST node representing the if statement.</returns>
        private AstNode ParseIfStatement()
        {
            CurrentTokenTuple = Lexer.NextTokenTuple(); // Skip "if"
            var condition = ParseExpression();
            
            if (CurrentTokenTuple.TokenType != TokenType.Then)
            {
                throw new InvalidOperationException("Expected 'then' in if statement");
            }
            
            CurrentTokenTuple = Lexer.NextTokenTuple();
            var statements = ParseStatementList();
            
            if (CurrentTokenTuple.TokenType != TokenType.End)
            {
                throw new InvalidOperationException("Expected 'end' in if statement");
            }
            
            CurrentTokenTuple = Lexer.NextTokenTuple(); // Skip "end"
            
            return new StatementNode
            {
                LineNumber = 0,
                StatementType = StatementType.If,
                Expression = condition,
                StatementList = statements
            };
        }

        /// <summary>
        /// Parses a while statement.
        /// </summary>
        /// <returns>An AST node representing the while statement.</returns>
        private AstNode ParseWhileStatement()
        {
            CurrentTokenTuple = Lexer.NextTokenTuple(); // Skip "while"
            var condition = ParseExpression();
            
            if (CurrentTokenTuple.TokenType != TokenType.Do)
            {
                throw new InvalidOperationException("Expected 'do' in while statement");
            }
            
            CurrentTokenTuple = Lexer.NextTokenTuple();
            var statements = ParseStatementList();
            
            if (CurrentTokenTuple.TokenType != TokenType.End)
            {
                throw new InvalidOperationException("Expected 'end' in while statement");
            }
            
            CurrentTokenTuple = Lexer.NextTokenTuple(); // Skip "end"
            
            return new StatementNode
            {
                LineNumber = 0,
                StatementType = StatementType.While,
                Expression = condition,
                StatementList = statements
            };
        }

        /// <summary>
        /// Parses a print statement.
        /// </summary>
        /// <returns>An AST node representing the print statement.</returns>
        private AstNode ParsePrintStatement()
        {
            CurrentTokenTuple = Lexer.NextTokenTuple(); // Skip "print"
            var expression = ParseExpression();
            
            return new StatementNode
            {
                LineNumber = 0,
                StatementType = StatementType.Print,
                Expression = expression
            };
        }

        /// <summary>
        /// Parses an expression.
        /// </summary>
        /// <returns>An AST node representing the expression.</returns>
        private AstNode ParseExpression()
        {
            var left = ParseTerm();
            
            if (CurrentTokenTuple.TokenType == TokenType.Plus || 
                CurrentTokenTuple.TokenType == TokenType.Minus)
            {
                var op = CurrentTokenTuple.TokenType;
                CurrentTokenTuple = Lexer.NextTokenTuple();
                var right = ParseExpression();
                
                return new ExpressionNode
                {
                    LineNumber = 0,
                    ExpressionType = op == TokenType.Plus ? ExpressionType.Addition : ExpressionType.Subtraction,
                    LeftOperand = left,
                    RightOperand = right
                };
            }
            
            return left;
        }

        /// <summary>
        /// Parses a term.
        /// </summary>
        /// <returns>An AST node representing the term.</returns>
        private AstNode ParseTerm()
        {
            var left = ParseFactor();
            
            if (CurrentTokenTuple.TokenType == TokenType.Multiply || 
                CurrentTokenTuple.TokenType == TokenType.Divide)
            {
                var op = CurrentTokenTuple.TokenType;
                CurrentTokenTuple = Lexer.NextTokenTuple();
                var right = ParseTerm();
                
                return new ExpressionNode
                {
                    LineNumber = 0,
                    ExpressionType = op == TokenType.Multiply ? ExpressionType.Multiplication : ExpressionType.Division,
                    LeftOperand = left,
                    RightOperand = right
                };
            }
            
            return left;
        }

        /// <summary>
        /// Parses a factor.
        /// </summary>
        /// <returns>An AST node representing the factor.</returns>
        private AstNode ParseFactor()
        {
            return CurrentTokenTuple.TokenType switch
            {
                TokenType.Identifier => new ExpressionNode
                {
                    LineNumber = 0,
                    ExpressionType = ExpressionType.Terminal,
                    Value = CurrentTokenTuple.Value
                },
                TokenType.Number => new ExpressionNode
                {
                    LineNumber = 0,
                    ExpressionType = ExpressionType.Terminal,
                    Value = CurrentTokenTuple.Value
                },
                TokenType.LeftParen => ParseParenthesizedExpression(),
                _ => throw new InvalidOperationException($"Unexpected token in factor: {CurrentTokenTuple.TokenType}")
            };
        }

        /// <summary>
        /// Parses a parenthesized expression.
        /// </summary>
        /// <returns>An AST node representing the parenthesized expression.</returns>
        private AstNode ParseParenthesizedExpression()
        {
            CurrentTokenTuple = Lexer.NextTokenTuple(); // Skip '('
            var expression = ParseExpression();
            
            if (CurrentTokenTuple.TokenType != TokenType.RightParen)
            {
                throw new InvalidOperationException("Expected ')' in parenthesized expression");
            }
            
            CurrentTokenTuple = Lexer.NextTokenTuple(); // Skip ')'
            
            return expression;
        }
    }
}