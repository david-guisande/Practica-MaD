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
    public partial class VerSeg : SpecificCulturePage
    {
        public IUsuariosService usrService;
        public UsuariosDto[] follow;
        public long id;
        public int pag = 0;
        public bool seguidores;

        protected void Page_Load(object sender, EventArgs e)
        {
            IIoCManager iocManager =
                (IIoCManager)HttpContext.Current.Application["managerIoC"];
            usrService = iocManager.Resolve<IUsuariosService>();

            try
            {
                id = (long)Session["perfil"];
                seguidores = (bool)Session["seg"];

                if (seguidores)
                    follow = usrService.VerSeguidores(id, pag, (int)Application["seguidoresSeguidosPag"]);
                else follow = usrService.VerSeguidos(id, pag, (int)Application["seguidoresSeguidosPag"]);

                actualizar();
            }
            catch { }
        }

        private void actualizar()
        {
            LinkButton[] buttons = { LinkButton1, LinkButton2, LinkButton3, LinkButton4, LinkButton5, LinkButton6, LinkButton7, LinkButton8, LinkButton9, LinkButton10 };
            for (int i = 0; i < 10; i++)
            {
                if (i < follow.Length)
                {
                    buttons[i].Text = follow[i].name;
                    buttons[i].Visible = true;
                }
                else
                {
                    buttons[i].Visible = false;
                }
            }
        }

        protected void VerUsuario(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            int i = Int32.Parse(lb.ID.Replace("LinkButton", "")) - 1;
            Session["perfil"] = follow[i].usrId;
            var url = Response.ApplyAppPathModifier("~/Principal.aspx");
            Response.Redirect(url);
        }

        protected void Prev(object sender, EventArgs e)
        {
            if (pag > 0)
            {
                pag--;
                actualizar();
            }
        }

        protected void Next(object sender, EventArgs e)
        {
            pag++;
            actualizar();
        }
    }
}