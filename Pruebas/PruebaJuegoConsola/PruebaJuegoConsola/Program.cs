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
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Ventana());
            */
            Juego juego = new Juego(8);
            juego.setJugador("1");
            juego.iniciarMatriz();
            juego.dibujar();
            List<List<int>> movidas = juego.MovidasPosibles();
            juego.getJugadasPosibles();
            Console.ReadKey();
            juego.realizarJugada();
            juego.dibujar();
            

        }
    }
}
