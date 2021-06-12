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

        /// <exception cref="InstanceNotFoundException"/>
        void SeguirA(Int64 usrIdSeguidor, Int64 usrIdSeguido);
        /// <exception cref="InstanceNotFoundException"/>
        Usuarios[] GetSeguidos(Int64 usrId, int npag);
        /// <exception cref="InstanceNotFoundException"/>
        Usuarios[] GetSeguidores(Int64 usrId, int npag);
        /// <exception cref="InstanceNotFoundException"/>
        void DarFav(Int64 usrId, Int64 pubId);

    }
}
