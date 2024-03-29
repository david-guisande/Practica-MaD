﻿using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.Photogram.Model.DTOs;
using Es.Udc.DotNet.Photogram.Model.Service;
using Es.Udc.DotNet.Photogram.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class BusquedaImagenes : SpecificCulturePage
    {
        public IPublicacionesService publiService;
        public PublicacionesDto[] publicaciones;
        public List<ImageButton> listaImg = new List<ImageButton>();
        public int pag = 0;
        public string cat;
        public string keywords;
        protected void Page_Load(object sender, EventArgs e)
        {
            IIoCManager iocManager =
                (IIoCManager)HttpContext.Current.Application["managerIoC"];
            publiService = iocManager.Resolve<IPublicacionesService>();

            cat = (string)Session["categoria"];
            keywords = (string)Session["keywords"];
            if (cat == null || keywords == null)
            {
                var url = Response.ApplyAppPathModifier("~/Principal.aspx");
                Response.Redirect(url);
            }

            for (int i = 0; i < (int)Application["buscarImagenPag"]; i++)
            {
                var button = new ImageButton
                {
                    ID = "Image" + i,
                };
                button.Command += Imagen;
                PlaceHolder1.Controls.Add(button);
                listaImg.Add(button);
            }
            actualizar();
        }

        private void actualizar()
        {
            try
            {
                if (cat == "")
                {
                    publicaciones = publiService.BuscarImagenes(keywords, pag, (int)Application["buscarImagenPag"]);
                }
                else
                {
                    publicaciones = publiService.BuscarImagenes(keywords, cat, pag, (int)Application["buscarImagenPag"]);
                }

                for (int i = 0; i < (int)Application["buscarImagenPag"]; i++)
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
            catch
            {

            }
        }

        protected void Imagen(object sender, EventArgs e)
        {
            Image img = (Image)sender;
            int i = Int32.Parse(img.ID.Replace("Image", ""));
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