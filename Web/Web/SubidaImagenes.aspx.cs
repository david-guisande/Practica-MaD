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

        protected void Page_Load(object sender, EventArgs e)
        {
            IIoCManager iocManager;

            UserSession userSession = SessionManager.GetUserSession(Context);

            if (userSession != null)
            {
                iocManager =
                (IIoCManager)HttpContext.Current.Application["managerIoC"];
                publiService = iocManager.Resolve<IPublicacionesService>();
                usrService = iocManager.Resolve<IUsuariosService>();
            }
            else
            {
                var url = Response.ApplyAppPathModifier("~/Autenticar.aspx");
                Response.Redirect(url);
            }
        }

        protected void Subir(object sender, EventArgs e)
        {
            UserSession userSession = SessionManager.GetUserSession(Context);
            long usrId = userSession.UserProfileId;
            long pubId = publiService.SubirImagen(usrId, txtTitle.Text, TextBox5.Text, DropDownList2.SelectedValue,
                float.Parse(TextBox2.Text), Int32.Parse(TextBox1.Text), Int32.Parse(TextBox3.Text), Int32.Parse(TextBox4.Text));
            var ruta = Server.MapPath("~/Imagenes/" + pubId + ".png");
            bool b = FileUpload1.HasFile;
            string x = FileUpload1.FileName;
            FileUpload1.SaveAs(ruta);
            Session["imagen"] = pubId;
            var url = Response.ApplyAppPathModifier("~/DetalleImagen.aspx");
            Response.Redirect(url);
        }
    }
}