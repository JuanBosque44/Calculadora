using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Calculadora
{
    internal class Tema
    {
        public static void CambiarColor(Form formulario)
        {
            using (StreamReader reader = new StreamReader("Tema.txt"))
            {
                string tema = reader.ReadLine().Trim();
                if (tema == "Claro")
                {
                    formulario.ForeColor = Color.Black;
                    formulario.BackColor = Color.White;
                    foreach (Control control in formulario.Controls)
                    {
                        if (control is Button)
                        {
                            control.BackColor = Color.White;
                        }
                    }
                }
                else if (tema == "Oscuro")
                {
                    formulario.ForeColor = Color.White;
                    formulario.BackColor = Color.Black;
                    foreach (Control control in formulario.Controls)
                    {
                        if (control is Button)
                        {
                            control.BackColor = Color.Black;
                        }
                    }

                }
            }
        }
    }
}
    

