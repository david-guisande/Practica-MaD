using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System;

namespace Es.Udc.DotNet.Photogram.Model.DAOs
{
    public interface IEtiquetasDao : IGenericDao<EtiquetaSet, string>
    {
        Publicaciones[] GetPublicaciones(string tag, int npag);

        EtiquetaSet[] GetEtiquetas(long pubId);

        void Etiquetar(string tag, long pubId);

        void Desetiquetar(string tag, long pubId);
    }
}