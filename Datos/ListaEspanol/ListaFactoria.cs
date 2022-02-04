using System;
using System.Data;
using DicEspNahuatl.Datos.Recursos;

namespace DicEspNahuatl.Datos
{
    internal class ListaFactoria : IDomainObjectFactory<Lista>
    {
        public Lista Construct(IDataReader reader)
        {
            if (reader == null) throw new Exception(CamposConstantes.C_ObjetoLectura);
            Lista lista = new Lista();

            int claveEntidadIndex = reader.GetOrdinal(CamposConstantes.C_Id);
            if (!reader.IsDBNull(claveEntidadIndex))
            {
                lista.ClaveEntidad = reader.GetInt32(claveEntidadIndex);
            }

            int descripcionIndex = reader.GetOrdinal(CamposConstantes.C_Espaniol);
            if (!reader.IsDBNull(descripcionIndex))
            {
                lista.Descripcion = reader.GetString(descripcionIndex);
            }

            return lista;
        }
    }
}
