using Calculadora.Domain.Interfaces;

namespace Calculadora.Domain.Strategies
{
    internal class DivisionStrategy : IOperationStrategy
    {
        public float Execute(float a, float b) {  return a / b; }
    }
}
