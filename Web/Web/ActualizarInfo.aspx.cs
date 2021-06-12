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
    public partial class ActualizarInfo : SpecificCulturePage
    {
		public IUsuariosService usrService;
		public UserSession userSession;
		protected void Page_Load(object sender, EventArgs e)
        {
			IIoCManager iocManager =
				(IIoCManager)HttpContext.Current.Application["managerIoC"];
			usrService = iocManager.Resolve<IUsuariosService>();

			userSession = SessionManager.GetUserSession(Context);
			if (userSession == null)
            {
				var url = Response.ApplyAppPathModifier("~/Autenticar.aspx");
				Response.Redirect(url);
			}
			else
            {
				if (!IsPostBack)
                {
					UsuariosDto usr = usrService.Usuario(userSession.UserProfileId);
					login.Text = usr.loginName;
					password.Text = usr.password;
					nombre.Text = usr.name;
					mail.Text = usr.email;
					pais.Text = usr.pais;
					idioma.Text = usr.idioma;
				}
			}
		}

		protected void BotonClick(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				try
				{
					usrService.ActualizarUsuario(userSession.UserProfileId, login.Text,
							password.Text, nombre.Text, mail.Text, pais.Text, idioma.Text);

					var usr = SessionManager.Login(Context, login.Text, password.Text, false);
					Session["perfil"] = usr.usrId;

					var url = Response.ApplyAppPathModifier("~/Principal.aspx");
					Response.Redirect(url);
				}
				catch { }
			}
		}
	}
}