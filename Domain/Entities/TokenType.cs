using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Domain.Parser
{
    public enum TokenType
    {
        Number,
        Plus,
        Minus,
        Star,
        Slash,
        Percent,
        LeftParen,
        RightParen,
        EOF
    }
}
