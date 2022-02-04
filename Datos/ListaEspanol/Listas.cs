using DicEspNahuatl.Datos.Recursos;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DicEspNahuatl.Datos
{
    public partial class Listas : DBAcceso<Lista>
    {
        #region ENUMERADORES

        /// <summary>
        /// Enumeracion de valores para las opciones disponibles del Store Procedure
        /// </summary>
        enum SPOpcion
        {
            AutoComplete = 6
        }
        #endregion

        #region CONSTRUCTOR

        public Listas()
            : base()
        {
            this.esquema = ParametrosConstantes.PC_EsquemaLS;
        }
        #endregion

        #region AUTOCOMPLETE
        /// <summary>
        ///
        /// </summary>
        /// <param name="Clave"></param>
        /// <returns></returns>
        public List<Lista> ObtenerAutoComplete(string Clave)
        {
            List<Lista> lstAutocomplete = new List<Lista>();
            SqlParameter[] parametros =
            {
                new SqlParameter(ParametrosConstantes.PC_NOPCION,               SqlDbType.TinyInt),
                new SqlParameter(ParametrosConstantes.PC_Espaniol,              SqlDbType.VarChar),
            };
            parametros[0].Value = SPOpcion.AutoComplete;
            parametros[1].Value = Clave;

            return lstAutocomplete = base.EjecutaProcedimiento(ConstantesSP.C_EspaniolNahuatl_SP, parametros, new ListaFactoria());
        }
        #endregion
    }
}
