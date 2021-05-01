using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;

namespace Es.Udc.DotNet.Photogram.Model.DAOs
{
    /// <summary>
    /// Specific Operations for UserProfile
    /// </summary>
    public class UserProfileDaoEntityFramework :
        GenericDaoEntityFramework<Usuarios, Int64>, IUserProfileDao
    {
        #region Public Constructors

        /// <summary>
        /// Public Constructor
        /// </summary>
        public UserProfileDaoEntityFramework()
        {
        }

        #endregion Public Constructors

        #region IUserProfileDao Members. Specific Operations

        /// <summary>
        /// Finds a UserProfile by his loginName
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        /// <exception cref="InstanceNotFoundException"></exception>
        public Usuarios FindByLoginName(string loginName)
        {
            Usuarios userProfile = null;

            DbSet<Usuarios> userProfiles = Context.Set<Usuarios>();

            var result =
                (from u in userProfiles
                 where u.loginName == loginName
                 select u);

            userProfile = result.FirstOrDefault();

            if (userProfile == null)
                throw new InstanceNotFoundException(loginName,
                    typeof(Usuarios).FullName);

            return userProfile;
        }

        public void SeguirA(Int64 usrIdSeguidor, Int64 usrIdSeguido)
		{
            Usuarios seguidor;

            DbSet<Usuarios> userProfiles = Context.Set<Usuarios>();
            var result = (from u in userProfiles.Include("Seguidos")
                          where u.usrId == usrIdSeguidor
                          select u);

            seguidor = result.FirstOrDefault();
            Usuarios seguido = Find(usrIdSeguido);

            seguidor.Seguidos.Add(seguido);
            Update(seguidor);
        }

        public Usuarios[] GetSeguidos(Int64 usrId, int npag)
		{
            DbSet<Usuarios> userProfiles = Context.Set<Usuarios>();
            var result = (from u in userProfiles.Include("Seguidos")
                          where u.usrId == usrId
                          select u);
            Usuarios seguidor = result.FirstOrDefault();
            return seguidor.Seguidos.Skip(10*npag).Take(10).ToArray<Usuarios>();
        }

        public Usuarios[] GetSeguidores(Int64 usrId, int npag)
		{
            DbSet<Usuarios> userProfiles = Context.Set<Usuarios>();
            var result = (from u in userProfiles.Include("Seguidores")
                          where u.usrId == usrId
                          select u);
            Usuarios seguido = result.FirstOrDefault();
            return seguido.Seguidores.Skip(10*npag).Take(10).ToArray<Usuarios>();
        }

        public void DarFav(Int64 usrId, Int64 pubId)
        {
            DbSet<Usuarios> userProfiles = Context.Set<Usuarios>();
            var result = (from u in userProfiles.Include("PublicacionesGustadas")
                          where u.usrId == usrId
                          select u);

            DbSet<Publicaciones> publicaciones = Context.Set<Publicaciones>();
            var result2 = (from p in publicaciones
                          where p.Id == pubId
                          select p);

            Usuarios usr = result.FirstOrDefault();
            Publicaciones pub = result2.FirstOrDefault();
            usr.PublicacionesGustadas.Add(pub);
            Update(usr);
        }

        #endregion IUserProfileDao Members


    }
}
