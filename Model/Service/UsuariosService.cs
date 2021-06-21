using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.Photogram.Model.DAOs;
using Es.Udc.DotNet.Photogram.Model.DTOs;
using Ninject;
using System;

namespace Es.Udc.DotNet.Photogram.Model.Service
{
    public class UsuariosService : IUsuariosService
    {

        [Inject]
        public IUserProfileDao UsuariosDao { private get; set; }

        /// <exception cref="InstanceNotFoundException"/>
        public long RegistrarUsuario(string loginName, string clearPassword, string nombre, string email, string pais, string idioma)
        {
            try
            {
                UsuariosDao.FindByLoginName(loginName);
            }
            catch (InstanceNotFoundException)
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
            throw new InstanceNotFoundException(loginName,"Usuarios");
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
            catch (InstanceNotFoundException) { return null; }
        }

        public UsuariosDto Usuario(long id)
        {
            return UsuariosDao.Find(id);
        }

        /// <exception cref="InstanceNotFoundException"/>
        public UsuariosDto[] VerSeguidores(Int64 usrId, int npag, int pagLen)
        {
            Usuarios[] seguidores = UsuariosDao.GetSeguidores(usrId, npag, pagLen);
            UsuariosDto[] res = new UsuariosDto[seguidores.Length];
         
            for (int i = 0; i < seguidores.Length; i++)
                res[i] = seguidores[i];

            return res;
        }

        /// <exception cref="InstanceNotFoundException"/>
        public UsuariosDto[] VerSeguidos(Int64 usrId, int npag, int pagLen)
        {
            Usuarios[] seguidos = UsuariosDao.GetSeguidos(usrId, npag, pagLen);
            UsuariosDto[] res = new UsuariosDto[seguidos.Length];

            for (int i = 0; i < seguidos.Length; i++)
                res[i] = seguidos[i];

            return res;
        }

        /// <exception cref="InstanceNotFoundException"/>
        public void SeguirA(Int64 usrIdSeguidor, Int64 usrIdSeguido)
        {
            UsuariosDao.SeguirA(usrIdSeguidor, usrIdSeguido);
        }

        /// <exception cref="InstanceNotFoundException"></exception>
        public bool Siguiendo(Int64 usrIdSeguidor, Int64 usrIdSeguido)
        {
            return UsuariosDao.Siguiendo(usrIdSeguidor, usrIdSeguido);
        }

        public void ActualizarUsuario(Int64 id,  string loginName, string clearPassword, string nombre, string email, string pais, string idioma)
        {
            Usuarios user = UsuariosDao.Find(id);
            user.loginName = loginName;
            user.password = clearPassword;
            user.name = nombre;
            user.email = email;
            user.pais = pais;
            user.idioma = idioma;

            UsuariosDao.Update(user);
        }
    }
}
