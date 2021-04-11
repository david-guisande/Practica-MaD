using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.Photogram.Model.DAOs;
using Ninject;

namespace Es.Udc.DotNet.Photogram.Model.Service
{
    public class PhotogramService : IPhotogramService
    {

        [Inject]
        public IUserProfileDao UserProfileDao { private get; set; }

        public void ActualizarComentario(long comId, long usrId, string textoNuevo)
        {
            throw new NotImplementedException();
        }

        public bool Autenticar(string loginName, string clearPassword)
        {
            throw new NotImplementedException();
        }

        public Publicaciones[] BuscarImagenes(string keywords, string categoria)
        {
            throw new NotImplementedException();
        }

        public long Comentar(long usrId, long pubId, string comentario)
        {
            throw new NotImplementedException();
        }

        public void DarMeGusta(long usrId, long pubId)
        {
            throw new NotImplementedException();
        }

        public void EliminarComentario(long comId, long usrId)
        {
            throw new NotImplementedException();
        }

        [Transactional]
        public long RegistrarUsuario(string loginName, string clearPassword, string nombre, string email, string pais, string idioma)
        {
            try
            {
                UserProfileDao.FindByLoginName(loginName);
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

                UserProfileDao.Create(user);

                return user.usrId;
            }
        }

        public void SeguirA(long usrIdSeguidor, long usrIdSeguido)
        {
            throw new NotImplementedException();
        }

        public long SubirImagen(string titulo, string descripcion, string fichero)
        {
            throw new NotImplementedException();
        }

        public Comentarios[] VerComentarios(long pubId)
        {
            throw new NotImplementedException();
        }

        public Usuarios VisualizarUsuario(long usrId)
        {
            throw new NotImplementedException();
        }
    }
}
