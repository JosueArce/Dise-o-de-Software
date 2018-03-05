using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaJuegoConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Juego juego = new Juego(8);
            juego.iniciarMatriz();
            juego.dibujar();

            List<List<int>> movidas = juego.MovidasPosibles(1);
            Console.Write(movidas);
            Console.ReadLine();


        }
    }
}
