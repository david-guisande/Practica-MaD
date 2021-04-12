using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.Photogram.Model.DAOs;
using Ninject;

namespace Es.Udc.DotNet.Photogram.Model.Service
{
    public class PhotogramService : IPhotogramService
    {

        [Inject]
        public IUserProfileDao UserProfileDao { private get; set; }
        [Inject]
        public IPublicacionesDao PublicacionesDao { private get; set; }
        [Inject]
        public IComentariosDao ComentariosDao { private get; set; }

        public void ActualizarComentario(long comId, long usrId, string textoNuevo)
        {
            throw new NotImplementedException();
        }

        public bool Autenticar(string loginName, string clearPassword)
        {
            try
			{
                Usuarios user = UserProfileDao.FindByLoginName(loginName);
                if (clearPassword == user.password)
                    return true;
                else return false;
            }
            catch(InstanceNotFoundException)
			{
                return false;
			}
        }

        public Publicaciones[] BuscarImagenes(string keywords, string categoria)
        {
            if (categoria == null)
                return PublicacionesDao.Buscar(keywords);
            else return PublicacionesDao.Buscar(keywords, categoria);
        }

        public long Comentar(long usrId, long pubId, string comentario)
        {
            Comentarios com = new Comentarios();
            com.Usuario = usrId;
            com.PublicacionId = pubId;
            com.texto = comentario;

            ComentariosDao.Create(com);
            return com.Id;
        }

        public void DarMeGusta(long usrId, long pubId)
        {
            throw new NotImplementedException();
        }

        public void EliminarComentario(long comId, long usrId)
        {
            Comentarios com = ComentariosDao.Find(comId);
            if (com.Usuario == usrId) ComentariosDao.Remove(comId);
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

        public long SubirImagen(long usrId, string titulo, string descripcion, string fichero)
        {
            Publicaciones publi = new Publicaciones();
            publi.Usuario = usrId;
            publi.imagen = "/home/david/Escriorio/a.png";
            publi.titulo = "imagen";
            publi.descripcion = "Una imagen mia";
            publi.categoria = "paisaje";
            publi.fecha = new TimeSpan();

            PublicacionesDao.Create(publi);
            return publi.Id;
        }

        public Comentarios[] VerComentarios(long pubId)
        {
            Publicaciones publi = PublicacionesDao.Find(pubId);
            return publi.Comentarios.ToArray();
        }

        public Usuarios VisualizarUsuario(long usrId)
        {
            return UserProfileDao.Find(usrId);
        }
    }
}
