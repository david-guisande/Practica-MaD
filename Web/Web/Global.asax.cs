﻿using Es.Udc.DotNet.Photogram.HTTP.Util.IoC;
using Es.Udc.DotNet.Photogram.Web.HTTP.Session;
using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.ModelUtil.Log;
using Ninject;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace Web
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{
			Application.Lock();

			IIoCManager IoCManager = new IoCManagerNinject();
			IoCManager.Configure();

			Application["managerIoC"] = IoCManager;

			Application.UnLock();
		}

		protected void Session_Start(object sender, EventArgs e)
		{
			SessionManager.TouchSession(Context);
		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			string json = File.ReadAllText(Server.MapPath("~/config.json"));
			var config = JsonSerializer.Deserialize<Dictionary<string,int>>(json);
			foreach (var pair in config)
            {
				Application[pair.Key] = pair.Value;
            }
		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_Error(object sender, EventArgs e)
		{

		}

		protected void Session_End(object sender, EventArgs e)
		{

		}

		protected void Application_End(object sender, EventArgs e)
		{
			((IKernel)Application["kernelIoC"]).Dispose();

			LogManager.RecordMessage("NInject kernel container disposed", MessageType.Info);
		}
	}
}