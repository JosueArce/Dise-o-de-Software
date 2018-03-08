using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_Othello.Models
{
    public class Estadisticas_Persona
    {
        public String ID_Facebook {get;set;}
        public int partidas_ganadas { get; set; }
        public int partidas_empatadas { get; set; }
        public int partidas_perdidas { get; set; }
    }
}