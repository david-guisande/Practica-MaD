using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System;

namespace Es.Udc.DotNet.Photogram.Model.DAOs
{
    public interface IPublicacionesDao : IGenericDao<Publicaciones, Int64>
    {
        Publicaciones[] Buscar(string palabras);
        Publicaciones[] Buscar(string palabras, string categoria);
        Publicaciones[] GetPubliUsuario(Int64 usrId);
        int Favs(long pubId);
    }
}