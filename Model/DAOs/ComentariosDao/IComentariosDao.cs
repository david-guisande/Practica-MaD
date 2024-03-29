﻿using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System;

namespace Es.Udc.DotNet.Photogram.Model.DAOs
{
    public interface IComentariosDao : IGenericDao<Comentarios, Int64>
    {
        /// <exception cref="InstanceNotFoundException"></exception>
        Comentarios[] GetComentariosPubli(Int64 pubId, int npag, int pagLen);
    }
}