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

        public Publicaciones[] Buscar(string palabras)
		{
            Publicaciones[] pub;
            string[] words = palabras.Split(' ');
            DbSet<Publicaciones> publicaciones = Context.Set<Publicaciones>();

            var request =
                (from p in publicaciones
                 select p);

            request = request.Where(new Func<Publicaciones,bool> (p => 
            {
                bool r = false;
                foreach (string w in words)
				{
                    r |= p.descripcion.Contains(w);
                    r |= p.titulo.Contains(w);
                }
                return r;
            })).AsQueryable<Publicaciones>();

            pub = request.ToList().ToArray();
            return pub;
        }
        public Publicaciones[] Buscar(string palabras, string categoria)
		{
            Publicaciones[] pub;
            string[] words = palabras.Split(' ');
            DbSet<Publicaciones> publicaciones = Context.Set<Publicaciones>();

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

            pub = request.ToList().ToArray();
            return pub;

        }

        public Publicaciones[] GetPubliUsuario(Int64 usrId)
		{
            DbSet<Usuarios> userProfiles = Context.Set<Usuarios>();
            var result = (from u in userProfiles.Include("Publicaciones")
                          where u.usrId == usrId
                          select u);
            Usuarios usr = result.FirstOrDefault();
            return usr.Publicaciones.ToArray<Publicaciones>();
        }

        public int Favs(long pubId)
		{
            DbSet<Publicaciones> publicaciones = Context.Set<Publicaciones>();

            var request =
                (from p in publicaciones.Include("Usuarios1")
                 where p.Id == pubId
                 select p);
            Publicaciones pub = request.FirstOrDefault();
            return pub.Usuarios1.Count;
        }

    }
}
