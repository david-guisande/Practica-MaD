﻿using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.Photogram.Model.DTOs;
using Es.Udc.DotNet.Photogram.Model.Service;
using Es.Udc.DotNet.Photogram.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
	public partial class Principal : SpecificCulturePage
	{
		public IUsuariosService usrService;
		public IPublicacionesService publiService;
		public PublicacionesDto[] publicaciones;
		public List<ImageButton> listaImg = new List<ImageButton>();
		public long id = -1, sessionID = -1;
		public int pag = 0;

		protected void Page_Load(object sender, EventArgs e)
		{
			IIoCManager iocManager =
				(IIoCManager)HttpContext.Current.Application["managerIoC"];
			publiService = iocManager.Resolve<IPublicacionesService>();
			usrService = iocManager.Resolve<IUsuariosService>();

			for (int i = 0; i < (int)Application["buscarImagenPag"]; i++)
			{
				var button = new ImageButton
				{
					ID = "Image" + i,
				};
				button.Command += Imagen;
				button.Visible = false;
				PlaceHolder1.Controls.Add(button);
				listaImg.Add(button);
			}

			try
			{
				id = (long)Session["perfil"];
				UsuariosDto usr = usrService.Usuario(id);
				nombre.Text = usr.name;
			}
			catch { }

			if (SessionManager.GetUserSession(Context) != null)
            {
				sessionID = SessionManager.GetUserSession(Context).UserProfileId;
				if (sessionID != id)
					Follow.Visible = true;
			}

			Following.Visible = true;
			Followers.Visible = true;
			Siguiente.Visible = true;
			Anterior.Visible = true;
			actualizar();
		}

		private void actualizar()
        {
			if (id == -1) return;

			publicaciones = publiService.VerPublicacionesUsuario(id, pag, (int)Application["buscarImagenPag"]);

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

			string follow = (string)GetLocalResourceObject("follow");
			string unfollow = (string)GetLocalResourceObject("unfollow");

			if (sessionID != -1)
            {
				Follow.Text = (usrService.Siguiendo(sessionID, id)) ? unfollow : follow;
			}
		}

		protected void Imagen(object sender, EventArgs e)
        {
			Image img = (Image)sender;
			int i = Int32.Parse(img.ID.Replace("Image",""));
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

		protected void RedirigirSubir(object sender, EventArgs e)
		{
			var url = Response.ApplyAppPathModifier("~/SubidaImagenes.aspx");
			Response.Redirect(url);
		}

		protected void Seguir(object sender, EventArgs e)
        {
			usrService.SeguirA(sessionID, id);
			actualizar();
		}

		protected void VerSeg(object sender, EventArgs e)
        {
			Session["seg"] = sender == Followers;
			var url = Response.ApplyAppPathModifier("~/VerSeg.aspx");
			Response.Redirect(url);
		}
	}
}