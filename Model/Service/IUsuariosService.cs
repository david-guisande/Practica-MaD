using Es.Udc.DotNet.Photogram.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.Photogram.Model.Service
{
    public interface IUsuariosService
    {
        long RegistrarUsuario(string loginName, string clearPassword, string nombre, string email, string pais, string idioma);

        UsuariosDto Autenticar(string loginName, string clearPassword);

        UsuariosDto Usuario(long id);

        UsuariosDto[] VerSeguidores(Int64 usrId, int npag);

        UsuariosDto[] VerSeguidos(Int64 usrId, int npag);

        void SeguirA(Int64 usrIdSeguidor, Int64 usrIdSeguido);

        void ActualizarUsuario(Int64 id, string loginName, string clearPassword, string nombre, string email, string pais, string idioma);
    }
}
