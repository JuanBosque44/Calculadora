using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    internal abstract class Operaciones
    {
        
        public static float Suma(List<float> numeros)
        {
            float suma = 0;
            if (numeros.Count > 0)
            {
                for (int i = 0; i < numeros.Count; i++)
                {
                    suma += numeros[i];
                }
            }
            return suma;
        }

        public static float Suma(float answer, List<float> numeros)
        {
            float suma = answer;
            if (numeros.Count > 0)
            {
                for (int i = 0; i < numeros.Count; i++)
                {
                    suma += numeros[i];
                }
            }
            return suma;
        }
        public static float Resta(List<float> numeros)
        {
            float resta = numeros[0];
            if (numeros.Count > 0)
            {
                for (int i = 1; i < numeros.Count; i++)
                {
                    resta -= numeros[i];
                }
            }
            return resta;
        }  
        public static float Resta(List<float> numeros, float ans)
        {
            float resta = ans;
            if (numeros.Count > 0)
            {
                for (int i = 1; i < numeros.Count; i++)
                {
                    resta -= numeros[i];
                }
            }
            return resta;
        } 
        public static float Multiplicacion(List<float> numeros)
        {
            float multiplicacion = 1;
            if (numeros.Count > 0)
            {
                for (int i = 0; i < numeros.Count; i++)
                {
                    multiplicacion *= numeros[i];
                }
            }
            return multiplicacion;
        }
        public static float Multiplicacion(List<float> numeros, float ans)
        {
            float multiplicacion = ans;
            if (numeros.Count > 0)
            {
                for (int i = 0; i < numeros.Count; i++)
                {
                    multiplicacion *= numeros[i];
                }
            }
            return multiplicacion;
        }
        public static float Division(List<float> numeros)
        {
            float division = numeros[0];
            if (numeros.Count > 0)
            {
                for (int i = 1; i < numeros.Count; i++)
                {
                    division /= numeros[i];
                }
            }
            return division;
        }
        public static float Division(List<float> numeros, float answer)
        {
            float division = answer;
            if (numeros.Count > 0)
            {
                for (int i = 1; i < numeros.Count; i++)
                {
                    division /= numeros[i];
                }
            }
            return division;
        }

        public static float Resto(List<float> numeros)
        {
            float resto = numeros[0];
            if (numeros.Count > 0)
            {
                for (int i = 0; i < numeros.Count; i++)
                {
                    resto %= numeros[i];
                }
            }
            return resto;
        }
        public static float Resto(List<float> numeros, float ans)
        {
            float resto = ans;
            if (numeros.Count > 0)
            {
                for (int i = 0; i < numeros.Count; i++)
                {
                    resto %= numeros[i];
                }
            }
            return resto;
        }
    }
}
