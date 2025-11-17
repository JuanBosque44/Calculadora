using System;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using Calculadora.Aplication.Services;
using Calculadora.Domain.Engine;

namespace Calculadora
{
    public partial class Calculadora : Form
    {
        private readonly CalculatorService _calculator;
        ArrayList operaciones = new ArrayList();
        float ans;
        int CantOp = 0;
        bool PrimerCalculo = true;
        public Calculadora()
        {
            InitializeComponent();
            _calculator = new CalculatorService(new CalculatorEngine());
            if (File.Exists("Tema.txt")) Tema.CambiarColor(this);
            this.KeyPreview = true;
        }
        private Button ultimoBotonPresionado = null;
        
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
                if (ultimoBotonPresionado != btnBorrar && CantOp != 0) Resultados.Text += ans;
                for (int i = 0; i < operaciones.Count; i++)
                {
                    if (i == 0) i = CantOp;
                    Resultados.Text += operaciones[i].ToString();
                }
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
            if (ultimoBotonPresionado == botonActual || ultimoBotonPresionado == null) return;
            ultimoBotonPresionado = botonActual;
            operaciones.Add(char.Parse(button11.Text));
            Escribir();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Button botonActual = (Button)sender;
            if (ultimoBotonPresionado == botonActual || ultimoBotonPresionado == null) return;
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
            if (ultimoBotonPresionado == botonActual || ultimoBotonPresionado == null) return;
            ultimoBotonPresionado = botonActual;
            operaciones.Add(char.Parse(button14.Text));
            Escribir();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Button botonActual = (Button)sender;
            if (ultimoBotonPresionado == botonActual || ultimoBotonPresionado == null) return;
            ultimoBotonPresionado = botonActual;
            operaciones.Add(char.Parse(button12.Text));
            Escribir();
        }

        private void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            //ultimoBotonPresionado = (Button)sender;
            ultimoBotonPresionado = null;
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
            try
            {
                string input = Resultados.Text; 

                float resultado = _calculator.Evaluate(input).Result;

                ans = resultado;

                Resultados.Text = resultado.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la expresión: " + ex.Message);
            }
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
            if (ultimoBotonPresionado == botonActual || ultimoBotonPresionado == null) return;
            ultimoBotonPresionado = botonActual;
            operaciones.Add(char.Parse(button16.Text));
            Escribir();
        }

        private void button17_Click(object sender, EventArgs e) //answer
        {
            Button botonActual = (Button)sender;
            if (ultimoBotonPresionado == botonActual || ultimoBotonPresionado == null) return;
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
 */


