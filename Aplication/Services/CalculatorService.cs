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

        public CalculatorService(ICalculatorEngine engine)
        {
            _engine = engine;
            _parser = new Parser();
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
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("La expresión está vacía.");

            var tokenizer = new Tokenizer();
            var tokens = tokenizer.Tokenize(input);

            var parser = new Parser();
            IExpression expression = parser.Parse(tokens);

            return new OperationResultDto
            {
                Result = expression.Evaluate()
            };
        }
    }
}
