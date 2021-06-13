using System;
using Es.Udc.DotNet.Photogram.Model.Service;
using Es.Udc.DotNet.ModelUtil.IoC;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Es.Udc.DotNet.Photogram.Web.HTTP.Session;

namespace Web
{
	public partial class Registrar : SpecificCulturePage
	{
		protected void BotonClick(object sender, EventArgs e)
		{

			if (Page.IsValid)
            {
				//try
				//{
					long id = SessionManager.RegisterUser(Context, login.Text,
							password.Text, nombre.Text, mail.Text, pais.SelectedValue, idioma.SelectedValue);
					Session["perfil"] = id;

					var url = Response.ApplyAppPathModifier("~/Principal.aspx");
					Response.Redirect(url);
				//}
				
			}
		}
	}
}