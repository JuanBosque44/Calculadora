using System.Collections;

namespace Calculadora
{
    internal class Operaciones
    {
        public static ArrayList CalculosPrimerOrden(ArrayList operacionTemporal, int i, float ans)
        {

            char operador = (char)operacionTemporal[i];
            if (operador == 'X' || operador == '/' || operador == '%')
            {
                float resultado = 0;
                float operando1;
                float operando2;
                if (ans == 0)
                {
                    operando1 = (float)operacionTemporal[i - 1];
                    operando2 = (float)operacionTemporal[i + 1];
                }
                else
                {
                    operando1 = ans;
                    operando2 = (float)operacionTemporal[i + 1];
                }
                if (operador == 'X')
                    resultado = operando1 * operando2;
                else if (operador == '/')
                    resultado = operando1 / operando2;
                else if (operador == '%')
                    resultado = operando1 % operando2;

                ans = resultado;
                operacionTemporal[i - 1] = ans;
                operacionTemporal.RemoveAt(i);
                operacionTemporal.RemoveAt(i);
                i--;
            }
            return operacionTemporal;
        }

        public static ArrayList CalculosSegundoOrden(ArrayList operacionTemporal, int i, float ans)
        {

            char operador = (char)operacionTemporal[i];
            if (operador == '+' || operador == '-')
            {
                float operando1;
                float operando2;
                float resultado = 0;
                if (ans == 0) 
                {
                    operando1 = (float)operacionTemporal[i - 1];
                    operando2 = (float)operacionTemporal[i + 1];
                }
                else
                {
                    operando1 = ans;
                    operando2 = (float)operacionTemporal[i + 1];
                }
                if (operador == '+')
                    resultado = operando1 + operando2;
                else if (operador == '-')
                    resultado = operando1 - operando2;

                ans = resultado;
                operacionTemporal[i - 1] = ans;
                operacionTemporal.RemoveAt(i);
                operacionTemporal.RemoveAt(i);
                i--;
                
            }
            return operacionTemporal;
        }


    }
}
