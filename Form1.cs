using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using Calculadora;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        ArrayList operaciones = new ArrayList();
        float ans;
        int CantOp = 0;
        bool PrimerCalculo = true;
        readonly char[] simbolos = { '+', '-', 'X', '/', '%' };
        public Form1()
        {
            InitializeComponent();
            if (File.Exists("Tema.txt")) Tema.CambiarColor(this);
            this.KeyPreview = true;
        }
        private Button ultimoBotonPresionado = null;
        /// <summary>
        /// Resuelve operaciones matematicas
        /// </summary>
        void ResolverOperaciones()
        {
            ArrayList operacionTemporal = new ArrayList(operaciones);
            float numeroConcat = 0;
            if (operacionTemporal[0] is float && operacionTemporal.Count == 1) Escribir();
            for (int i = 0; i < operacionTemporal.Count; i++) //concatena y guarda los numeros
            {

                if (PrimerCalculo)
                {
                    if (operacionTemporal[i] is float)
                    {
                        numeroConcat = float.Parse(numeroConcat.ToString() + operacionTemporal[i].ToString());
                    }
                    if (operacionTemporal[i] is char && (char)operacionTemporal[i] != ',' || i == operacionTemporal.Count - 1)
                    {
                        //todos los numeros concatenados se guardan en el ultimo numero sin concatenar, antes de una operacion o del cierre del array
                        if (operacionTemporal[i - 1] is char) operacionTemporal[i] = numeroConcat;
                        if (operacionTemporal[i] is float && i == operacionTemporal.Count - 1) operacionTemporal[i] = numeroConcat;
                        else if (operacionTemporal[i - 1] is float) operacionTemporal[i - 1] = numeroConcat;
                        Eliminar();
                        numeroConcat = 0;
                    }
                    else if (operacionTemporal[i] is char && (char)operacionTemporal[i] == ',' && operacionTemporal[i + 1] is float) // actualizar los concatenados de decimales para que colocque los nros adelante
                    {
                        numeroConcat = float.Parse(numeroConcat.ToString() + operacionTemporal[i].ToString() + operacionTemporal[i + 1].ToString());
                        if (i == operacionTemporal.Count - 2)
                        {
                            operacionTemporal[operacionTemporal.Count - 1] = numeroConcat;
                            i++;
                            Eliminar();
                        }
                        if (i != operacionTemporal.Count - 2 && i != operacionTemporal.Count - 1) i++;
                    }
                }
                else
                {
                    operacionTemporal[0] = ans;
                    if (i == 0 && CantOp > 0) i = CantOp;
                    else if (i == 0) i = 1;
                    if (operacionTemporal[i] is float)
                    {
                        numeroConcat = float.Parse(numeroConcat.ToString() + operacionTemporal[i].ToString());
                    }
                    if (operacionTemporal[i] is char && (char)operacionTemporal[i] != ',' && i > 1 || i == operacionTemporal.Count - 1)
                    {
                        if (operacionTemporal[i - 1] is char && i != 0) operacionTemporal[i] = numeroConcat;
                        if (operacionTemporal[i] is float && i == operacionTemporal.Count - 1 && i != 0) operacionTemporal[i] = numeroConcat;
                        else if (operacionTemporal[i - 1] is float && i != 0) operacionTemporal[i - 1] = numeroConcat;
                        Eliminar();
                        numeroConcat = 0;
                    }
                    else if (operacionTemporal[i] is char && (char)operacionTemporal[i] == ',' && operacionTemporal[i + 1] is float)
                    {
                        numeroConcat = float.Parse(numeroConcat.ToString() + operacionTemporal[i].ToString() + operacionTemporal[i + 1].ToString());
                        if (i == operacionTemporal.Count - 2)
                        {
                            operacionTemporal[operacionTemporal.Count - 1] = numeroConcat;
                            i++;
                            Eliminar();
                        }
                        if (i != operacionTemporal.Count - 2 && i != operacionTemporal.Count - 1) i++;
                    }
                }
                void Eliminar()
                {
                    if (i >= 2 && numeroConcat.ToString().Length > 1 && numeroConcat != ans)
                    {
                        int carac = numeroConcat.ToString().Length;
                        int contador = 0;
                        do
                        {
                            if (i != operacionTemporal.Count && operacionTemporal[i - carac] is float && (float)operacionTemporal[i - carac] != numeroConcat || (operacionTemporal[i - carac] is char && (char)operacionTemporal[i - carac] == ','))
                            {
                                operacionTemporal.RemoveAt(i - carac);
                                contador++;
                            }
                            else
                            {
                                operacionTemporal.RemoveAt(i - (carac - 1));
                                contador++;
                            }
                            if (i == operacionTemporal.Count - 1 && i != carac) i--;
                        }
                        while (contador < carac - 1);
                        i -= contador;
                    }
                }
            }
            // multiplicación, división y módulo
            for (int i = 0; i < operacionTemporal.Count; i++)
            {
                if (operacionTemporal[i] is char)
                {
                    if (PrimerCalculo)
                    {
                        char operador = (char)operacionTemporal[i];
                        if (operador == 'X' || operador == '/' || operador == '%')
                        {
                            float operando1 = (float)operacionTemporal[i - 1];
                            float operando2 = (float)operacionTemporal[i + 1];
                            float resultado = 0;

                            if (operador == 'X')
                                resultado = operando1 * operando2;
                            else if (operador == '/')
                                resultado = operando1 / operando2;
                            else if (operador == '%')
                                resultado = operando1 % operando2;

                            operacionTemporal[i - 1] = resultado;
                            operacionTemporal.RemoveAt(i);
                            operacionTemporal.RemoveAt(i);
                            i--;
                        }
                    }
                    else
                    {
                        char operador = (char)operacionTemporal[i];
                        if (operador == 'X' || operador == '/' || operador == '%')
                        {
                            float operando1 = ans;
                            float operando2 = (float)operacionTemporal[i + 1];
                            float resultado = 0;

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
                    }
                }
            }

            //suma y resta
            for (int i = 0; i < operacionTemporal.Count; i++)
            {
                if (operacionTemporal[i] is char)
                {
                    if (PrimerCalculo)
                    {
                        char operador = (char)operacionTemporal[i];
                        if (operador == '+' || operador == '-')
                        {
                            float operando1 = (float)operacionTemporal[i - 1];
                            float operando2 = (float)operacionTemporal[i + 1];
                            float resultado = 0;

                            if (operador == '+')
                                resultado = operando1 + operando2;
                            else if (operador == '-')
                                resultado = operando1 - operando2;

                            operacionTemporal[i - 1] = resultado;
                            operacionTemporal.RemoveAt(i);
                            operacionTemporal.RemoveAt(i);
                            i--;
                        }
                    }
                    else
                    {
                        char operador = (char)operacionTemporal[i];
                        if (operador == '+' || operador == '-')
                        {
                            float operando1 = ans;
                            float operando2 = (float)operacionTemporal[i + 1];
                            float resultado = 0;

                            if (operador == '+')
                                resultado = operando1 + operando2;
                            else if (operador == '-')
                                resultado = operando1 - operando2;

                            ans = resultado;
                            operacionTemporal[i - 1] = ans; // Reemplaza el primer operando con el resultado
                            operacionTemporal.RemoveAt(i);       // Elimina el operador
                            operacionTemporal.RemoveAt(i);       // Elimina el segundo operando
                            i--; // Retrocede el índice para reevaluar
                        }
                    }
                }
            }

            // Al final de la evaluación, el resultado estará en el primer elemento
            if (operacionTemporal[0] is float)
            {
                ans = (float)operacionTemporal[0];
                Escribir(ans);
                PrimerCalculo = false;
                CantOp = operacionTemporal.Count;
                operaciones = operacionTemporal;
            }
        }
        /// <summary>
        /// Permite escribir numeros en el label
        /// </summary>
        void Escribir()
        {
            Resultados.Text = string.Empty;
            if (PrimerCalculo)
            {
                foreach (var variable in operaciones)
                {
                    Resultados.Text += variable.ToString();
                }
            }
            else
            {
                if (ultimoBotonPresionado != btnBorrar) Resultados.Text += ans;
                for (int i = 0; i < operaciones.Count; i++)
                {
                    if (i == 0) i = CantOp;
                    Resultados.Text += operaciones[i].ToString();
                }
            }
        }
        bool UnSoloCalculo()
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
                    Escribir();
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
        void Escribir(float resultado)
        {
            Resultados.Text = string.Empty;
            Resultados.Text = resultado.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ultimoBotonPresionado = (Button)sender;
            operaciones.Add(float.Parse(button1.Text));
            Escribir();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ultimoBotonPresionado = (Button)sender;
            operaciones.Add(float.Parse(button10.Text));
            Escribir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ultimoBotonPresionado = (Button)sender;
            operaciones.Add(float.Parse(button2.Text));
            Escribir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ultimoBotonPresionado = (Button)sender;
            operaciones.Add(float.Parse(button3.Text));
            Escribir();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ultimoBotonPresionado = (Button)sender;
            operaciones.Add(float.Parse(button4.Text));
            Escribir();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ultimoBotonPresionado = (Button)sender;
            operaciones.Add(float.Parse(button5.Text));
            Escribir();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ultimoBotonPresionado = (Button)sender;
            operaciones.Add(float.Parse(button6.Text));
            Escribir();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ultimoBotonPresionado = (Button)sender;
            operaciones.Add(float.Parse(button7.Text));
            Escribir();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ultimoBotonPresionado = (Button)sender;
            operaciones.Add(float.Parse(button8.Text));
            Escribir();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Button botonActual = (Button)sender;
            if (ultimoBotonPresionado == botonActual) return;
            ultimoBotonPresionado = botonActual;
            operaciones.Add(char.Parse(button11.Text));
            Escribir();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Button botonActual = (Button)sender;
            if (ultimoBotonPresionado == botonActual) return;
            ultimoBotonPresionado = botonActual;
            operaciones.Add(char.Parse(button13.Text));
            Escribir();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Button botonActual = (Button)sender;
            if (ultimoBotonPresionado == botonActual) return;
            ultimoBotonPresionado = botonActual;
            operaciones.Add(char.Parse(button9.Text));
            Escribir();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Button botonActual = (Button)sender;
            if (ultimoBotonPresionado == botonActual) return;
            ultimoBotonPresionado = botonActual;
            operaciones.Add(char.Parse(button14.Text));
            Escribir();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Button botonActual = (Button)sender;
            if (ultimoBotonPresionado == botonActual) return;
            ultimoBotonPresionado = botonActual;
            operaciones.Add(char.Parse(button12.Text));
            Escribir();
        }

        private void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            ultimoBotonPresionado = (Button)sender;
            operaciones.Clear();
            ans = 0;
            CantOp = 0;
            PrimerCalculo = true;
            Escribir();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            ultimoBotonPresionado = (Button)sender;
            if (operaciones.Count > 0)
            {
                if (!PrimerCalculo && CantOp != 0) CantOp--;
                if (operaciones[operaciones.Count - 1] is float && (float)operaciones[operaciones.Count - 1] == ans)
                {
                    PrimerCalculo = true;
                    operaciones.RemoveAt(operaciones.Count - 1);
                }
                else operaciones.RemoveAt(operaciones.Count - 1);
                Escribir();
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            Button botonActual = (Button)sender;
            if (ultimoBotonPresionado == botonActual) return;
            ultimoBotonPresionado = botonActual;
            if (!UnSoloCalculo()) return;
            ResolverOperaciones();
        }

        private void Menu_Opciones_Click(object sender, EventArgs e)
        {
            Opciones opciones = new Opciones();
            if (File.Exists("Tema.txt")) Tema.CambiarColor(opciones);
            opciones.ShowDialog();
            Tema.CambiarColor(this);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ultimoBotonPresionado = (Button)sender;
            operaciones.Add(float.Parse(button15.Text));
            Escribir();
        }

        private void button16_Click(object sender, EventArgs e) //coma
        {
            Button botonActual = (Button)sender;
            if (ultimoBotonPresionado == botonActual) return;
            ultimoBotonPresionado = botonActual;
            operaciones.Add(char.Parse(button16.Text));
            Escribir();
        }

        private void button17_Click(object sender, EventArgs e) //answer
        {
            Button botonActual = (Button)sender;
            if (ultimoBotonPresionado == botonActual) return;
            ultimoBotonPresionado = (Button)sender;
            operaciones.Add(ans);
            Escribir();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D1:
                    button1.PerformClick();
                    break;

                case Keys.D2:
                    button10.PerformClick();
                    break;

                case Keys.D3:
                    button2.PerformClick();
                    break;

                case Keys.D4:
                    button3.PerformClick();
                    break;

                case Keys.D5:
                    button4.PerformClick();
                    break;

                case Keys.D6:
                    button5.PerformClick();
                    break;

                case Keys.D7:
                    button6.PerformClick();
                    break;

                case Keys.D8:
                    button7.PerformClick();
                    break;

                case Keys.D9:
                    button8.PerformClick();
                    break;

                case Keys.D0:
                    button15.PerformClick();
                    break;

                case Keys.Oemcomma:
                    button16.PerformClick();
                    break;

                case Keys.Oemplus:
                    button11.PerformClick();
                    break;

                case Keys.OemMinus:
                    button9.PerformClick();
                    break;

                case Keys.Back:
                    btnBorrar.PerformClick();
                    break;

                case Keys.Divide:
                    button13.PerformClick();
                    break;

                case Keys.Multiply:
                    button12.PerformClick();
                    break;

                case Keys.Enter:
                    btnCalcular.PerformClick();
                    break;
                case Keys.Add:
                    button11.PerformClick();
                    break;
                case Keys.Subtract:
                    button9.PerformClick();
                    break;
                case Keys.NumPad1:
                    button1.PerformClick();
                    break;
                case Keys.NumPad2:
                    button10.PerformClick();
                    break;
                case Keys.NumPad3:
                    button2.PerformClick();
                    break;
                case Keys.NumPad4:
                    button3.PerformClick();
                    break;
                case Keys.NumPad5:
                    button4.PerformClick();
                    break;
                case Keys.NumPad6:
                    button5.PerformClick();
                    break;
                case Keys.NumPad7:
                    button6.PerformClick();
                    break;
                case Keys.NumPad8:
                    button7.PerformClick(); 
                    break;
                case Keys.NumPad9:
                    button8.PerformClick();
                    break;
                case Keys.NumPad0:
                    button15.PerformClick();
                    break;
                default:
                    break;
            }
        }
    }
}

