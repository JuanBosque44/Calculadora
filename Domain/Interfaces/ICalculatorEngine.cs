

using Calculadora.Domain.Entities;
using System.Collections.Generic;

namespace Calculadora.Domain.Interfaces
{
    internal interface ICalculatorEngine
    {
        float Evaluate(List<Token> tokens);
    }
}
