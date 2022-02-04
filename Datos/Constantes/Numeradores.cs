//==|    \ /    |============================================ == ==
//==|   11011   |===|  < >LocalStore v1.0 13/02/2016</ > |=== = ===
//==| =0101010= |============================================ == ==
//==| =1010101= |===|    { The bug develop & network }   |=== === =
//==| =0101010= |===| ( ){ ISC Gerardo Álvarez Mendoza } |=== == ==
//==|   00100   |============================================ = ===
namespace DicEspNahuatl.Datos.Numeradores
{
    /// <summary>
    /// Opciones de tipo de accion a ejecutar
    /// </summary>
    public enum VistaActivo
    {
        Grid = 0,
        Campos = 1
    }

    /// <summary>
    /// Opciones de tipo de accion a ejecutar
    /// </summary>
    public enum AccionTipo
    {
        Agregar = 1,
        Modificar = 2
    }

    /// <summary>
    /// Opciones de tipo de accion a ejecutar
    /// </summary>
    public enum CveEstado
    {
        Inactivo = 0,
        Activo = 1
    }

    /// <summary>
    /// Opciones de tipo de usuario de acceso
    /// </summary>
    public enum TipoUsuario
    {
        Administrador = 1,
        Responsable = 2,
        Usuario = 3
    }
}
