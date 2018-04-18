using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi_Othello.Models;

namespace WebApi_Othello.Controllers
{
    public class JuegoController : Controller
    {
        private Juego juego;

        public JuegoController()
        {
            this.juego = new Juego();//no final
        }

        public JsonResult Cargar_Datos(int size, int level, string[][] tablero, String jugadorActual)
        {
            switch (Request.HttpMethod)
            {
                case "GET":
                    return Json(juego.Cargar(size, level, tablero, jugadorActual),
                                JsonRequestBehavior.AllowGet);
                case "POST":
                    return Json(juego.Cargar(size, level, tablero, jugadorActual));
            }

            return Json(new { Error = true, Message = "Operación HTTP desconocida" });
        }

    }
}