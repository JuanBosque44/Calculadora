using Calculadora.Domain.Parser;

namespace Calculadora.Domain.Entities
{
    /// <summary>
    /// Objeto que guarda cada parte de la operación por separado
    /// </summary>
    public class Token
    {
        public TokenType Type { get; }
        public string Value { get; }
        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
