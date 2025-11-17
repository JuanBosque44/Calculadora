using Calculadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculadora.Domain.Parser
{
    public class Tokenizer
    {
        public List<Token> Tokenize(string input)
        {
            var tokens = new List<Token>();
            int i = 0;

            while (i < input.Length)
            {
                char c = input[i];

                if (char.IsWhiteSpace(c))
                {
                    i++;
                    continue;
                }

                if (char.IsDigit(c) || c == '.')
                {
                    string number = "";

                    while (i < input.Length &&
                          (char.IsDigit(input[i]) || input[i] == '.'))
                    {
                        number += input[i];
                        i++;
                    }

                    tokens.Add(new Token(TokenType.Number, number));
                    continue;
                }

                if ("+-*/%".Contains(c))
                {
                    switch (c)
                    {
                        case '+':
                            tokens.Add(new Token(TokenType.Plus, "+"));
                            break;
                        case '-':
                            tokens.Add(new Token(TokenType.Minus, "-"));
                            break;
                        case '*':
                            tokens.Add(new Token(TokenType.Star, "*"));
                            break;
                        case '/':
                            tokens.Add(new Token(TokenType.Slash, "/"));
                            break;
                        case '%':
                            tokens.Add(new Token(TokenType.Percent, "%"));
                            break;
                        default:
                            throw new Exception($"Operador desconocido: {c}");
                    }
                    i++;
                    continue;
                }

                if (c == '(')
                {
                    tokens.Add(new Token(TokenType.LeftParen, "("));
                    i++;
                    continue;
                }

                if (c == ')')
                {
                    tokens.Add(new Token(TokenType.RightParen, ")"));
                    i++;
                    continue;
                }

                throw new Exception($"Carácter inválido: {c}");
            }

            return tokens;
        }
    }
}
