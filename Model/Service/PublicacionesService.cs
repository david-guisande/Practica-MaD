﻿using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.Photogram.Model.DAOs;
using Es.Udc.DotNet.Photogram.Model.DTOs;
using Ninject;
using System;


namespace Es.Udc.DotNet.Photogram.Model.Service
{
    public class PublicacionesService : IPublicacionesService
    {
        [Inject]
        public IPublicacionesDao PublicacionesDao { private get; set; }
        [Inject]
        public IUserProfileDao UsuariosDao { private get; set; }

        public Int64 SubirImagen(long usrId, string titulo, string descripcion, string categoria, double? f = null, int? ISO = null, int? t = null, int? wb = null)
        {
            Publicaciones publi = new Publicaciones();
            publi.Usuario = usrId;
            publi.Usuarios = UsuariosDao.Find(usrId);
            publi.titulo = titulo;
            publi.imagen = "";
            publi.descripcion = descripcion;
            publi.categoria = categoria;
            publi.fecha = DateTime.Now.Ticks;
            publi.f = f;
            publi.ISO = ISO;
            publi.t = t;
            publi.wb = wb;

            PublicacionesDao.Create(publi);
            publi.imagen = "~/Imagenes/"+publi.Id+".png";
            PublicacionesDao.Update(publi);
            return publi.Id;
        }

        /// <exception cref="InstanceNotFoundException"/>
        public PublicacionesDto[] VerPublicacionesUsuario(Int64 usrId, int npag, int pagLen)
        {
            Publicaciones[] pub = PublicacionesDao.GetPubliUsuario(usrId, npag, pagLen);
            PublicacionesDto[] res = new PublicacionesDto[pub.Length];

            for (int i = 0; i < pub.Length; i++)
                res[i] = pub[i];

            return res;
        }

        /// <exception cref="InstanceNotFoundException"/>
        public PublicacionesDto[] BuscarImagenes(string keywords, int npag, int pagLen)
        {
            Publicaciones[] pub = PublicacionesDao.Buscar(keywords, npag, pagLen);
            PublicacionesDto[] res = new PublicacionesDto[pub.Length];

            for (int i = 0; i < pub.Length; i++)
                res[i] = pub[i];

            return res;
        }

        /// <exception cref="InstanceNotFoundException"/>
        public PublicacionesDto[] BuscarImagenes(string keywords, string categoria, int npag, int pagLen)
        {
            Publicaciones[] pub = PublicacionesDao.Buscar(keywords, categoria, npag, pagLen);
            PublicacionesDto[] res = new PublicacionesDto[pub.Length];

            for (int i = 0; i < pub.Length; i++)
                res[i] = pub[i];

            return res;
        }

        /// <exception cref="InstanceNotFoundException"/>
        public void DarMeGusta(Int64 usrId, Int64 pubId)
        {
            UsuariosDao.DarFav(usrId, pubId);
        }

        /// <exception cref="InstanceNotFoundException"/>
        public int NumeroMeGusta(Int64 pubId)
        {
            return PublicacionesDao.Favs(pubId);
        }

        public PublicacionesDto FindPublicacion(Int64 pubId)
        {
            return PublicacionesDao.Find(pubId);
        }
    }
}
