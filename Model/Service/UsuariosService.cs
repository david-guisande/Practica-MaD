using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.Photogram.Model.DAOs;
using Es.Udc.DotNet.Photogram.Model.DTOs;
using Ninject;

namespace Es.Udc.DotNet.Photogram.Model.Service
{
    public class UsuariosService : IUsuariosService
    {

        [Inject]
        public IUserProfileDao UsuariosDao { private get; set; }

        public long RegistrarUsuario(string loginName, string clearPassword, string nombre, string email, string pais, string idioma)
        {
            try
            {
                UsuariosDao.FindByLoginName(loginName);
                throw new Exception();
            }
            catch (Exception)
            {

                Usuarios user = new Usuarios();

                user.loginName = loginName;
                user.password = clearPassword;
                user.name = nombre;
                user.email = email;
                user.pais = pais;
                user.idioma = idioma;

                UsuariosDao.Create(user);

                return user.usrId;
            }
        }

        public UsuariosDto Autenticar(string loginName, string clearPassword)
        {
            try
            {
                Usuarios user = UsuariosDao.FindByLoginName(loginName);
                if (clearPassword == user.password)
                    return (UsuariosDto) user;
                else return null;
            }
            catch (InstanceNotFoundException)
            {
                return null;
            }
        }

        public UsuariosDto[] VerSeguidores(Int64 usrId, int npag)
        {
            Usuarios[] seguidores = UsuariosDao.GetSeguidores(usrId, npag);
            UsuariosDto[] res = new UsuariosDto[seguidores.Length];
         
            for (int i = 0; i < seguidores.Length; i++)
            {
                res[i] = seguidores[i];
            }

            return res;
        }

        public UsuariosDto[] VerSeguidos(Int64 usrId, int npag)
        {
            Usuarios[] seguidos = UsuariosDao.GetSeguidos(usrId, npag);
            UsuariosDto[] res = new UsuariosDto[seguidos.Length];

            for (int i = 0; i < seguidos.Length; i++)
            {
                res[i] = seguidos[i];
            }

            return res;
        }

        public void SeguirA(Int64 usrIdSeguidor, Int64 usrIdSeguido)
        {
            UsuariosDao.SeguirA(usrIdSeguidor, usrIdSeguido);
        }
    }
}
