using System.Data;
using System.Data.SqlClient;
using DicEspNahuatl.Datos;
using DicEspNahuatl.Datos.Recursos;

//==|    \ /    |============================================ == ==
//==|   11011   |===|  < >LocalStore v1.0 13/02/2016</ > |=== = ===
//==| =0101010= |============================================ == ==
//==| =1010101= |===|    { The bug develop & network }   |=== === =
//==| =0101010= |===| ( ){ ISC Gerardo Álvarez Mendoza } |=== == ==
//==|   00100   |============================================ = ===
namespace DicEspNahuatl.Datos
{
    public partial class Palabras : DBAcceso<Palabra>
    {
        #region Numeradores
        /// <summary>
        /// Enumeración de valores para las opciones disponibles del Store Procedure
        /// </summary>
        enum SPOpcion
        {
            ObtenerPorClaveEntidad = 7
        }
        #endregion

        #region constructor
        /// <summary>
        /// Metodo constructor para la clase Palabras.
        /// </summary>
        public Palabras()
            : base()
        {
            this.esquema = ParametrosConstantes.PC_EsquemaLS;
        }

        #endregion

        #region Obtener por Clave Entidad
        /// <summary>
        /// Método que ejecuta la operacion de Búsqueda por Clave Entidad en la BD
        /// </summary>
        /// <param name="claveEntidad">Valor de Búsqueda Correspondiente a la categoria</param>
        /// <returns>DComer consultado</returns>
        public Palabra ObtenerPorClaveEntidad(int claveEntidad)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter (ParametrosConstantes.PC_NOPCION,      SqlDbType.TinyInt),
                new SqlParameter(ParametrosConstantes.PC_Id,  SqlDbType.Int)
            };
            parametros[0].Value = SPOpcion.ObtenerPorClaveEntidad;
            parametros[1].Value = claveEntidad;

            return EjecutaProcedimientoOne(ConstantesSP.C_EspaniolNahuatl_SP, parametros, new PalabraFactoria());
        }
        #endregion
    }
}