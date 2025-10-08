using System;
using System.Collections;
using System.Windows.Forms;

namespace Calculadora
{
    internal class Validacion
    {
        readonly static char[] simbolos = { '+', '-', 'X', '/', '%' };

        public static bool UnSoloCalculo(ArrayList operaciones)
        {
            try
            {
                int contador = 0;
                for (int i = 0; i < operaciones.Count; i++)
                {
                    if (operaciones[i] is float) contador++;
                }
                if (contador == operaciones.Count)
                {
                    return false;
                }
                for (int i = 0; i < operaciones.Count; i++)
                {
                    if (operaciones[i] is char && operaciones[i + 1] is char && (float)operaciones[i + 1] < operaciones.Count)
                    {
                        if (operaciones[i] == operaciones[i + 1])
                        {
                            return false;
                        }
                        for (int j = 0; j < simbolos.Length; j++)
                        {
                            if (j < simbolos.Length - 1)
                                if ((char)operaciones[i] == simbolos[j] && (char)operaciones[i + 1] == simbolos[j] || (char)operaciones[i] == simbolos[j + 1] && (char)operaciones[i + 1] == simbolos[j + 1])
                                {
                                    return false;
                                }
                            if (j == simbolos.Length - 1)
                                if ((char)operaciones[i] == simbolos[j] && (char)operaciones[i] == simbolos[0])
                                {
                                    return false;
                                }
                        }
                        if ((char)operaciones[0] == ',')
                        {
                            return false;
                        }
                        return true;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
    }
}
