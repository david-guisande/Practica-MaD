using Es.Udc.DotNet.ModelUtil.IoC;
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
    public partial class DetalleImagen : System.Web.UI.Page
    {
        public IPublicacionesService publiService;
        public IUsuariosService usrService;
        long pubid;
        long usrid;
        UsuariosDto autor;
        protected void Page_Load(object sender, EventArgs e)
        {
            IIoCManager iocManager =
                (IIoCManager)HttpContext.Current.Application["managerIoC"];
            publiService = iocManager.Resolve<IPublicacionesService>();
            usrService = iocManager.Resolve<IUsuariosService>();

            pubid = (long) Session["imagen"];
            usrid = SessionManager.GetUserSession(Context).UserProfileId;
            PublicacionesDto pub = publiService.FindPublicacion(pubid);

            Favs.Text = "Likes " + publiService.NumeroMeGusta(pubid).ToString();
            autor = usrService.Usuario(pub.Usuario);
            UserLink.Text = autor.loginName;
            Image1.ImageUrl = pub.imagen;
            txtTitle.Text = pub.titulo;
            TextBox6.Text = pub.categoria;
            TextBox5.Text = pub.descripcion;
            DateTime data = new DateTime(pub.fecha);
            TextBox7.Text = data.ToString();
            if(pub.ISO != null)
            {
                TextBox1.Text = "ISO " + pub.ISO.ToString();
            }

            if (pub.f != null)
            {
                TextBox2.Text = "f " + pub.f.ToString();
            }
            
            if (pub.t != null)
            {
                TextBox3.Text = "t " + pub.t.ToString();
            }
            
            if (pub.wb != null)
            {
                TextBox4.Text = "wb " + pub.wb.ToString();
            }
            
        }

        protected void DarMegusta(object sender, EventArgs e)
        {
            publiService.DarMeGusta(usrid ,pubid);
            Favs.Text = "Likes " + publiService.NumeroMeGusta(pubid).ToString();
        }

        protected void VerUsuario(object sender, EventArgs e)
        {
            Session["perfil"] = autor.usrId;
            var url = Response.ApplyAppPathModifier("~/Principal.aspx");
            Response.Redirect(url);
        }
    }
}