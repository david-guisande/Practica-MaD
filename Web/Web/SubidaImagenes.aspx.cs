using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.Photogram.Model.Service;
using Es.Udc.DotNet.Photogram.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class SubidaImagenes : SpecificCulturePage
    {
        public IUsuariosService usrService;
        public IPublicacionesService publiService;
        public IEtiquetasService etiqService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IIoCManager iocManager;

            iocManager = (IIoCManager)HttpContext.Current.Application["managerIoC"];
            publiService = iocManager.Resolve<IPublicacionesService>();
            usrService = iocManager.Resolve<IUsuariosService>();
            etiqService = iocManager.Resolve<IEtiquetasService>();
        }

        protected void Subir(object sender, EventArgs e)
        {
            if (!IsValid) return;
            string[] tags = TextBox9.Text.ToLower().Split(' ');
            UserSession userSession = SessionManager.GetUserSession(Context);
            long usrId = userSession.UserProfileId;
            float? t2 = null;
            int? t1 = null;
            int? t3 = null;
            int? t4 = null;
            if (TextBox2.Text != "")
            {
                t2 = float.Parse(TextBox2.Text);
            }
            if (TextBox1.Text != "")
            {
                t1 = Int32.Parse(TextBox1.Text);
            }
            if (TextBox3.Text != "")
            {
                t3 = Int32.Parse(TextBox3.Text);
            }
            if (TextBox4.Text != "")
            {
                t4 = Int32.Parse(TextBox4.Text);
            }
            long pubId = publiService.SubirImagen(usrId, txtTitle.Text, TextBox5.Text, DropDownList2.SelectedValue, t2, t1, t3, t4);
            var ruta = Server.MapPath("~/Imagenes/" + pubId + ".png");
            bool b = FileUpload1.HasFile;
            string x = FileUpload1.FileName;
            FileUpload1.SaveAs(ruta);
            Session["imagen"] = pubId;

            for (int i=0; i<tags.Length; i++)
            {
                if (tags[i] != "")
                {
                    etiqService.Etiquetar(tags[i], pubId);
                }
            }

            var url = Response.ApplyAppPathModifier("~/DetalleImagen.aspx");
            Response.Redirect(url);
        }
    }
}