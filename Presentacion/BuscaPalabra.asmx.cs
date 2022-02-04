//==== \ / ============================================== == ==
//==== 101 =====|<> Es-Nahuatl v:1.0 - 20/08/2016 </>|=== = ===
//== =10101= ===|    { The bug develop & network }   |=== === =
//== =01010= ===| ( ){ ISC Gerardo Álvarez Mendoza } |=== == ==
//==== 010 ============================================== = ===
using DicEspNahuatl.Datos;
using System;
using System.Collections.Generic;
using System.Web.Script.Services;
using System.Web.Services;

namespace DicEspNahuatl
{
    /// <summary>
    /// Summary description for BuscaPalabra
    /// </summary>
    [WebService(Namespace = "http://localhost/~BuscaPalabra.asmx")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    [System.Web.Script.Services.ScriptService]
    public class BuscaPalabra : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> ObtenerListaAutocomplete(string prefixText)
        {
            List<Lista> lstPuntos = new Listas().ObtenerAutoComplete(prefixText);
            List<string> listaComer = new List<string>();
            foreach (Lista comer in lstPuntos)
            {
                listaComer.Add(string.Format("{0}-{1}", Convert.ToString(comer.Descripcion), Convert.ToString(comer.ClaveEntidad)));
            }
            return listaComer;
        }
    }
}