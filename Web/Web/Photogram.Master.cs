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
    public partial class Photogram : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Salir(object sender, EventArgs e)
		{
            SessionManager.Logout(Context);
            var url = Response.ApplyAppPathModifier("~/Principal.aspx");
            Response.Redirect(url);
        }

        protected void BuscarImagenes(object sender, EventArgs e)
        {
            var url = Response.ApplyAppPathModifier("~/BusquedaImagenes.aspx");
            Session["keywords"] = keywords.Text;
            Session["categoria"] = DropDownList1.SelectedValue;
            Session["paginaBusqueda"] = 0;
            Response.Redirect(url);
        }

        protected void MyProfile(object sender, EventArgs e)
        {
            UserSession userSession = SessionManager.GetUserSession(Context);

            if (userSession != null)
            {
                Session["perfil"] = userSession.UserProfileId;
                var url = Response.ApplyAppPathModifier("~/Principal.aspx");
                Response.Redirect(url);
            }
            else
            {
                var url = Response.ApplyAppPathModifier("~/Autenticar.aspx");
                Response.Redirect(url);
            }
            
        }

        protected void ActualizarInformacion(object sender, EventArgs e)
        {
            UserSession userSession = SessionManager.GetUserSession(Context);

            if (userSession == null)
            {
                var url = Response.ApplyAppPathModifier("~/ActualizarInfo.aspx");
                Response.Redirect(url);
            }
            else
            {
                var url = Response.ApplyAppPathModifier("~/Autenticar.aspx");
                Response.Redirect(url);
            }
        }
    }
}