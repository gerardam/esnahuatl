//==== \ / ============================================== == ==
//==== 101 =====|<> Es-Nahuatl v:1.0 - 20/08/2016 </>|=== = ===
//== =10101= ===|    { The bug develop & network }   |=== === =
//== =01010= ===| ( ){ ISC Gerardo Álvarez Mendoza } |=== == ==
//==== 010 ============================================== = ===
using DicEspNahuatl.Datos;
using DicEspNahuatl.Datos.Recursos;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DicEspNahuatl
{
    public partial class PAG_03 : System.Web.UI.Page
    {
        #region PROPIEDADES
        /// <summary>
        /// Propiedad de claveEntidad.
        /// </summary>
        private int ClaveEntidad
        {
            set { ViewState[Mensajes.C_ClaveEntidad] = value; }
            get { return (int)ViewState[Mensajes.C_ClaveEntidad]; }
        }

        /// <summary>
        /// Propiedad de fechaCambio.
        /// </summary>
        private DateTime FechaCambio
        {
            set { ViewState[Mensajes.C_FechaCambio] = value; }
            get { return (DateTime)ViewState[Mensajes.C_FechaCambio]; }
        }

        /// <summary>
        /// Propiedad para agregar o modificar.
        /// </summary>
        private byte AgregarModificar
        {
            set { ViewState[Mensajes.C_AgregarModificar] = value; }
            get { return (byte)ViewState[Mensajes.C_AgregarModificar]; }
        }
        #endregion

        #region ENUMERADORES
        private enum vistaActiva
        {
            Inicio = 0,
            AgregarModificar = 1
        }

        private enum agregaModifica
        {
            Agrega = 0,
            Modifica = 1
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            if (!IsPostBack)
            {
                MultiVista.ActiveViewIndex = (int)vistaActiva.Inicio;
                cargarContador();
            }
        }

        protected void lnkAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                divBuscador.Visible = false;
                divImg.Visible = false;
                MultiVista.ActiveViewIndex = (int)vistaActiva.AgregarModificar;
                AgregarModificar = (byte)agregaModifica.Agrega;
                LimpiarCampos(false);
            }
            catch (Exception ex)
            {

            }
        }

        protected void lnkEditar_Click(object sender, EventArgs e)
        {
            try
            {
                divBuscador.Visible = true;
                divImg.Visible = true;
                MultiVista.ActiveViewIndex = (int)vistaActiva.AgregarModificar;
                AgregarModificar = (byte)agregaModifica.Modifica;
                LimpiarCampos(false);
            }
            catch (Exception ex)
            {

            }
        }

        protected void hdComerId_ValueChanged(object sender, EventArgs e)
        {
            txtBusca.Text = String.Empty;

            ClaveEntidad = Convert.ToInt32(hdComerId.Value);
            AdminPalabra lsPalabra = new AdminPalabras().ObtenerPorClaveEntidad(ClaveEntidad);
            txtEspaniol.Text = lsPalabra.Espaniol;
            txtNahuatl.Text = lsPalabra.Nahuatl;
            txtTipo.Text = lsPalabra.Tipo;
            txtURL.Text = lsPalabra.URL;
            txtDescripcion.Text = lsPalabra.Comentarios;
            imgPalabra.ImageUrl = "~/handler/hdlImagen.ashx?numPalabra=" + ClaveEntidad;
        }

        protected void lnkAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                AdminPalabra palabra = new AdminPalabra();
                palabra.Espaniol = txtEspaniol.Text;
                palabra.Nahuatl = txtNahuatl.Text;
                palabra.Tipo = txtTipo.Text;
                palabra.URL = txtURL.Text;
                palabra.Comentarios = txtDescripcion.Text;

                palabra.Imagen = null;
                if (fuArchivo.HasFile == true)
                {
                    using (System.IO.BinaryReader reader = new System.IO.BinaryReader(fuArchivo.PostedFile.InputStream))
                    {
                        palabra.Imagen = reader.ReadBytes(fuArchivo.PostedFile.ContentLength);
                    }
                }

                if (AgregarModificar == (int)agregaModifica.Agrega)
                {
                    new AdminPalabras().Insertar(palabra);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Materialize.toast('Palabra agregada!', 2000)", true);
                }
                else if (AgregarModificar == (int)agregaModifica.Modifica)
                {
                    palabra.ClaveEntidad = ClaveEntidad;
                    new AdminPalabras().Actualizar(palabra);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Materialize.toast('Palabra editada!', 2000)", true);
                }
                MultiVista.ActiveViewIndex = (int)vistaActiva.Inicio;
                LimpiarCampos(true);
                cargarContador();
            }
            catch (Exception ex)
            {

            }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                MultiVista.ActiveViewIndex = (int)vistaActiva.Inicio;
                LimpiarCampos(true);
                cargarContador();
            }
            catch (Exception ex)
            {

            }
        }

        private void cargarContador()
        {
            DataSet dtTotalPalabra = new AdminPalabras().ObtenerTotal();
            NoPalabras.Text = dtTotalPalabra.Tables[0].Rows[0]["TotalPalabras"].ToString();
        }

        private void LimpiarCampos(bool mostrar)
        {
            lnkAgregar.Visible = mostrar;
            lnkEditar.Visible = mostrar;
            lnkAceptar.Visible = !mostrar;
            lnkCancelar.Visible = !mostrar;

            txtEspaniol.Text = String.Empty;
            txtNahuatl.Text = String.Empty;
            txtTipo.Text = String.Empty;
            txtArchivo.Text = String.Empty;
            txtURL.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            fuArchivo = new FileUpload();
        }
    }
}