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
    public partial class BusquedaEtiquetas : SpecificCulturePage
    {
        public IEtiquetasService etiqService;
        public PublicacionesDto[] publicaciones;
        public List<ImageButton> listaImg = new List<ImageButton>();
        public int pag = 0;
        public string tag;
        protected void Page_Load(object sender, EventArgs e)
        {
            IIoCManager iocManager =
                (IIoCManager)HttpContext.Current.Application["managerIoC"];
            etiqService = iocManager.Resolve<IEtiquetasService>();

                tag = (string)Session["tag"];
                if (tag == null)
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
            publicaciones = etiqService.GetPublicaciones(tag, pag, (int)Application["buscarImagenPag"]);

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