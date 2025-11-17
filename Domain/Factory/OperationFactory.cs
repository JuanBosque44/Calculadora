using Calculadora.Domain.Interfaces;
using Calculadora.Domain.Strategies;
using System;


namespace Calculadora.Domain.Factory
{
    public class OperationFactory
    {
        public static IOperationStrategy Get(char op)
        {
            switch (op)
            {
                case '+':
                    return new AdditionStrategy();
                case '-':
                    return new SubstractionStrategy();
                case '*':
                    return new MultiplicationStrategy();
                case '/':
                    return new DivisionStrategy();
                case '%':
                    return new ModuleStrategy();
                default:
                    throw new NotImplementedException("Operación no implementada: " + op);
            }
        }
    }
}
