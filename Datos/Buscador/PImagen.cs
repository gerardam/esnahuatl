using System;

namespace DicEspNahuatl.Datos
{
    public class PImagen
    {
        #region CONSTRUCTORES

        /// <summary>
        /// Metodo constructor para la clase LogoComercio.
        /// </summary>
        public PImagen()
        {
        }

        /// <summary>
        ///  Constructor de la clase
        /// </summary>
        /// <param name="_rol">Valor para la empresaReporte</param>
        /// <param name="_funcionalidad"> Valor para la funcionalidad</param>
        public PImagen(Byte[] pImage)
        {
            this.pImageField = pImage;
        }
        #endregion

        #region PROPIEDADES

        private Byte[] pImageField;
        /// <summary>
        /// Obtiene o establece la propiedad de logo
        /// </summary>
        /// <value>ClaveEntidad tipo de dato String.</value>
        public Byte[] PImage
        {
            get { return this.pImageField; }
            set { this.pImageField = value; }
        }

        #endregion
    }
}
