using Calculadora.Domain.Interfaces;


namespace Calculadora.Domain.Strategies
{
    internal class SubstractionStrategy : IOperationStrategy
    {
        public float Execute(float a, float b) { return a - b; }
    }
}
