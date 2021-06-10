using Es.Udc.DotNet.ModelUtil.IoC;
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
    public partial class SubidaImagenes : System.Web.UI.Page
    {
        public IUsuariosService usrService;
        public IPublicacionesService publiService;

        protected void Page_Load(object sender, EventArgs e)
        {
            IIoCManager iocManager =
                (IIoCManager)HttpContext.Current.Application["managerIoC"];
            publiService = iocManager.Resolve<IPublicacionesService>();
            usrService = iocManager.Resolve<IUsuariosService>();
        }

        protected void Subir(object sender, EventArgs e)
        {
            UserSession userSession = SessionManager.GetUserSession(Context);
            if (userSession != null)
            {
                long usrId = userSession.UserProfileId;
                long pubId = publiService.SubirImagen(usrId, txtTitle.Text, TextBox5.Text, DropDownList2.SelectedValue);
                FileUpload1.SaveAs(Server.MapPath("~/Imagenes/"+pubId+".png"));

                Session["imagen"] = pubId;
                var url = Response.ApplyAppPathModifier("~/DetalleImagen.aspx");
                Response.Redirect(url);
            }
        }
    }
}