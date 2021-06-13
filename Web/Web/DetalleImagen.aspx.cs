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
    public partial class DetalleImagen : SpecificCulturePage
    {
        public IPublicacionesService publiService;
        public IUsuariosService usrService;
        public IEtiquetasService etiqService;
        long pubid = -1;
        long usrid = -1;
        UsuariosDto autor;
        protected void Page_Load(object sender, EventArgs e)
        {
            IIoCManager iocManager =
                (IIoCManager)HttpContext.Current.Application["managerIoC"];
            publiService = iocManager.Resolve<IPublicacionesService>();
            usrService = iocManager.Resolve<IUsuariosService>();
            etiqService = iocManager.Resolve<IEtiquetasService>();

            pubid = (long) Session["imagen"];
            try
            {
                usrid = SessionManager.GetUserSession(Context).UserProfileId;
            }
            catch { }
            PublicacionesDto pub = publiService.FindPublicacion(pubid);

            Favs.Text = GetLocalResourceObject("likes").ToString() + " " + publiService.NumeroMeGusta(pubid).ToString();
            autor = usrService.Usuario(pub.Usuario);
            UserLink.Text = autor.loginName;
            Image1.ImageUrl = pub.imagen;
            txtTitle.Text = pub.titulo;
            TextBox6.Text = GetGlobalResourceObject("Common",pub.categoria.ToLower()).ToString();
            TextBox5.Text = pub.descripcion;
            DateTime data = new DateTime(pub.fecha);
            TextBox7.Text = data.ToString();
            if(pub.ISO != null)
            {
                TextBox1.Text = "ISO " + pub.ISO.ToString();
            }

            if (pub.f != null)
            {
                TextBox2.Text = GetLocalResourceObject("f").ToString() + " " + pub.f.ToString();
            }
            
            if (pub.t != null)
            {
                TextBox3.Text = GetLocalResourceObject("t").ToString() + " " + pub.t.ToString();
            }
            
            if (pub.wb != null)
            {
                TextBox4.Text = "wb " + pub.wb.ToString();
            }

            string[] list = etiqService.GetEtiquetas(pubid);

            for (int i = 0; i < list.Length; i++)
            {
                var button = new LinkButton
                {
                    ID = "Button" + i,
                    Text = list[i]
                };
                button.Command += EtiquetaOnClick;
                PlaceHolder1.Controls.Add(button);
                PlaceHolder1.Controls.Add(new HtmlGenericControl("br"));
            }

        }

        protected void EtiquetaOnClick(object sender, EventArgs e)
        {
            var url = Response.ApplyAppPathModifier("~/BusquedaEtiquetas.aspx");
            Session["tag"] = ((LinkButton)sender).Text;
            Response.Redirect(url);
        }
        protected void DarMegusta(object sender, EventArgs e)
        {
            if (usrid != -1)
            {
                publiService.DarMeGusta(usrid, pubid);
                Favs.Text = GetLocalResourceObject("likes").ToString() + publiService.NumeroMeGusta(pubid).ToString();
            }
        }

        protected void VerUsuario(object sender, EventArgs e)
        {
            Session["perfil"] = autor.usrId;
            var url = Response.ApplyAppPathModifier("~/Principal.aspx");
            Response.Redirect(url);
        }

        protected void VerComentarios(object sender, EventArgs e)
        {
            var url = Response.ApplyAppPathModifier("~/Comentarios.aspx");
            Response.Redirect(url);
        }
    }
}