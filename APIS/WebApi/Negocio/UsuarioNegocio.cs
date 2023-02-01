using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class UsuarioNegocio
    {
        public static UsuarioEntidad Crear(UsuarioEntidad usuarioEntidad)
        {
            return UsuarioDatos.Crear(usuarioEntidad);
        }
        public static List<UsuarioEntidad> ListarUsuarios()
        {
            return UsuarioDatos.ListarUsuarios();
        }
        public static UsuarioEntidad ObtenerUsuarioPorId(int Id)
        {
            return UsuarioDatos.ObtenerUsuarioPorId(Id);
        }
        public static UsuarioEntidad ObtenerUsuarioLogin(LoginEntidad loginEntidad)
        {
            return UsuarioDatos.ObtenerUsuarioLogin(loginEntidad);
        }
        public static UsuarioEntidad Actualizar(UsuarioEntidad usuarioEntidad)
        {
            return UsuarioDatos.Actualizar(usuarioEntidad);
        }
        public static bool Eliminar(int Id)
        {
            return UsuarioDatos.Eliminar(Id);
        }
    }
}
