﻿using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.Photogram.Model.DTOs;
using Es.Udc.DotNet.Photogram.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class BusquedaImagenes : System.Web.UI.Page
    {
        public IPublicacionesService publiService;
        public PublicacionesDto[] publicaciones;
        public int pag = 0;
        public string cat;
        public string keywords;
        protected void Page_Load(object sender, EventArgs e)
        {
            IIoCManager iocManager =
                (IIoCManager)HttpContext.Current.Application["managerIoC"];
            publiService = iocManager.Resolve<IPublicacionesService>();

            try
            {
                cat = (string)Session["categoria"];
                keywords = (string)Session["keywords"];
                if (cat == null || keywords == null)
                {
                    throw new Exception();
                }
                actualizar();
            }
            catch
            {
                var url = Response.ApplyAppPathModifier("~/Principal.aspx");
                Response.Redirect(url);
            }
           
        }

        private void actualizar()
        {
            ImageButton[] listaImg = { Image1, Image2, Image3, Image4, Image5, Image6, Image7, Image8, Image9, Image10 };
            if (cat == "")
            {
                publicaciones = publiService.BuscarImagenes(keywords, pag);
            }
            else
            {
                publicaciones = publiService.BuscarImagenes(keywords, cat, pag);
            }

            for (int i = 0; i < 10; i++)
            {
                if (i < publicaciones.Length)
                {
                    listaImg[i].ImageUrl = publicaciones[i].imagen;
                    listaImg[i].Visible = true;
                }
                else
                {
                    listaImg[i].Visible = false;
                }
            }
        }

            protected void Imagen(object sender, EventArgs e)
        {
            Image img = (Image)sender;
            int i = Int32.Parse(img.ID.Replace("Image", "")) - 1;
            Session["imagen"] = publicaciones[i].Id;

            var url = Response.ApplyAppPathModifier("~/DetalleImagen.aspx");
            Response.Redirect(url);
        }

        protected void Prev(object sender, EventArgs e)
        {
            if (pag > 0)
            {
                pag--;
                actualizar();
            }
        }

        protected void Next(object sender, EventArgs e)
        {
            pag++;
            actualizar();
        }
    }
}