using Calculadora.Aplication.DTOs;
using Calculadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Aplication.Interfaces
{
    internal interface ICalculatorService
    {
        OperationResultDto Evaluate(List<Token> tokens);

        OperationResultDto Evaluate(string expression);
    }
}
