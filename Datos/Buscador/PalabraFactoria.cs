using System;
using System.Data;
using DicEspNahuatl.Datos.Recursos;

//==|    \ /    |============================================ == ==
//==|   11011   |===|  < >LocalStore v1.0 13/02/2016</ > |=== = ===
//==| =0101010= |============================================ == ==
//==| =1010101= |===|    { The bug develop & network }   |=== === =
//==| =0101010= |===| ( ){ ISC Gerardo Álvarez Mendoza } |=== == ==
//==|   00100   |============================================ = ===
namespace DicEspNahuatl.Datos
{
    internal class PalabraFactoria : IDomainObjectFactory<Palabra>
    {
        public Palabra Construct(IDataReader reader)
        {
            if (reader == null) throw new Exception(CamposConstantes.C_ObjetoLectura);
            Palabra palabra = new Palabra();

            int claveEntidadIndex = reader.GetOrdinal(CamposConstantes.C_Id);
            if (!reader.IsDBNull(claveEntidadIndex))
                palabra.ClaveEntidad = reader.GetInt32(claveEntidadIndex);

            int descripcionIndex = reader.GetOrdinal(CamposConstantes.C_Espaniol);
            if (!reader.IsDBNull(descripcionIndex))
                palabra.Espaniol = reader.GetString(descripcionIndex);

            int nahuatlIndex = reader.GetOrdinal(CamposConstantes.C_Nahuatl);
            if (!reader.IsDBNull(nahuatlIndex))
                palabra.Nahuatl = reader.GetString(nahuatlIndex);

            int comentariosIndex = reader.GetOrdinal(CamposConstantes.C_Comentarios);
            if (!reader.IsDBNull(comentariosIndex))
                palabra.Comentarios = reader.GetString(comentariosIndex);

            return palabra;
        }
    }
}