using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi_Othello.Models;

namespace WebApi_Othello.Controllers
{
    public class LoginController : Controller
    {
        private LoginManager loginManager;
        public LoginController()
        {
            loginManager = new LoginManager();
        }

        public JsonResult logIn(PersonasActivas persona)
        {
            switch (Request.HttpMethod)
            {
                case "GET":
                    return Json(LoginManager.Check_ExtractData(persona),
                                JsonRequestBehavior.AllowGet);
            }
            return Json(new { Error = true, Message = "Operación HTTP desconocida" });
        }
    }
}