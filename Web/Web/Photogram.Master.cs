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
        protected void Salir(object sender, EventArgs e)
		{
            SessionManager.Logout(Context);
            var url = Response.ApplyAppPathModifier("~/Principal.aspx");
            Response.Redirect(url);
        }
    }
}