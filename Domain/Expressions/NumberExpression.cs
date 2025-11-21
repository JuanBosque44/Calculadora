using Calculadora.Domain.Interfaces;

namespace Calculadora.Domain.Expressions
{
    internal class NumberExpression : IExpression
    {
        public float Value { get; }

        public NumberExpression(float value)
        {
            Value = value;
        }

        public float Evaluate()
        {
            return Value;
        }
    }
}
