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
    public partial class DetalleImagen : System.Web.UI.Page
    {
        public IPublicacionesService publiService;
        protected void Page_Load(object sender, EventArgs e)
        {
            IIoCManager iocManager =
                (IIoCManager)HttpContext.Current.Application["managerIoC"];
            publiService = iocManager.Resolve<IPublicacionesService>();

            long pubid = (long) Session["imagen"];
            PublicacionesDto pub = publiService.FindPublicacion(pubid);

            Image1.ImageUrl = pub.imagen;
            txtTitle.Text = pub.titulo;
            TextBox6.Text = pub.categoria;
            TextBox5.Text = pub.descripcion;
            if(pub.ISO != null)
            {
                TextBox1.Text += " " + pub.ISO.ToString();
            }

            if (pub.f != null)
            {
                TextBox2.Text += " " + pub.f.ToString();
            }
            
            if (pub.t != null)
            {
                TextBox3.Text += " " + pub.t.ToString();
            }
            
            if (pub.wb != null)
            {
                TextBox4.Text += " " + pub.wb.ToString();
            }
            
        }


    }
}