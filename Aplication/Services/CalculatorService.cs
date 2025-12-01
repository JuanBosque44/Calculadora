using Calculadora.Aplication.DTOs;
using Calculadora.Aplication.Interfaces;
using Calculadora.Domain.Entities;
using Calculadora.Domain.Interfaces;
using Calculadora.Domain.Parser;
using System;
using System.Collections.Generic;

namespace Calculadora.Aplication.Services
{
    internal class CalculatorService : ICalculatorService
    {
        private readonly ICalculatorEngine _engine;
        private readonly Parser _parser;
        private readonly Tokenizer _tokenizer = new Tokenizer();

        public CalculatorService(ICalculatorEngine engine)
        {
            _engine = engine;
            _parser = new Parser();
            _tokenizer = new Tokenizer();
        }

        public OperationResultDto Evaluate(List<Token> tokens)
        {
            var result = _engine.Evaluate(tokens);
            return new OperationResultDto { Result = result };
        }

        /// <summary>
        /// Calcula el resultado de la operación recibida 
        /// </summary>
        /// <param name="input">Recibe una operación como parámetro</param>
        /// <returns>El resultado final de la operación</returns>
        /// <exception cref="ArgumentException"></exception>
        public OperationResultDto Evaluate(string input)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(input))
                    throw new ArgumentException("La expresión está vacía.");

                var tokens = _tokenizer.Tokenize(input);

                IExpression expression = _parser.Parse(tokens);

                return new OperationResultDto
                {
                    Result = expression.Evaluate()
                };
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al evaluar la expresión: " + ex.Message, ex);
            }
        }
    }
}
