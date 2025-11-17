using Calculadora.Domain.Entities;
using Calculadora.Domain.Factory;
using Calculadora.Domain.Interfaces;
using Calculadora.Domain.Parser;
using System;
using System.Collections.Generic;


namespace Calculadora.Domain.Engine
{
    internal class CalculatorEngine : ICalculatorEngine
    {
        
        public float Evaluate(List<Token> tokens)
        {
            var list = new List<Token>(tokens);

            list = Process(list, TokenType.Star, TokenType.Slash, TokenType.Percent);

            // 2. Luego suma/resta
            list = Process(list, TokenType.Plus, TokenType.Minus);

            return float.Parse(list[0].Value);
        }

        private List<Token> Process(List<Token> tokens, params TokenType[] types)
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                if (Array.Exists(types, t => t == tokens[i].Type))
                {
                    var op = tokens[i].Value[0];
                    var left = float.Parse(tokens[i - 1].Value);
                    var right = float.Parse(tokens[i + 1].Value);

                    var strategy = OperationFactory.Get(op);
                    var result = strategy.Execute(left, right);

                    // reemplazar tokens
                    tokens.RemoveAt(i + 1);
                    tokens.RemoveAt(i);
                    tokens[i - 1] = new Token(TokenType.Number, result.ToString());

                    i--;
                }
            }

            return tokens;
        }
    }
}
