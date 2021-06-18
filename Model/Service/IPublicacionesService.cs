using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.Photogram.Model.DTOs;
using System;

namespace Es.Udc.DotNet.Photogram.Model.Service
{
    public interface IPublicacionesService
    {
        Int64 SubirImagen(long usrId, string titulo, string descripcion, string categoria,double? f = null, int? ISO = null, int? t = null, int? wb = null);
        /// <exception cref="InstanceNotFoundException"/>
        PublicacionesDto[] VerPublicacionesUsuario(Int64 usrId, int npag, int pagLen);
        /// <exception cref="InstanceNotFoundException"/>
        PublicacionesDto[] BuscarImagenes(string keywords, int npag, int pagLen);
        /// <exception cref="InstanceNotFoundException"/>
        PublicacionesDto[] BuscarImagenes(string keywords, string categoria, int npag, int pagLen);
        /// <exception cref="InstanceNotFoundException"/>
        void DarMeGusta(Int64 usrId, Int64 pubId);
        /// <exception cref="InstanceNotFoundException"/>
        int NumeroMeGusta(Int64 pubId);
        PublicacionesDto FindPublicacion(Int64 pubId);
    }
}