/* falta terminar opciones 
 * --> agregar opcion cambiar tipo de calculadora (conversor de numeros, temperaturas, romanos, etc)
 * historial de calculos
 * ver una forma mas optima de cambiar la funcion de cada boton
 * agregar numeros negativos
 * agregar otros tipos de calculo
 * Buscar alguna soluciom al problema de si el usuario decide calcular usando los mismos numeros que ans pero que no quiso pulsar el boton homonimo
 */


//Codigo anterior de la calculadora
//List<float> numeroConcatenado = new List<float>();
//float numeroConcat = 0;


//for (int i = 0; i < operaciones.Count; i++)
//{
//    if (operaciones[i] is char && (char)operaciones[i] != ',')
//    {
//        if (PrimerCalculo)
//        {
//            if ((char)operaciones[i] == '+')
//            {
//                ans = Operaciones.Suma(numeroConcatenado);
//                Escribir(ans);
//            }
//            else if ((char)operaciones[i] == '-')
//            {
//                ans = Operaciones.Resta(numeroConcatenado);
//                Escribir(ans);
//            }
//            else if ((char)operaciones[i] == 'X')
//            {
//                ans = Operaciones.Multiplicacion(numeroConcatenado);
//                Escribir(ans);
//            }
//            else if ((char)operaciones[i] == '/')
//            {
//                ans = Operaciones.Division(numeroConcatenado);
//                Escribir(ans);
//            }
//            else if ((char)operaciones[i] == '%') Escribir(Operaciones.Resto(numeroConcatenado));
//            PrimerCalculo = false;
//        }
//        else
//        {
//            if (i == 1) i = CantOp;
//            if (operaciones[i] is float) return;
//            if ((char)operaciones[i] == '+')
//            {
//                ans = Operaciones.Suma(ans, numeroConcatenado);
//                Escribir(ans);
//            }
//            else if ((char)operaciones[i] == '-')
//            {
//                ans = Operaciones.Resta(numeroConcatenado, ans);
//                Escribir(ans);
//            }
//            else if ((char)operaciones[i] == 'X')
//            {
//                ans = Operaciones.Multiplicacion(numeroConcatenado, ans);
//                Escribir(ans);
//            }
//            else if ((char)operaciones[i] == '/')
//            {
//                ans = Operaciones.Division(numeroConcatenado, ans);
//                Escribir(ans);
//            }
//            else if ((char)operaciones[i] == '%')
//            {
//                ans = Operaciones.Resto(numeroConcatenado, ans);
//                Escribir(ans);
//            }
//        }
//    }

//}
//CantOp = operaciones.Count;
