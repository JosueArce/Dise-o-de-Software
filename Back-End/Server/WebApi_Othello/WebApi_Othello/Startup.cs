using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebApi_Othello.Startup))]

namespace WebApi_Othello
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.MapSignalR();
            // Para obtener más información sobre cómo configurar la aplicación, visite https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
