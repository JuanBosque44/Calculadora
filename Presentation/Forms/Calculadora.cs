using System;
using System.Windows.Forms;
using System.IO;
using Calculadora.Aplication.Services;
using Calculadora.Domain.Engine;

namespace Calculadora
{
    public partial class Calculadora : Form
    {
        private readonly CalculatorService _calculator;
        float ans;
        public Calculadora()
        {
            InitializeComponent();
            _calculator = new CalculatorService(new CalculatorEngine());
            if (File.Exists("Tema.txt")) Tema.CambiarColor(this);
            this.KeyPreview = true;
            this.AcceptButton = btnCalcular;
        }
        private Button ultimoBotonPresionado = null;
        
        /// <summary>
        /// Permite escribir numeros en el label
        /// </summary>
        void Agregar(string txt)
        {
            if(Resultados.Text == "0")
            {
                Resultados.Text = string.Empty;
            }
            Resultados.Text += txt;
        }

        private void btn1(object sender, EventArgs e)
        {
            ultimoBotonPresionado = (Button)sender;
            Agregar(button1.Text);
        }

        private void btn2(object sender, EventArgs e)
        {
            ultimoBotonPresionado = (Button)sender;
            Agregar(button10.Text);
        }

        private void btn3(object sender, EventArgs e)
        {
            ultimoBotonPresionado = (Button)sender;
            Agregar(button2.Text);
        }

        private void btn4(object sender, EventArgs e)
        {
            ultimoBotonPresionado = (Button)sender;
            Agregar(button3.Text);
        }

        private void btn5(object sender, EventArgs e)
        {
            ultimoBotonPresionado = (Button)sender;
            Agregar(button4.Text);
        }

        private void btn6(object sender, EventArgs e)
        {
            ultimoBotonPresionado = (Button)sender;
            Agregar(button5.Text);
        }

        private void btn7(object sender, EventArgs e)
        {
            ultimoBotonPresionado = (Button)sender;
            Agregar(button6.Text);
        }

        private void btn8(object sender, EventArgs e)
        {
            ultimoBotonPresionado = (Button)sender;
            Agregar(button7.Text);
        }

        private void btn9(object sender, EventArgs e)
        {
            ultimoBotonPresionado = (Button)sender;
            Agregar(button8.Text);
        }

        private void btnSuma(object sender, EventArgs e)
        {
            Button botonActual = (Button)sender;
            if (ultimoBotonPresionado == botonActual || ultimoBotonPresionado == null) return;
            ultimoBotonPresionado = botonActual;
            Agregar(button11.Text);
        }

        private void btnDivision(object sender, EventArgs e)
        {
            Button botonActual = (Button)sender;
            if (ultimoBotonPresionado == botonActual || ultimoBotonPresionado == null) return;
            ultimoBotonPresionado = botonActual;
            Agregar(button13.Text);
        }

        private void btnResta(object sender, EventArgs e)
        {
            Button botonActual = (Button)sender;
            if (ultimoBotonPresionado == botonActual) return;
            ultimoBotonPresionado = botonActual;
            Agregar(button9.Text);
        }

        private void btnModulo(object sender, EventArgs e)
        {
            Button botonActual = (Button)sender;
            if (ultimoBotonPresionado == botonActual || ultimoBotonPresionado == null) return;
            ultimoBotonPresionado = botonActual;
            Agregar(button14.Text);
        }

        private void btnMultiplicacion(object sender, EventArgs e)
        {
            Button botonActual = (Button)sender;
            if (ultimoBotonPresionado == botonActual || ultimoBotonPresionado == null) return;
            ultimoBotonPresionado = botonActual;
            Agregar(button12.Text);
        }

        private void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            ultimoBotonPresionado = null;
            Resultados.Text = string.Empty;
            ans = 0;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            ultimoBotonPresionado = (Button)sender;
            if (Resultados.Text.Length > 0)
            {
                Resultados.Text = Resultados.Text.Substring(0, Resultados.Text.Length - 1);
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
                MessageBox.Show("Error en la sintaxis: " + ex.Message);
            }
        }

        private void Menu_Opciones_Click(object sender, EventArgs e)
        {
            Opciones opciones = new Opciones();
            if (File.Exists("Tema.txt")) Tema.CambiarColor(opciones);
            opciones.ShowDialog();
            Tema.CambiarColor(this);
        }

        private void btn0(object sender, EventArgs e)
        {
            ultimoBotonPresionado = (Button)sender;
            Agregar(button15.Text);
        }

        private void btnDecimal(object sender, EventArgs e) 
        {
            Button botonActual = (Button)sender;
            if (ultimoBotonPresionado == botonActual || ultimoBotonPresionado == null) return;
            ultimoBotonPresionado = botonActual;
            Agregar(button16.Text);
        }

        private void btnRespuesta(object sender, EventArgs e) 
        {
            Button botonActual = (Button)sender;
            if (ultimoBotonPresionado == botonActual || ultimoBotonPresionado == null) return;
            ultimoBotonPresionado = (Button)sender;
            Agregar(ans.ToString());
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


