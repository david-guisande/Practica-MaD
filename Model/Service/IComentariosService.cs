using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.Photogram.Model.DTOs;
using System;

namespace Es.Udc.DotNet.Photogram.Model.Service
{
    public interface IComentariosService
    {
        Int64 Comentar(Int64 usrId, Int64 pubId, string comentario);
        void ActualizarComentario(Int64 comId, Int64 usrId, string textoNuevo);
        void EliminarComentario(Int64 comId, Int64 usrId);
        /// <exception cref="InstanceNotFoundException"/>
        ComentariosDto[] VerComentarios(Int64 pubId, int npag, int pagLen);
    }
}
