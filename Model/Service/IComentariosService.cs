using Es.Udc.DotNet.Photogram.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.Photogram.Model.Service
{
    public interface IComentariosService
    {
        Int64 Comentar(Int64 usrId, Int64 pubId, string comentario);

        void ActualizarComentario(Int64 comId, Int64 usrId, string textoNuevo);

        void EliminarComentario(Int64 comId, Int64 usrId);

        ComentariosDto[] VerComentarios(Int64 pubId, int npag);
    }
}
