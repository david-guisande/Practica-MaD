using Es.Udc.DotNet.ModelUtil.IoC;
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
	public partial class Principal : System.Web.UI.Page
	{
		public IUsuariosService usrService;
		public IPublicacionesService publiService;
		public PublicacionesDto[] publicaciones;
		public long id;
		public int pag = 0;

		protected void Page_Load(object sender, EventArgs e)
		{
			IIoCManager iocManager =
				(IIoCManager)HttpContext.Current.Application["managerIoC"];
			publiService = iocManager.Resolve<IPublicacionesService>();
			usrService = iocManager.Resolve<IUsuariosService>();

			try
			{
				id = (long)Session["perfil"];
				UsuariosDto usr = usrService.Usuario(id);

				nombre.Text = usr.name;
				actualizar();
			}
			catch { }
		}

		private void actualizar()
        {
			publicaciones = publiService.VerPublicacionesUsuario(id, pag);
			Image1.ImageUrl = publicaciones[0].imagen;
			Image2.ImageUrl = publicaciones[1].imagen;
			Image3.ImageUrl = publicaciones[2].imagen;
			Image4.ImageUrl = publicaciones[3].imagen;
			Image5.ImageUrl = publicaciones[4].imagen;
			Image6.ImageUrl = publicaciones[5].imagen;
			Image7.ImageUrl = publicaciones[6].imagen;
			Image8.ImageUrl = publicaciones[7].imagen;
			Image9.ImageUrl = publicaciones[8].imagen;
			Image10.ImageUrl = publicaciones[9].imagen;
		}

		protected void Imagen(object sender, EventArgs e)
        {
			Image img = (Image)sender;
			int i = Int32.Parse(img.ClientID.Replace("Image",""))-1;
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