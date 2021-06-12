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
    public partial class Comentarios : SpecificCulturePage
    {
        public IPublicacionesService publiService;
        public IUsuariosService usrService;
        public IComentariosService comService;
        public ComentariosDto[] lista;
        public long pubid;
        public static int pagina = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            IIoCManager iocManager =
               (IIoCManager)HttpContext.Current.Application["managerIoC"];
            publiService = iocManager.Resolve<IPublicacionesService>();
            usrService = iocManager.Resolve<IUsuariosService>();
            comService = iocManager.Resolve<IComentariosService>();

            pubid = (long)Session["imagen"];
            if (!IsPostBack) pagina = 0;
            lista = comService.VerComentarios(pubid, pagina);

            if (!IsPostBack) actualizar();
        }

        private void actualizar()
        {
            lista = comService.VerComentarios(pubid, pagina);
            LinkButton[] users = { LinkButton1, LinkButton2, LinkButton3, LinkButton4, LinkButton5, LinkButton6, LinkButton7, LinkButton8, LinkButton9, LinkButton10 };
            Label[] times = { Label1, Label2, Label3, Label4, Label5, Label6, Label7, Label8, Label9, Label10 };
            TextBox[] texts = { TextBox1, TextBox2, TextBox3, TextBox4, TextBox5, TextBox6, TextBox7, TextBox8, TextBox9, TextBox10 };
            Button[] update = { Button1, Button3, Button5, Button7, Button9, Button11, Button13, Button15, Button17, Button19, };
            Button[] delete = { Button2, Button4, Button6, Button8, Button10, Button12, Button14, Button16, Button18, Button20, };

            for (int i = 0; i < 10; i++)
            {
                if (i < lista.Length)
                {
                    users[i].Text = usrService.Usuario(lista[i].Usuario).name;
                    times[i].Text = new DateTime(lista[i].fecha).ToString();
                    texts[i].Text = lista[i].texto;

                    var usrsesion = SessionManager.GetUserSession(Context);
                    if (usrsesion != null && lista[i].Usuario == usrsesion.UserProfileId)
                    {
                        texts[i].ReadOnly = false;
                        update[i].Visible = true;
                        delete[i].Visible = true;
                    }
                    else
                    {
                        texts[i].ReadOnly = true;
                        update[i].Visible = false;
                        delete[i].Visible = false;
                    }

                    users[i].Visible = true;
                    times[i].Visible = true;
                    texts[i].Visible = true;
                }
                else
                {
                    users[i].Visible = false;
                    times[i].Visible = false;
                    texts[i].Visible = false;
                    update[i].Visible = false;
                    delete[i].Visible = false;
                }
            }
        }

        protected void VerUsuario(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            int i = Int32.Parse(lb.ID.Replace("LinkButton", "")) - 1;
            Session["perfil"] = lista[i].Usuario;
            var url = Response.ApplyAppPathModifier("~/Principal.aspx");
            Response.Redirect(url);
        }
        protected void Prev(object sender, EventArgs e)
        {
            if (pagina > 0)
            {
                pagina--;
            }
            actualizar();
        }
        protected void Next(object sender, EventArgs e)
        {
            pagina++;
            actualizar();
        }

        protected void Coment(object sender, EventArgs e)
        {
            UserSession userSession = SessionManager.GetUserSession(Context);

            if (userSession != null)
            {
                long usrid = userSession.UserProfileId;
                comService.Comentar(usrid, pubid, Comentario.Text);
                Comentario.Text = "";
                actualizar();
            }
            else
            {
                var url = Response.ApplyAppPathModifier("~/Autenticar.aspx");
                Response.Redirect(url);
            }
        }

        protected void Update(object sender, EventArgs e)
        {
            TextBox[] texts = { TextBox1, TextBox2, TextBox3, TextBox4, TextBox5, TextBox6, TextBox7, TextBox8, TextBox9, TextBox10 };
            Button lb = (Button)sender;
            int i = (Int32.Parse(lb.ID.Replace("Button", ""))+1) / 2 - 1;
            comService.ActualizarComentario(lista[i].Id, lista[i].Usuario, texts[i].Text);
        }
        protected void Delete(object sender, EventArgs e)
        {
            Button lb = (Button)sender;
            int i = Int32.Parse(lb.ID.Replace("Button", ""))/2 - 1;
            comService.EliminarComentario(lista[i].Id, lista[i].Usuario);
            actualizar();
        }
    }
}