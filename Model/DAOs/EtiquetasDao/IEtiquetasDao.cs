using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System;

namespace Es.Udc.DotNet.Photogram.Model.DAOs
{
    public interface IEtiquetasDao : IGenericDao<EtiquetaSet, string>
    {
        /// <exception cref="InstanceNotFoundException"></exception>
        Publicaciones[] GetPublicaciones(string tag, int npag);

        /// <exception cref="InstanceNotFoundException"></exception>
        EtiquetaSet[] GetEtiquetas(long pubId);

        /// <exception cref="InstanceNotFoundException"></exception>
        void Etiquetar(string tag, long pubId);

        /// <exception cref="InstanceNotFoundException"></exception>
        void Desetiquetar(string tag, long pubId);

        /// <exception cref="InstanceNotFoundException"></exception>
        int GetNumPublicaciones(string tag);
    }
}