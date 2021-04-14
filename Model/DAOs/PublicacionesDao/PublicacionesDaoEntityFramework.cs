using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
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

            request = (IQueryable<Publicaciones>)request.Where(new Func<Publicaciones,bool> (p => 
            {
                bool r = false;
                foreach (string w in words)
				{
                    r |= p.descripcion.Contains(w);
                    r |= p.titulo.Contains(w);
                }
                return r;
            }));

            pub = request.ToList().ToArray();

            if (pub.Length == 0)
                throw new InstanceNotFoundException(palabras, typeof(Publicaciones).FullName);

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

            request = (IQueryable<Publicaciones>)request.Where(new Func<Publicaciones, bool>(p =>
            {
                bool r = false;
                foreach (string w in words)
                {
                    r |= p.descripcion.Contains(w);
                    r |= p.titulo.Contains(w);
                }
                return r;
            }));

            pub = request.ToList().ToArray();

            if (pub.Length == 0)
                throw new InstanceNotFoundException(palabras, typeof(Publicaciones).FullName);

            return pub;

        }

    }
}
