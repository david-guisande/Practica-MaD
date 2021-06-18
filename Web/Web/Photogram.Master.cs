using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.Photogram.Model.Service;
using Es.Udc.DotNet.Photogram.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Photogram : System.Web.UI.MasterPage
    {
        public IEtiquetasService etiqService;
        protected void Page_Load(object sender, EventArgs e)
        {
            IIoCManager iocManager =
                (IIoCManager)HttpContext.Current.Application["managerIoC"];
            etiqService = iocManager.Resolve<IEtiquetasService>();


            (string,int)[] list = etiqService.NubeEtiquetas((int)Application["nubeEtiquetasPag"]);

            int sum = 0;
            for (int i = 0; i < list.Length; i++)
            {
                sum += list[i].Item2;
            }
            for (int i = 0; i < list.Length; i++)
            {
                var button = new LinkButton
                {
                    ID = "Button" + i,
                    Text = list[i].Item1
                };
                button.Command += EtiquetaOnClick;
                float x = ((float)list[i].Item2 / (float)sum) * 36 + 12;


                button.Attributes.Add("style", "font-size:" + (Math.Round(x*100)/100).ToString() +"px;");
                PlaceHolder1.Controls.Add(button);
                PlaceHolder1.Controls.Add(new HtmlGenericControl("br"));
            }

            UserSession userSession = SessionManager.GetUserSession(Context);
            if (userSession == null)
            {
                registrar.Visible = true;
                login.Visible = true;
                miperfil.Visible = false;
                actualizar.Visible = false;
                salir.Visible = false;
            }
            else
            {
                registrar.Visible = false;
                login.Visible = false;
                miperfil.Visible = true;
                actualizar.Visible = true;
                salir.Visible = true;
            }
        }

        protected void EtiquetaOnClick(object sender, EventArgs e)
        {
            var url = Response.ApplyAppPathModifier("~/BusquedaEtiquetas.aspx");
            Session["tag"] = ((LinkButton)sender).Text;
            Response.Redirect(url);
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
            Response.Redirect(url);
        }

        protected void MyProfile(object sender, EventArgs e)
        {
            UserSession userSession = SessionManager.GetUserSession(Context);

            Session["perfil"] = userSession.UserProfileId;
            var url = Response.ApplyAppPathModifier("~/Principal.aspx");
            Response.Redirect(url);
            
        }

        protected void ActualizarInformacion(object sender, EventArgs e)
        {
            var url = Response.ApplyAppPathModifier("~/ActualizarInfo.aspx");
            Response.Redirect(url);
        }

        protected void Registrar(object sender, EventArgs e)
        {
            var url = Response.ApplyAppPathModifier("~/Registrar.aspx");
            Response.Redirect(url);

        }

        protected void Login(object sender, EventArgs e)
        {
            var url = Response.ApplyAppPathModifier("~/Autenticar.aspx");
            Response.Redirect(url);
        }
    }
}