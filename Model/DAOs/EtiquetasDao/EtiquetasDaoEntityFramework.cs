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
    public class EtiquetasDaoEntityFramework :
        GenericDaoEntityFramework<EtiquetaSet, string>, IEtiquetasDao
    {
        #region Public Constructors

        /// <summary>
        /// Public Constructor
        /// </summary>
        public EtiquetasDaoEntityFramework()
        {
            
        }

        #endregion Public Constructors

        /// <exception cref="InstanceNotFoundException"></exception>
        public Publicaciones[] GetPublicaciones(string tag, int npag, int pagLen)
        {
            DbSet<EtiquetaSet> etiq = Context.Set<EtiquetaSet>();

            try
            {
                var request =
                    (from e in etiq.Include("Publicaciones")
                     where e.tag == tag
                     select e);
                EtiquetaSet etiqueta = request.FirstOrDefault();
                return etiqueta.Publicaciones.Skip(pagLen * npag).Take(pagLen).ToArray<Publicaciones>();
            }
            catch (ArgumentNullException)
            {
                throw new InstanceNotFoundException(tag, "EtiquetaSet");
            }
        }

        /// <exception cref="InstanceNotFoundException"></exception>
        public EtiquetaSet[] GetEtiquetas(long pubId)
        {
            DbSet<Publicaciones> pubs = Context.Set<Publicaciones>();

            try
            {
                var request =
                    (from p in pubs.Include("EtiquetaSet")
                     where p.Id == pubId
                     select p);
                Publicaciones publi = request.FirstOrDefault();
                return publi.EtiquetaSet.ToArray<EtiquetaSet>();
            }
            catch (ArgumentNullException)
            {
                throw new InstanceNotFoundException(pubId, "Publicaciones");
            }
        }

        /// <exception cref="InstanceNotFoundException"></exception>
        public void Etiquetar(string tag, long pubId)
        {
            DbSet<EtiquetaSet> etiquetas = Context.Set<EtiquetaSet>();
            DbSet<Publicaciones> publicaciones = Context.Set<Publicaciones>();

            try
            {
                var result = (from u in etiquetas.Include("Publicaciones")
                              where u.tag == tag
                              select u);
                EtiquetaSet et = result.FirstOrDefault();

                try
                {
                    var result2 = (from p in publicaciones
                                   where p.Id == pubId
                                   select p);
                    Publicaciones pub = result2.FirstOrDefault();

                    et.Publicaciones.Add(pub);
                    Update(et);
                }
                catch (ArgumentNullException)
                {
                    throw new InstanceNotFoundException(pubId, "Publicaciones");
                }
            }
            catch (ArgumentNullException)
            {
                throw new InstanceNotFoundException(tag, "EtiquetaSet");
            }
        }

        /// <exception cref="InstanceNotFoundException"></exception>
        public void Desetiquetar(string tag, long pubId)
        {
            DbSet<EtiquetaSet> etiquetas = Context.Set<EtiquetaSet>();
            DbSet<Publicaciones> publicaciones = Context.Set<Publicaciones>();

            try
            {
                var result = (from u in etiquetas.Include("Publicaciones")
                              where u.tag == tag
                              select u);
                EtiquetaSet et = result.FirstOrDefault();

                try
                {
                    var result2 = (from p in publicaciones
                                   where p.Id == pubId
                                   select p);
                    Publicaciones pub = result2.FirstOrDefault();

                    et.Publicaciones.Remove(pub);
                    Update(et);

                    if (et.Publicaciones.Count == 0)
                        Remove(et.tag);
                }
                catch (ArgumentNullException)
                {
                    throw new InstanceNotFoundException(pubId, "Publicaciones");
                }
            }
            catch (ArgumentNullException)
            {
                throw new InstanceNotFoundException(tag, "EtiquetaSet");
            }
        }

        public int GetNumPublicaciones(string tag)
        {
            DbSet<EtiquetaSet> etiq = Context.Set<EtiquetaSet>();

            try
            {
                var request =
                    (from e in etiq.Include("Publicaciones")
                     where e.tag == tag
                     select e);
                EtiquetaSet etiqueta = request.FirstOrDefault();
                return etiqueta.Publicaciones.Count;
            }
            catch (ArgumentNullException)
            {
                throw new InstanceNotFoundException(tag, "EtiquetaSet");
            }
        }
    }
}
