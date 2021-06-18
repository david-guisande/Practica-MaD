﻿using Es.Udc.DotNet.Photogram.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
	public partial class Autenticar : SpecificCulturePage
	{
		protected void BotonClick(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				try
				{
					SessionManager.Login(Context,login.Text,password.Text, checkRememberPassword.Checked);
					FormsAuthentication. RedirectFromLoginPage(login.Text, checkRememberPassword.Checked);
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