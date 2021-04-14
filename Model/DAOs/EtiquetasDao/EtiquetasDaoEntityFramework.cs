﻿using Es.Udc.DotNet.ModelUtil.Dao;
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


    }
}