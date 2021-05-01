using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System;

namespace Es.Udc.DotNet.Photogram.Model.DAOs
{
    public interface IUserProfileDao : IGenericDao<Usuarios, Int64>
    {
        /// <summary>
        /// Finds a UserProfile by loginName
        /// </summary>
        /// <param name="loginName">loginName</param>
        /// <returns>The UserProfile</returns>
        /// <exception cref="InstanceNotFoundException"/>
        Usuarios FindByLoginName(String loginName);

        void SeguirA(Int64 usrIdSeguidor, Int64 usrIdSeguido);

        Usuarios[] GetSeguidos(Int64 usrId, int npag);

        Usuarios[] GetSeguidores(Int64 usrId, int npag);
        void DarFav(Int64 usrId, Int64 pubId);

    }
}
