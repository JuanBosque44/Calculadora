using Calculadora.Domain.Factory;
using Calculadora.Domain.Interfaces;

namespace Calculadora.Domain.Expressions
{
    public class BinaryExpressions : IExpression
    {
        public IExpression Left { get; }
        public IExpression Right { get; }
        public char Operator { get; }

        public BinaryExpressions(IExpression left, IExpression right, char op)
        {
            Left = left;
            Right = right;
            Operator = op;
        }

        public float Evaluate()
        {
            var leftValue = Left.Evaluate();
            var rightValue = Right.Evaluate();

            var strategy = OperationFactory.Get(Operator);

            return strategy.Execute(leftValue, rightValue);
        }
    }
}
