using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaJuegoConsola
{
    class Data
    {
        public int fichas_J1 { get; set; }
        public int fichas_J2 { get; set; }
        public String[,] tablero { get; set; }
        public List<List<int>> movidas { get; set; }
        public bool juego_Terminado { get; set; }
        public string jugador_Actual { get; set; }
    }
}
