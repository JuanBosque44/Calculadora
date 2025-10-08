using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Opciones : Form
    {
        public Opciones()
        {
            InitializeComponent();
            if (BackColor == Color.Black) radioButton2.Checked = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) radioButton2.Checked = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) radioButton1.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                TemaClaro();
                if (BackColor == Color.Transparent) BackColor = Color.White;
                using (StreamWriter writer = new StreamWriter("Tema.txt"))
                {
                    writer.WriteLine("Claro");
                }
            }
            if (radioButton2.Checked)
            {
                TemaOscuro();
                if (BackColor == Color.Transparent) BackColor = Color.Black;
                using (StreamWriter writer = new StreamWriter("Tema.txt"))
                {
                    writer.WriteLine("Oscuro");
                }
            }
        }

        public void TemaClaro()
        {
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    control.BackColor = Color.White; 
                }
            }

        }
        public void TemaOscuro()
        {
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
            foreach (Control control in this.Controls)
            {
                if (control is Button) 
                {
                    control.BackColor = Color.Black; 
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
