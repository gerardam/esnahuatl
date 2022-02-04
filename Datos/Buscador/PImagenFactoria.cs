using DicEspNahuatl.Datos.Recursos;
using System;
using System.Data;

namespace DicEspNahuatl.Datos
{
    internal class PImagenFactoria : IDomainObjectFactory<PImagen>
    {
        public PImagen Construct(IDataReader reader)
        {
            if (reader == null) throw new Exception(CamposConstantes.C_ObjetoLectura);
            PImagen pImage = new PImagen();

            int archivoIndex = reader.GetOrdinal(CamposConstantes.C_Imagen);
            if (!reader.IsDBNull(archivoIndex))
            {
                byte[] archivo = (byte[])reader[archivoIndex];
                pImage.PImage = archivo;
            }

            return pImage;
        }
    }
}
