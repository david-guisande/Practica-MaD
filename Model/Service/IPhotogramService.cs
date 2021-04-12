using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.Photogram.Model.Service
{
    public interface IPhotogramService
    {
        long RegistrarUsuario(string loginName, string clearPassword, string nombre, string email, string pais, string idioma);

        bool Autenticar(string loginName, string clearPassword);

        Usuarios VisualizarUsuario(Int64 usrId);

        void SeguirA(Int64 usrIdSeguidor, Int64 usrIdSeguido);

        Int64 SubirImagen(long usrId, string titulo, string descripcion, string fichero);

        Publicaciones[] BuscarImagenes(string keywords, string categoria);

        void DarMeGusta(Int64 usrId, Int64 pubId);

        Int64 Comentar(Int64 usrId, Int64 pubId, string comentario);

        void ActualizarComentario(Int64 comId, Int64 usrId, string textoNuevo);

        void EliminarComentario(Int64 comId, Int64 usrId);

        Comentarios[] VerComentarios(Int64 pubId);
    }
}
