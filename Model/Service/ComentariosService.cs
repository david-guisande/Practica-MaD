﻿using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.Photogram.Model.DAOs;
using Es.Udc.DotNet.Photogram.Model.DTOs;
using Ninject;
using System;


namespace Es.Udc.DotNet.Photogram.Model.Service
{
    public class ComentariosService : IComentariosService
    {
        [Inject]
        public IPublicacionesDao PublicacionesDao { private get; set; }
        [Inject]
        public IUserProfileDao UsuariosDao { private get; set; }
        [Inject]
        public IComentariosDao ComentariosDao { private get; set; }


        public Int64 Comentar(Int64 usrId, Int64 pubId, string comentario)
        {
            Comentarios com = new Comentarios();
            com.Usuario = usrId;
            com.PublicacionId = pubId;
            com.texto = comentario;
            com.fecha = DateTime.Now.Ticks;

            ComentariosDao.Create(com);
            return com.Id;
        }

        public void ActualizarComentario(Int64 comId, Int64 usrId, string textoNuevo)
        {
            Comentarios com = ComentariosDao.Find(comId);
            if (com.Usuario == usrId)
            {
                com.texto = textoNuevo;
                ComentariosDao.Update(com);
            }
        }

        public void EliminarComentario(Int64 comId, Int64 usrId)
        {
            Comentarios com = ComentariosDao.Find(comId);
            if (com.Usuario == usrId) ComentariosDao.Remove(comId);
        }

        /// <exception cref="InstanceNotFoundException"/>
        public ComentariosDto[] VerComentarios(Int64 pubId, int npag, int pagLen)
        {
            Comentarios[] com = ComentariosDao.GetComentariosPubli(pubId, npag, pagLen);
            ComentariosDto[] res = new ComentariosDto[com.Length];

            for (int i = 0; i < com.Length; i++)
                res[i] = com[i];

            return res;
        }
    }
}