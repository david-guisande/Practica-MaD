using Es.Udc.DotNet.Photogram.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
	public partial class Autenticar : System.Web.UI.Page
	{
		protected void BotonClick(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				try
				{
					var usr = SessionManager.Login(Context,login.Text,password.Text,false);
					Session["perfil"] = usr.usrId;

					var url = Response.ApplyAppPathModifier("~/Principal.aspx");
					Response.Redirect(url);
				}
				catch { }
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
            {
				TextoError.Visible = true;
			}
        }
	}
}