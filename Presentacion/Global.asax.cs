//==== \ / ============================================== == ==
//==== 101 =====|<> Es-Nahuatl v:1.0 - 20/08/2016 </>|=== = ===
//== =10101= ===|    { The bug develop & network }   |=== === =
//== =01010= ===| ( ){ ISC Gerardo Álvarez Mendoza } |=== == ==
//==== 010 ============================================== = ===
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace DicEspNahuatl
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        private void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("", "buscador",
            "~/paginas/PAG_02.aspx");
        }
    }
}