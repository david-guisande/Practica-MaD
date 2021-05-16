using System;
using Es.Udc.DotNet.Photogram.Model.Service;
using Es.Udc.DotNet.ModelUtil.IoC;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
	public partial class Registrar : System.Web.UI.Page
	{
		protected void BotonClick(object sender, EventArgs e)
		{
			IIoCManager iocManager = (IIoCManager)Application["managerIoC"];
			IUsuariosService userService = iocManager.Resolve<IUsuariosService>();

			try
			{
				long id = userService.RegistrarUsuario(login.Text, password.Text, nombre.Text, mail.Text, pais.Text, idioma.Text);
				// Session["login"] = login.Text;
				// Redirigir hacia pagina principal
				Console.WriteLine(userService.Autenticar(login.Text,password.Text));
			}
			catch { /* Mostrar mensaje de error */ }
		}
	}
}