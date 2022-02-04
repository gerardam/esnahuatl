//==== \ / ============================================== == ==
//==== 101 =====|<> Es-Nahuatl v:1.0 - 20/08/2016 </>|=== = ===
//== =10101= ===|    { The bug develop & network }   |=== === =
//== =01010= ===| ( ){ ISC Gerardo Álvarez Mendoza } |=== == ==
//==== 010 ============================================== = ===
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DicEspNahuatl.Datos;

namespace DicEspNahuatl.Presentacion.Handler
{
    /// <summary>
    /// Summary description for hdlImagen
    /// </summary>
    public class hdlImagen : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            int cveImagen = Convert.ToInt32(context.Request["numPalabra"]);
            context.Response.ContentType = "image/png";

            List<PImagen> lstEmpresa = new PImagenes().ObtenImagen(cveImagen);
            Byte[] imagen = null;
            foreach (PImagen a in lstEmpresa)
            {
                imagen = a.PImage;
            }

            try
            {
                context.Response.BinaryWrite(imagen);
                context.Response.End();
            }
            catch (Exception)
            {
                //No cuenta con una imagen
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}