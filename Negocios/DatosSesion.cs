using System;

namespace DicEspNahuatl.Datos.Negocios
{
    [Serializable]
    public class DatosSesion
    {
        #region PROPIEDADES

        /// <summary>
        /// Variable que controla el email del usuario
        /// </summary>
        private string _emailUsuario;
        /// <summary>
        /// Propiedad para el control del
        /// Email del usuario
        /// </summary>
        public string EmailUsuario
        {
            set { _emailUsuario = value; }
            get { return _emailUsuario; }
        }

        /// <summary>
        /// Variable que controla la clave del usuario en sesion
        /// </summary>
        private int _cveEntUsuario;
        /// <summary>
        /// Propiedad para elcontrol de la calve del
        /// usuario en sesión
        /// </summary>
        public int CveEntUsuario
        {
            set { _cveEntUsuario = value; }
            get { return _cveEntUsuario; }
        }

        /// <summary>
        /// Variable que controla el tipo de usuario (Permisos de usuario)
        /// </summary>
        private byte _tipoUsuario;
        /// <summary>
        /// Propiedad para el control del tipo de usuario
        /// </summary>
        public byte TipoUsuario
        {
            set { _tipoUsuario = value; }
            get { return _tipoUsuario; }
        }

        #endregion
    }
}
