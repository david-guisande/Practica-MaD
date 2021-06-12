using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.Photogram.Model.DTOs;
using System;

namespace Es.Udc.DotNet.Photogram.Model.Service
{
    public interface IUsuariosService
    {
        /// <exception cref="InstanceNotFoundException"/>
        long RegistrarUsuario(string loginName, string clearPassword, string nombre, string email, string pais, string idioma);
        UsuariosDto Autenticar(string loginName, string clearPassword);
        UsuariosDto Usuario(long id);
        /// <exception cref="InstanceNotFoundException"/>
        UsuariosDto[] VerSeguidores(Int64 usrId, int npag);
        /// <exception cref="InstanceNotFoundException"/>
        UsuariosDto[] VerSeguidos(Int64 usrId, int npag);
        /// <exception cref="InstanceNotFoundException"/>
        void SeguirA(Int64 usrIdSeguidor, Int64 usrIdSeguido);
        void ActualizarUsuario(Int64 id, string loginName, string clearPassword, string nombre, string email, string pais, string idioma);
    }
}
