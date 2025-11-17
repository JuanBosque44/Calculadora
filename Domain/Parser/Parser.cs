using Calculadora.Domain.Entities;
using Calculadora.Domain.Expressions;
using Calculadora.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Calculadora.Domain.Parser
{
    public class Parser
    {
        private readonly Tokenizer _tokenizer = new Tokenizer();

        public IExpression Parse(string input)
        {
            var tokens = _tokenizer.Tokenize(input);
            int position = 0;
            return ParseExpression(tokens, ref position);
        }

        public IExpression Parse(List<Token> tokens)
        {
            int position = 0;
            return ParseExpression(tokens, ref position);
        }

        private IExpression ParseExpression(List<Token> tokens, ref int position)
        {
            var left = ParseTerm(tokens, ref position);

            while (position < tokens.Count &&
                  (tokens[position].Type == TokenType.Plus ||
                   tokens[position].Type == TokenType.Minus))
            {
                var op = tokens[position];
                position++;

                var right = ParseTerm(tokens, ref position);

                if (op.Type == TokenType.Plus)
                    left = new BinaryExpressions(left, right, '+');
                else
                    left = new BinaryExpressions(left, right, '-');
            }

            return left;
        }

        private IExpression ParseTerm(List<Token> tokens, ref int position)
        {
            var left = ParseFactor(tokens, ref position);

            while (position < tokens.Count &&
                  (tokens[position].Type == TokenType.Star ||
                   tokens[position].Type == TokenType.Slash ||
                   tokens[position].Type == TokenType.Percent))
            {
                var op = tokens[position];
                position++;

                var right = ParseFactor(tokens, ref position);

                switch (op.Type)
                {
                    case TokenType.Star:
                        left = new BinaryExpressions(left, right, '*');
                        break;

                    case TokenType.Slash:
                        left = new BinaryExpressions(left, right, '/');
                        break;

                    case TokenType.Percent:
                        left = new BinaryExpressions(left, right, '%');
                        break;
                }
            }

            return left;
        }

        private IExpression ParseFactor(List<Token> tokens, ref int position)
        {
            var token = tokens[position];

            if (token.Type == TokenType.Number)
            {
                position++;
                return new NumberExpression(float.Parse(token.Value));
            }

            if (token.Type == TokenType.LeftParen)
            {
                position++;
                var exp = ParseExpression(tokens, ref position);

                if (tokens[position].Type != TokenType.RightParen)
                    throw new Exception("Missing closing parenthesis");

                position++;
                return exp;
            }

            throw new Exception($"Unexpected token: {token.Type}");
        }
    }
}
