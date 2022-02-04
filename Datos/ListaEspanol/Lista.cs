using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicEspNahuatl.Datos
{
    public partial class Lista
    {
        #region CONSTRUCTORES
        public Lista()
        {
        }
        #endregion

        #region PROPIEDADES
        private Int32 claveEntidadField;
        public Int32 ClaveEntidad
        {
            get { return this.claveEntidadField; }
            set { this.claveEntidadField = value; }
        }

        private String descripcionField;
        public String Descripcion
        {
            get { return this.descripcionField; }
            set { this.descripcionField = value; }
        }
        #endregion
    }
}
