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

    }
}
