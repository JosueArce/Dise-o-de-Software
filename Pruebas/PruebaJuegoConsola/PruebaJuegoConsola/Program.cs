using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaJuegoConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Ventana());
            /*
            Juego juego = new Juego(8);
            juego.iniciarMatriz();
            List<List<int>> movidas = juego.MovidasPosibles("1");
            foreach (List<int> movida in movidas)
            {
                Console.WriteLine(movida[0] + "," + movida[1]);
            }
            Console.ReadKey();
            */

        }
    }
}
