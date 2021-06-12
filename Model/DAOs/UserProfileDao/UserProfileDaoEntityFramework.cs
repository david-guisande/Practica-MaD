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
                throw new InstanceNotFoundException(loginName,"Usuarios");

            return userProfile;
        }

        /// <exception cref="InstanceNotFoundException"></exception>
        public void SeguirA(Int64 usrIdSeguidor, Int64 usrIdSeguido)
		{
            Usuarios seguidor;

            try
            {
                DbSet<Usuarios> userProfiles = Context.Set<Usuarios>();
                var result = (from u in userProfiles.Include("Seguidos")
                              where u.usrId == usrIdSeguidor
                              select u);

                seguidor = result.FirstOrDefault();
                Usuarios seguido = Find(usrIdSeguido);

                seguidor.Seguidos.Add(seguido);
                Update(seguidor);
            }
            catch (ArgumentNullException)
            {
                throw new InstanceNotFoundException((usrIdSeguidor, usrIdSeguido), "Usuarios");
            }
        }

        /// <exception cref="InstanceNotFoundException"></exception>
        public Usuarios[] GetSeguidos(Int64 usrId, int npag)
		{
            DbSet<Usuarios> userProfiles = Context.Set<Usuarios>();
            try
            {
                var result = (from u in userProfiles.Include("Seguidos")
                              where u.usrId == usrId
                              select u);
                Usuarios seguidor = result.FirstOrDefault();
                return seguidor.Seguidos.Skip(10 * npag).Take(10).ToArray<Usuarios>();
            }
            catch (ArgumentNullException)
            {
                throw new InstanceNotFoundException(usrId, "Usuarios");
            }
        }

        /// <exception cref="InstanceNotFoundException"></exception>
        public Usuarios[] GetSeguidores(Int64 usrId, int npag)
		{
            DbSet<Usuarios> userProfiles = Context.Set<Usuarios>();
            try
            {
                var result = (from u in userProfiles.Include("Seguidores")
                              where u.usrId == usrId
                              select u);
                Usuarios seguido = result.FirstOrDefault();
                return seguido.Seguidores.Skip(10 * npag).Take(10).ToArray<Usuarios>();
            }
            catch (ArgumentNullException)
            {
                throw new InstanceNotFoundException(usrId, "Usuarios");
            }
        }

        /// <exception cref="InstanceNotFoundException"></exception>
        public void DarFav(Int64 usrId, Int64 pubId)
        {
            DbSet<Usuarios> userProfiles = Context.Set<Usuarios>();
            DbSet<Publicaciones> publicaciones = Context.Set<Publicaciones>();

            try
            {
                var result = (from u in userProfiles.Include("PublicacionesGustadas")
                              where u.usrId == usrId
                              select u);
                Usuarios usr = result.FirstOrDefault();

                try
                {
                    var result2 = (from p in publicaciones
                                   where p.Id == pubId
                                   select p);
                    Publicaciones pub = result2.FirstOrDefault();

                    usr.PublicacionesGustadas.Add(pub);
                    Update(usr);
                }
                catch (ArgumentNullException)
                {
                    throw new InstanceNotFoundException(pubId, "Publicaciones");
                }
            }
            catch (ArgumentNullException)
            {
                throw new InstanceNotFoundException(usrId, "Usuarios");
            }
        }

        #endregion IUserProfileDao Members
    }
}
