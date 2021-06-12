using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System;

namespace Es.Udc.DotNet.Photogram.Model.DAOs
{
    public interface IPublicacionesDao : IGenericDao<Publicaciones, Int64>
    {
        /// <exception cref="InstanceNotFoundException"></exception>
        Publicaciones[] Buscar(string palabras, int npag);
        /// <exception cref="InstanceNotFoundException"></exception>
        Publicaciones[] Buscar(string palabras, string categoria, int npag);
        /// <exception cref="InstanceNotFoundException"></exception>
        Publicaciones[] GetPubliUsuario(Int64 usrId, int npag);
        /// <exception cref="InstanceNotFoundException"></exception>
        int Favs(long pubId);
    }
}