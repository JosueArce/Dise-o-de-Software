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
            this.juego = new Juego(0, 0);//no final
        }


        
        // GET: Juego
        public ActionResult Index()
        {
            return View();
        }
    }
}