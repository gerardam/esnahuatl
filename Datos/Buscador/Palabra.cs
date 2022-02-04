using System;

//==|    \ /    |============================================ == ==
//==|   11011   |===|  < >LocalStore v1.0 13/02/2016</ > |=== = ===
//==| =0101010= |============================================ == ==
//==| =1010101= |===|    { The bug develop & network }   |=== === =
//==| =0101010= |===| ( ){ ISC Gerardo Álvarez Mendoza } |=== == ==
//==|   00100   |============================================ = ===
namespace DicEspNahuatl.Datos
{
    public partial class Palabra
    {
        /// <summary>
        /// Metodo constructor para la clase AdminCategoria.
        /// </summary>
        public Palabra()
        {

        }

        /// <summary>
        /// Metodo constructor con parametros de la clase AdminCategoria
        /// </summary>
        /// <param name="claveEntidad"></param>
        /// <param name="descripcion"></param>
        /// <param name="claveEstado"></param>
        /// <param name="fechaCambio"></param>
        /// <param name="comentarios"></param>
        public Palabra(Int32 claveEntidad, String espaniol, String nahuatl, Byte claveEstado, DateTime fechaCambio, String comentarios)
        {
            this.claveEntidadField = claveEntidad;
            this.espaniolField = espaniol;
            this.nahuatlField = nahuatl;
            this.claveEstadoField = claveEstado;
            this.fechaCambioField = fechaCambio;
            this.comentariosField = comentarios;
        }

        private Int32 claveEntidadField;
        /// <summary>
        /// Obtiene o establece la propiedad de ClaveEntidad.
        /// </summary>
        /// <value>ClaveEntidad tipo de dato Int32.</value>
        public Int32 ClaveEntidad
        {
            get { return this.claveEntidadField; }
            set { this.claveEntidadField = value; }
        }

        private String espaniolField;
        /// <summary>
        /// Obtiene o establece la propiedad de Descripcion.
        /// </summary>
        /// <value>Descripcion tipo de dato String.</value>
        public String Espaniol
        {
            get { return this.espaniolField; }
            set { this.espaniolField = value; }
        }

        private String nahuatlField;
        /// <summary>
        /// Obtiene o establece la propiedad de Descripcion.
        /// </summary>
        /// <value>Descripcion tipo de dato String.</value>
        public String Nahuatl
        {
            get { return this.nahuatlField; }
            set { this.nahuatlField = value; }
        }

        private Byte claveEstadoField;
        /// <summary>
        /// Obtiene o establece la propiedad de ClaveEstado.
        /// </summary>
        /// <value>ClaveEstado tipo de dato Byte.</value>
        public Byte ClaveEstado
        {
            get { return this.claveEstadoField; }
            set { this.claveEstadoField = value; }
        }

        private DateTime fechaCambioField;
        /// <summary>
        /// Obtiene o establece la propiedad de FechaCambio.
        /// </summary>
        /// <value>FechaCambio tipo de dato DateTime.</value>
        public DateTime FechaCambio
        {
            get { return this.fechaCambioField; }
            set { this.fechaCambioField = value; }
        }

        private String comentariosField;
        /// <summary>
        /// Obtiene o establece la propiedad de Comentarios.
        /// </summary>
        /// <value>Comentarios tipo de dato String.</value>
        public String Comentarios
        {
            get { return this.comentariosField; }
            set { this.comentariosField = value; }
        }
    }
}