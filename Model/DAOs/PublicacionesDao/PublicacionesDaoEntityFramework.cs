using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.Photogram.Model.DTOs;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;

namespace Es.Udc.DotNet.Photogram.Model.DAOs

{
    /// <summary>
    /// Specific Operations for Publicaciones
    /// </summary>
    public class PublicacionesDaoEntityFramework :
        GenericDaoEntityFramework<Publicaciones, Int64>, IPublicacionesDao
    {
        #region Public Constructors

        /// <summary>
        /// Public Constructor
        /// </summary>
        public PublicacionesDaoEntityFramework()
        {
        }

        #endregion Public Constructors
        /// <exception cref="InstanceNotFoundException"></exception>
        public Publicaciones[] Buscar(string palabras, int npag, int pagLen)
		{
            Publicaciones[] pub;
            string[] words = palabras.Split(' ');
            DbSet<Publicaciones> publicaciones = Context.Set<Publicaciones>();

            try
            {
                var request =
                    (from p in publicaciones
                     select p);

                request = request.Where(new Func<Publicaciones, bool>(p =>
                {
                    bool r = false;
                    foreach (string w in words)
                    {
                        r |= p.descripcion.Contains(w);
                        r |= p.titulo.Contains(w);
                    }
                    return r;
                })).AsQueryable<Publicaciones>();

                pub = request.Skip(pagLen * npag).Take(pagLen).ToList().ToArray();
                return pub;
            }
            catch (ArgumentNullException)
            {
                throw new InstanceNotFoundException(palabras,"Publicaciones");
            }
        }

        /// <exception cref="InstanceNotFoundException"></exception>
        public Publicaciones[] Buscar(string palabras, string categoria, int npag, int pagLen)
		{
            Publicaciones[] pub;
            string[] words = palabras.Split(' ');
            DbSet<Publicaciones> publicaciones = Context.Set<Publicaciones>();

            try
            {
                var request =
                    (from p in publicaciones
                     where p.categoria == categoria
                     select p);

                request = request.Where(new Func<Publicaciones, bool>(p =>
                {
                    bool r = false;
                    foreach (string w in words)
                    {
                        r |= p.descripcion.Contains(w);
                        r |= p.titulo.Contains(w);
                    }
                    return r;
                })).AsQueryable<Publicaciones>();

                pub = request.Skip(pagLen * npag).Take(pagLen).ToList().ToArray();
                return pub;
            }
            catch (ArgumentNullException)
            {
                throw new InstanceNotFoundException(palabras,"Publicaciones");
            }
        }

        /// <exception cref="InstanceNotFoundException"></exception>
        public Publicaciones[] GetPubliUsuario(Int64 usrId, int npag, int pagLen)
		{
            DbSet<Usuarios> userProfiles = Context.Set<Usuarios>();
            try
            {
                var result = (from u in userProfiles.Include("Publicaciones")
                              where u.usrId == usrId
                              select u);
                Usuarios usr = result.FirstOrDefault();
                return usr.Publicaciones.Skip(pagLen * npag).Take(pagLen).ToArray<Publicaciones>();
            }
            catch (ArgumentNullException)
            {
                throw new InstanceNotFoundException(usrId,"Usuarios");
            }
        }

        /// <exception cref="InstanceNotFoundException"></exception>
        public int Favs(long pubId)
		{
            DbSet<Publicaciones> publicaciones = Context.Set<Publicaciones>();

            try
            {
                var request =
                    (from p in publicaciones.Include("Usuarios1")
                     where p.Id == pubId
                     select p);
                Publicaciones pub = request.FirstOrDefault();
                return pub.Usuarios1.Count;
            }
            catch (ArgumentNullException)
            {
                throw new InstanceNotFoundException(pubId, "Publicaciones");
            }
        }

    }
}
