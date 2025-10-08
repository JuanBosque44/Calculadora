//using System.Collections;
//using System.Windows.Forms;

//namespace Calculadora
//{
//    internal class Info
//    {
//        public static string Escribir(bool PrimerCalculo, Button ultimoBotonPresionado, ArrayList operaciones, float ans)
//        {
//            string texto = "";
//            if (PrimerCalculo)
//            {
//                foreach (var variable in operaciones)
//                {
//                    texto += variable.ToString();
//                }
//            }
//            else
//            {
//                if (ultimoBotonPresionado != btnBorrar && CantOp != 0) texto += ans;
//                for (int i = 0; i < operaciones.Count; i++)
//                {
//                    if (i == 0) i = CantOp;
//                    texto += operaciones[i].ToString();
//                }
//            }
//            return texto;
//        }
//    }
//}
