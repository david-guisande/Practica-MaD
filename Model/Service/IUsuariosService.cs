using Es.Udc.DotNet.Photogram.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.Photogram.Model.Service
{
    interface IUsuariosService
    {
        long RegistrarUsuario(string loginName, string clearPassword, string nombre, string email, string pais, string idioma);

        bool Autenticar(string loginName, string clearPassword);

        UsuariosDto[] VerSeguidores(Int64 usrId);

        UsuariosDto[] VerSeguidos(Int64 usrId);

        void SeguirA(Int64 usrIdSeguidor, Int64 usrIdSeguido);
    }
}
