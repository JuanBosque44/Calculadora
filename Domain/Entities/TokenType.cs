
namespace Calculadora.Domain.Parser
{
    /// <summary>
    /// Lista de valores válidos que puede contener una operación
    /// </summary>
    public enum TokenType
    {
        /// <summary>
        /// Valor numérico
        /// </summary>
        Number,
        /// <summary>
        /// Suma
        /// </summary>
        Plus,
        /// <summary>
        /// Resta
        /// </summary>
        Minus,
        /// <summary>
        /// Multiplicación
        /// </summary>
        Star,
        /// <summary>
        /// División
        /// </summary>
        Slash,
        /// <summary>
        /// Módulo o resto de una división
        /// </summary>
        Percent,
        /// <summary>
        /// Paréntesis izquierdo
        /// </summary>
        LeftParen,
        /// <summary>
        /// Paréntesis derecho
        /// </summary>
        RightParen,
    }
}
