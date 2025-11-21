using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Calculadora
{
    internal class Tema
    {
        /// <summary>
        /// Permite cambiar el color de un formulario según el tema guardado en "Tema.txt"
        /// </summary>
        /// <param name="formulario">Recibe un formulario al que se le aplicará un tema</param>
        public static void CambiarColor(Form formulario)
        {
            using (StreamReader reader = new StreamReader("Tema.txt"))
            {
                string tema = reader.ReadLine().Trim();
                if (tema == "Claro")
                {
                    CambiarColor(Color.White, Color.Black);
                }
                else if (tema == "Oscuro")
                {
                    CambiarColor(Color.Black, Color.White);
                }

                void CambiarColor(Color colorElegido, Color contraste) 
                {
                    formulario.ForeColor = contraste;
                    formulario.BackColor = colorElegido;
                    foreach (Control control in formulario.Controls)
                    {
                        if (control is Button)
                        {
                            control.BackColor = colorElegido;
                        }
                    }
                }
            }
        }
    }
}
    

