using Calculadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculadora.Domain.Parser
{
    public class Tokenizer
    {
        /// <summary>
        /// Transforma el input recibido en una lista de tokens
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

                if (char.IsDigit(c) || c == ',' || ValidarValor(input, i, tokens))
                {
                    var tokenNumero = LeerNumero(input, ref i);
                    tokens.Add(tokenNumero);
                    continue;
                }

                if ("+-X/%".Contains(c))
                {
                    switch (c)
                    {
                        case '+':
                            tokens.Add(new Token(TokenType.Plus, "+"));
                            break;
                        case '-':
                            tokens.Add(new Token(TokenType.Minus, "-"));
                            break;
                        case 'X':
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

        private bool ValidarValor(string input, int index, List<Token> tokens)
        {
            if (input[index] != '-' && input[index] != '+') return false;

            bool esPrimerCaracter = tokens.Count == 0;

            bool tokenAnteriorEsOperador =
                tokens.Count > 0 &&
                (
                    tokens[tokens.Count - 1].Type == TokenType.Plus ||
                    tokens[tokens.Count - 1].Type == TokenType.Minus ||
                    tokens[tokens.Count - 1].Type == TokenType.Star ||
                    tokens[tokens.Count - 1].Type == TokenType.Slash ||
                    tokens[tokens.Count - 1].Type == TokenType.Percent
                );

            bool tokenAnteriorEsParentesisAbierto =
                tokens.Count > 0 &&
                tokens[tokens.Count - 1].Type == TokenType.LeftParen;

            return esPrimerCaracter || tokenAnteriorEsOperador || tokenAnteriorEsParentesisAbierto;
        }

        private Token LeerNumero(string input, ref int i)
        {
            var sb = new StringBuilder();

            if (input[i] == '-' || input[i] == '+')
            {
                if (input[i] == '-') sb.Append('-');
                else sb.Append('+');
                i++;
            }

            while (i < input.Length && (char.IsDigit(input[i]) || input[i] == ','))
            {
                sb.Append(input[i]);
                i++;
            }

            return new Token(TokenType.Number, sb.ToString());
        }
    }
}
