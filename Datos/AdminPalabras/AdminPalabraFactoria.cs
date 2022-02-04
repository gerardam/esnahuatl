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
    internal class AdminPalabraFactoria : IDomainObjectFactory<AdminPalabra>
    {
        public AdminPalabra Construct(IDataReader reader)
        {
            if (reader == null) throw new Exception(CamposConstantes.C_ObjetoLectura);
            AdminPalabra palabra = new AdminPalabra();

            int claveEntidadIndex = reader.GetOrdinal(CamposConstantes.C_Id);
            if (!reader.IsDBNull(claveEntidadIndex))
                palabra.ClaveEntidad = reader.GetInt32(claveEntidadIndex);

            int descripcionIndex = reader.GetOrdinal(CamposConstantes.C_Espaniol);
            if (!reader.IsDBNull(descripcionIndex))
                palabra.Espaniol = reader.GetString(descripcionIndex);

            int nahuatlIndex = reader.GetOrdinal(CamposConstantes.C_Nahuatl);
            if (!reader.IsDBNull(nahuatlIndex))
                palabra.Nahuatl = reader.GetString(nahuatlIndex);

            int tipoIndex = reader.GetOrdinal(CamposConstantes.C_Tipo);
            if (!reader.IsDBNull(tipoIndex))
                palabra.Tipo = reader.GetString(tipoIndex);

            int urlIndex = reader.GetOrdinal(CamposConstantes.C_Url);
            if (!reader.IsDBNull(urlIndex))
                palabra.URL = reader.GetString(urlIndex);

            int comentariosIndex = reader.GetOrdinal(CamposConstantes.C_Comentarios);
            if (!reader.IsDBNull(comentariosIndex))
                palabra.Comentarios = reader.GetString(comentariosIndex);

            return palabra;
        }
    }
}