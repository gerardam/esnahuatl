using System.Data;
using System.Data.SqlClient;
using DicEspNahuatl.Datos.Recursos;
using System.Collections.Generic;

//==|    \ /    |============================================ == ==
//==|   11011   |===|  < >LocalStore v1.0 13/02/2016</ > |=== = ===
//==| =0101010= |============================================ == ==
//==| =1010101= |===|    { The bug develop & network }   |=== === =
//==| =0101010= |===| ( ){ ISC Gerardo Álvarez Mendoza } |=== == ==
//==|   00100   |============================================ = ===
namespace DicEspNahuatl.Datos
{
    public partial class PImagenes : DBAcceso<PImagen>
    {
        #region Numeradores
        /// <summary>
        /// Enumeración de valores para las opciones disponibles del Store Procedure
        /// </summary>
        enum SPOpcion
        {
            ObtenImagen = 5
        }
        #endregion

        #region constructor
        /// <summary>
        /// Metodo constructor para la clase LogoComercios.
        /// </summary>
        public PImagenes()
            : base()
        {
            this.esquema = ParametrosConstantes.PC_EsquemaLS;
        }

        #endregion

        #region Obtener Lista con el logoComercio
        /// <summary>
        ///
        /// </summary>
        /// <param name="claveEmpresa"></param>
        /// <returns></returns>
        public List<PImagen> ObtenImagen(int idPalabra)
        {
            List<PImagen> lstImagen = new List<PImagen>();
            SqlParameter[] parametros =
            {
                new SqlParameter(ParametrosConstantes.PC_NOPCION,      SqlDbType.TinyInt),
                new SqlParameter(ParametrosConstantes.PC_Id, SqlDbType.Int),
            };
            parametros[0].Value = SPOpcion.ObtenImagen;
            parametros[1].Value = idPalabra;

            return lstImagen = base.EjecutaProcedimiento(ConstantesSP.C_EspaniolNahuatl_SP, parametros, new PImagenFactoria());
        }
        #endregion
    }
}