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
    public partial class AdminPalabras : DBAcceso<AdminPalabra>
    {
        #region Numeradores
        /// <summary>
        /// Enumeración de valores para las opciones disponibles del Store Procedure
        /// </summary>
        enum SPOpcion
        {
            Insertar = 1,
            Actualizar = 2,
            ObtenerTotal = 3,
            ObtenerPorClaveEntidad = 4
        }
        #endregion

        #region constructor
        /// <summary>
        /// Metodo constructor para la clase Palabras.
        /// </summary>
        public AdminPalabras()
            : base()
        {
            this.esquema = ParametrosConstantes.PC_EsquemaLS;
        }

        #endregion

        #region Insertar
        /// <summary>
        /// Metodo que ejecuta la operación de Insertar el registro en la BD.
        /// </summary>
        /// <param name="categorias"></param>
        public void Insertar(AdminPalabra palabra)
        {
            SqlParameter[] parametros =
            {
                  new SqlParameter(ParametrosConstantes.PC_NOPCION,         SqlDbType.TinyInt),
                  new SqlParameter(ParametrosConstantes.PC_Id,              SqlDbType.Int),
                  new SqlParameter(ParametrosConstantes.PC_Espaniol,        SqlDbType.NVarChar),
                  new SqlParameter(ParametrosConstantes.PC_Nahuatl,         SqlDbType.NVarChar),
                  new SqlParameter(ParametrosConstantes.PC_Tipo,            SqlDbType.NVarChar),
                  new SqlParameter(ParametrosConstantes.PC_Imagen,          SqlDbType.VarBinary),
                  new SqlParameter(ParametrosConstantes.PC_Url,             SqlDbType.NVarChar),
                  new SqlParameter(ParametrosConstantes.PC_Comentarios,     SqlDbType.NVarChar)
              };
            parametros[0].Value = SPOpcion.Insertar;
            parametros[1].Direction = ParameterDirection.Output;
            parametros[2].Value = palabra.Espaniol;
            parametros[3].Value = palabra.Nahuatl;
            parametros[4].Value = palabra.Tipo;
            parametros[5].Value = palabra.Imagen;
            parametros[6].Value = palabra.URL;
            parametros[7].Value = palabra.Comentarios;

            EjecutaProcedimientoCrud(ConstantesSP.C_EspaniolNahuatl_SP, parametros);
        }
        #endregion

        #region Actualizar
        /// <summary>
        /// Metodo que ejecuta la operación de Actualizar el registro en la BD.
        /// </summary>
        /// <param name="articulo">Objeto de categoria con los valores a insertar</param>
        public int Actualizar(AdminPalabra palabra)
        {
            SqlParameter[] parametros =
            {
                  new SqlParameter(ParametrosConstantes.PC_NOPCION,         SqlDbType.TinyInt),
                  new SqlParameter(ParametrosConstantes.PC_Id,              SqlDbType.Int),
                  new SqlParameter(ParametrosConstantes.PC_Espaniol,        SqlDbType.NVarChar),
                  new SqlParameter(ParametrosConstantes.PC_Nahuatl,         SqlDbType.NVarChar),
                  new SqlParameter(ParametrosConstantes.PC_Tipo,            SqlDbType.NVarChar),
                  new SqlParameter(ParametrosConstantes.PC_Imagen,          SqlDbType.VarBinary),
                  new SqlParameter(ParametrosConstantes.PC_Url,             SqlDbType.NVarChar),
                  new SqlParameter(ParametrosConstantes.PC_Comentarios,     SqlDbType.NVarChar)
              };
            parametros[0].Value = SPOpcion.Actualizar;
            parametros[1].Value = palabra.ClaveEntidad;
            parametros[2].Value = palabra.Espaniol;
            parametros[3].Value = palabra.Nahuatl;
            parametros[4].Value = palabra.Tipo;
            parametros[5].Value = palabra.Imagen;
            parametros[6].Value = palabra.URL;
            parametros[7].Value = palabra.Comentarios;

            DataSet TablaRecibir = EjecutaProcedimiento(ConstantesSP.C_EspaniolNahuatl_SP, parametros, CamposConstantes.C_Modificaciones);
            int dato = int.Parse(TablaRecibir.Tables[CamposConstantes.C_Modificaciones].Rows[0][0].ToString());
            return dato;
        }
        #endregion

        #region Obtener Todo
        /// <summary>
        /// Obtener todos las categorias de la BD
        /// </summary>
        /// <returns></returns>
        public DataSet ObtenerTotal()
        {
            SqlParameter[] parametros =
            {
                  new SqlParameter (ParametrosConstantes.PC_NOPCION,    SqlDbType.TinyInt)
              };
            parametros[0].Value = SPOpcion.ObtenerTotal;

            return EjecutaProcedimiento(ConstantesSP.C_EspaniolNahuatl_SP, parametros, ConstantesSP.C_EspaniolNahuatl_SP);
        }
        #endregion

        #region Obtener por Clave Entidad
        /// <summary>
        /// Método que ejecuta la operacion de Búsqueda por Clave Entidad en la BD
        /// </summary>
        /// <param name="claveEntidad">Valor de Búsqueda Correspondiente a la categoria</param>
        /// <returns>DComer consultado</returns>
        public AdminPalabra ObtenerPorClaveEntidad(int claveEntidad)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter (ParametrosConstantes.PC_NOPCION,      SqlDbType.TinyInt),
                new SqlParameter(ParametrosConstantes.PC_Id,            SqlDbType.Int)
            };
            parametros[0].Value = SPOpcion.ObtenerPorClaveEntidad;
            parametros[1].Value = claveEntidad;

            return EjecutaProcedimientoOne(ConstantesSP.C_EspaniolNahuatl_SP, parametros, new AdminPalabraFactoria());
        }
        #endregion
    }
}