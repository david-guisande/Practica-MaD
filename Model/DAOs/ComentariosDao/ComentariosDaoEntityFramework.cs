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

        /// <exception cref="InstanceNotFoundException"></exception>
        public Comentarios[] GetComentariosPubli(Int64 pubId, int npag, int pagLen)
		{
            DbSet<Publicaciones> publicaciones = Context.Set<Publicaciones>();
            try
            {
                var result = (from p in publicaciones.Include("Comentarios")
                              where p.Id == pubId
                              select p);
                Publicaciones pub = result.FirstOrDefault();
                return pub.Comentarios.OrderByDescending(c => c.fecha).Skip(pagLen * npag).Take(pagLen).ToArray<Comentarios>();
            }
            catch (ArgumentNullException)
            {
                throw new InstanceNotFoundException(pubId, "Publicaciones");
            }
        }

    }
}
