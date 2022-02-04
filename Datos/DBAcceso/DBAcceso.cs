using DicEspNahuatl.Datos.Recursos;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DicEspNahuatl.Datos
{
    public class DBAcceso<TDomainObject>
    {
        private bool disposed = false;
        /// <summary>
        /// Constante de cadena de conexion del key
        /// </summary>
        protected string keyCadenaDeConexion = string.Empty;

        /// <summary>
        /// Constante de cadena de conexion del key
        /// </summary>
        protected string esquema = string.Empty;

        /// <summary>
        /// Constructor Default
        /// </summary>
        public DBAcceso()
        {
            keyCadenaDeConexion = ParametrosConstantes.PC_DataBase;
        }

        /// <summary>
        /// Constructor con cadena de conexion explicita
        /// </summary>
        /// <param name="KeyCadenaDeConexion"></param>
        public DBAcceso(string KeyCadenaDeConexion, string esquema)
        {
            this.keyCadenaDeConexion = KeyCadenaDeConexion;
            this.esquema = esquema;
        }

        #region Cadena de conexión tal y como esta en el web.config.
        //private string cadena;
        /// <summary>
        /// Cadena de conexión tal y como esta en el web.config.
        /// </summary>
        private SqlConnection ObtenerConexion() //string cadena
        {
                return new SqlConnection(ConfigurationManager.ConnectionStrings[this.keyCadenaDeConexion].ToString());
        }
        #endregion

        #region EjecutaProcedimiento DataSet
        /// <summary>
        /// Creates a DataSet by running the stored procedure and placing the results
        /// of the query/proc into the given tablename.
        /// </summary>
        /// <param name="strProcedimiento">Nombre del Stored Procedure en la DB.</param>
        /// <param name="arrParametros">Arreglo del objeto IDataParameter que contiene los parametros en el Stored Procedure.</param>
        /// <param name="tableName">Nombre de la tabla.</param>
        /// <returns></returns>
        protected DataSet EjecutaProcedimiento(string strProcedimiento, IDataParameter[] arrParametros, string tableName)
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection cnn = ObtenerConexion())
            {
                cnn.Open();
                using (SqlDataAdapter sqlDA = new SqlDataAdapter())
                {
                    sqlDA.SelectCommand = BuildQueryCommand(strProcedimiento, arrParametros, cnn);
                    sqlDA.Fill(dataSet, tableName);
                }
                cnn.Close();
            }
            return dataSet;
        }
        #endregion

        #region EjecutaProcedimientoCrud void
        /// <summary>
        /// Ejecuta un procedimiento almacenado, sólo puede ser convocada por las clases derivadas a partir de esta base.
        /// Devuelve un entero que indica el valor de retorno de la procedimiento almacenado, y también devuelve el valor de la filasEfectadas
        /// del procedimiento almacenado que es devuelto por el método ExecuteNonQuery.
        /// </summary>
        /// <param name="strProcedimiento">Nombre del Stored Procedure en la DB.</param>
        /// <param name="arrParametros">Arreglo del objeto IDataParameter que contiene los parametros en el Stored Procedure.</param>
        /// <returns>Un entero indicando le valor regresado por el Stored Procedure.</returns>
        protected void EjecutaProcedimientoCrud(string strProcedimiento, IDataParameter[] arrParametros)
        {
            using (SqlConnection cnn = ObtenerConexion())
            {
                cnn.Open();
                using (SqlCommand command = BuildIntCommand(strProcedimiento, arrParametros, cnn))
                {
                    command.ExecuteNonQuery();
                }
                cnn.Close();
            }
        }
        #endregion

        #region EjecutaProcedimiento List
        /// <summary>
        /// Se ejecutará un procedimiento almacenado, sólo puede ser convocada por las clases derivadas a partir de esta base.
        /// Devuelve un List que contenga el resultado del procedimiento almacenado.
        /// </summary>
        /// <param name="strProcedimiento">Nombre del Stored Procedure en la DB.</param>
        /// <param name="arrParametros">Arreglo del objeto IDataParameter que contiene los parametros en el Stored Procedure.</param>
        /// <param name="domainObjectFactory">Objeto Factory que puede transformar el conjunto de resultados devueltos en un objeto de dominio</param>
        /// <returns></returns>
        protected List<TDomainObject> EjecutaProcedimiento(string strProcedimiento, IDataParameter[] arrParametros, IDomainObjectFactory<TDomainObject> domainObjectFactory)
        {
            List<TDomainObject> returnListReader = new List<TDomainObject>();
            using (SqlConnection cnn = ObtenerConexion())
            {
                cnn.Open();
                using (SqlCommand command = BuildIntCommand(strProcedimiento, arrParametros, cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (IDataReader rdr = command.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            returnListReader.Add(domainObjectFactory.Construct(rdr));
                        }
                    }
                }
                cnn.Close();
            }
            return returnListReader;
        }
        #endregion

        #region EjecutaProcedimientoOne
        /// <summary>
        ///
        /// </summary>
        /// <param name="strProcedimiento">Nombre del Stored Procedure en la DB.</param>
        /// <param name="arrParametros">Arreglo del objeto IDataParameter que contiene los parametros en el Stored Procedure.</param>
        /// <param name="domainObjectFactory">Objeto Factory que puede transformar el conjunto de resultados devueltos en un objeto de dominio</param>
        /// <returns></returns>
        protected TDomainObject EjecutaProcedimientoOne(string strProcedimiento, IDataParameter[] arrParametros, IDomainObjectFactory<TDomainObject> domainObjectFactory)
        {//RunProcedimientoOne
            TDomainObject result = default(TDomainObject);

            using (SqlConnection cnn = ObtenerConexion())
            {
                cnn.Open();
                using (SqlCommand command = BuildIntCommand(strProcedimiento, arrParametros, cnn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (IDataReader rdr = command.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            result = domainObjectFactory.Construct(rdr);
                        }
                    }

                }
                cnn.Close();
            }
            return result;
        }
        #endregion

        #region Construye un SqlCommand diseñado
        /// <summary>
        /// Construye un SqlCommand diseñados para devolver un SqlDataReader, y no un valor real.
        /// </summary>
        /// <param name="strProcedimiento">Nombre del Stored Procedure en la DB.</param>
        /// <param name="arrParametros">Arreglo del objeto IDataParameter que contiene los parametros en el Stored Procedure.</param>
        /// <returns>Regresa un SqlDataReader</returns>
        protected SqlCommand BuildQueryCommand(string strProcedimiento, IDataParameter[] arrParametros, SqlConnection cnn)
        {
            SqlCommand command = new SqlCommand(esquema + strProcedimiento, cnn);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in arrParametros)
            {
                command.Parameters.Add(parameter);
            }
            command.CommandTimeout = 0;
            return command;
        }
        #endregion

        #region Construcción de objeto SqlCommand
        /// <summary>
        /// Metodo privada para esta clase de base permite, automatiza la tarea
        /// de la construcción de un objeto SqlCommand para obtener un valor de retorno de el procedimiento almacenado.
        /// </summary>
        /// <param name="strProcedimiento">Nombre del Stored Procedure en la DB.</param>
        /// <param name="arrParametros">Arreglo del objeto IDataParameter que contiene los parametros en el Stored Procedure.</param>
        /// <returns>Newly instantiated SqlCommand instance</returns>
        protected SqlCommand BuildIntCommand(string strProcedimiento, IDataParameter[] arrParametros, SqlConnection cnn)
        {
            SqlCommand command = BuildQueryCommand(strProcedimiento, arrParametros, cnn);
            return command;
        }
        #endregion

    }
}
