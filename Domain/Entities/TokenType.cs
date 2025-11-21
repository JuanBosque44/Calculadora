
namespace Calculadora.Domain.Parser
{
    /// <summary>
    /// Lista de valores válidos que puede contener una operación
    /// </summary>
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
