//==== \ / ============================================== == ==
//==== 101 =====|<> Es-Nahuatl v:1.0 - 20/08/2016 </>|=== = ===
//== =10101= ===|    { The bug develop & network }   |=== === =
//== =01010= ===| ( ){ ISC Gerardo Álvarez Mendoza } |=== == ==
//==== 010 ============================================== = ===
using DicEspNahuatl.Datos;
using System;

namespace DicEspNahuatl
{
    public partial class PAG_02 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //Session["descComer"] = txtBuscar.Text;
            //Response.Redirect("~/paginas/DS_02.aspx");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void hdComerId_ValueChanged(object sender, EventArgs e)
        {
            txtBuscar.Text = String.Empty;

            int cveEntItem = Convert.ToInt32(hdComerId.Value);
            Palabra lsPalabras = new Palabras().ObtenerPorClaveEntidad(cveEntItem);
            lblNahuatl.Text = lsPalabras.Nahuatl;
            lblEspaniol.Text = lsPalabras.Espaniol;
            lblComentarios.Text = lsPalabras.Comentarios;
            imgPalabra.ImageUrl = "~/handler/hdlImagen.ashx?numPalabra=" + cveEntItem;
        }
    }
}