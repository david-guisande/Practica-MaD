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
    public class ComentariosDaoEntityFramework :
        GenericDaoEntityFramework<Comentarios, Int64>, IComentariosDao
    {
        #region Public Constructors

        /// <summary>
        /// Public Constructor
        /// </summary>
        public ComentariosDaoEntityFramework()
        {
        }

        #endregion Public Constructors
        public Comentarios[] GetComentariosPubli(Int64 pubId, int npag)
		{
            DbSet<Publicaciones> publicaciones = Context.Set<Publicaciones>();
            var result = (from p in publicaciones.Include("Comentarios")
                           where p.Id == pubId
                           select p);
            Publicaciones pub = result.FirstOrDefault();
            return pub.Comentarios.OrderByDescending(c => c.fecha).Skip(10 * npag).Take(10).ToArray<Comentarios>();
        }

    }
}
