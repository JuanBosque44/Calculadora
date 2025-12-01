using Calculadora.Aplication.Services;
using Calculadora.Domain.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Calculadora : Form
    {
        private readonly CalculatorService _calculator;
        private readonly Dictionary<Keys, Button> _keyMap;
        /// <summary>
        /// Resultado de cada operación
        /// </summary>
        float ans;
        public Calculadora()
        {
            InitializeComponent();
            _calculator = new CalculatorService(new CalculatorEngine());
            if (File.Exists("Tema.txt")) Tema.CambiarColor(this);
            if (btnBorrar.BackColor == Color.Black) btnBorrar.Image = Properties.Resources.borrar_blanco;
            this.KeyPreview = true;
            this.AcceptButton = btnCalcular;

            _keyMap = new Dictionary<Keys, Button>
            {
                { Keys.D1, button1 },
                { Keys.D2, button10 },
                { Keys.D3, button2 },
                { Keys.D4, button3 },
                { Keys.D5, button4 },
                { Keys.D6, button5 },
                { Keys.D7, button6 },
                { Keys.D8, button7 },
                { Keys.D9, button8 },
                { Keys.D0, button15 },

                { Keys.NumPad1, button1 },
                { Keys.NumPad2, button10 },
                { Keys.NumPad3, button2 },
                { Keys.NumPad4, button3 },
                { Keys.NumPad5, button4 },
                { Keys.NumPad6, button5 },
                { Keys.NumPad7, button6 },
                { Keys.NumPad8, button7 },
                { Keys.NumPad9, button8 },
                { Keys.NumPad0, button15 },

                { Keys.Oemcomma, button16 },
                { Keys.Oemplus, button11 },
                { Keys.OemMinus, button9 },
                { Keys.Divide, button13 },
                { Keys.Multiply, button12 },

                { Keys.Back, btnBorrar },
                { Keys.Add, button11 },
                { Keys.Subtract, button9 },
                { Keys.Enter, btnCalcular },
                { Keys.Escape, btnBorrarTodo },
            };
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Resultados.Text = string.Empty;
            }
        }

        private void Menu_Opciones_Click(object sender, EventArgs e)
        {
            Opciones opciones = new Opciones();
            if (File.Exists("Tema.txt")) Tema.CambiarColor(opciones);
            opciones.ShowDialog();
            Tema.CambiarColor(this);
            if (btnBorrar.BackColor == Color.Black) btnBorrar.Image = Properties.Resources.borrar_blanco;
            else btnBorrar.Image = Properties.Resources.borrar_negro;
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
            if (_keyMap.TryGetValue(e.KeyCode, out Button btn))
            {
                btn.PerformClick();
                e.Handled = true;
            }
        }
    }
}

/*  
 * --> agregar opcion cambiar tipo de calculadora (conversor de numeros, temperaturas, romanos, etc)
 * historial de calculos
 * agregar otros tipos de calculo
 */


