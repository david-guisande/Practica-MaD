using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.Photogram.Model.DTOs;
using Es.Udc.DotNet.Photogram.Model.Service;
using Es.Udc.DotNet.Photogram.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Comentarios : SpecificCulturePage
    {
        public IPublicacionesService publiService;
        public IUsuariosService usrService;
        public IComentariosService comService;
        public ComentariosDto[] lista;
        List<LinkButton> users = new List<LinkButton>();
        List<Label> times = new List<Label>();
        List<TextBox> texts = new List<TextBox>();
        List<Button> update = new List<Button>();
        List<Button> delete = new List<Button>();
        public long pubid;
        public static int pagina = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            IIoCManager iocManager =
               (IIoCManager)HttpContext.Current.Application["managerIoC"];
            publiService = iocManager.Resolve<IPublicacionesService>();
            usrService = iocManager.Resolve<IUsuariosService>();
            comService = iocManager.Resolve<IComentariosService>();

            for (int i = 0; i < (int)Application["comentariosPag"]; i++)
            {
                var div = new HtmlGenericControl("DIV");
                div.Style.Value = "margin-left: 20%";

                var div2 = new HtmlGenericControl("DIV");
                div2.Style.Value = "margin-right: 20px; float:left";

                var lb = new LinkButton
                {
                    ID = "LinkButton" + i,
                    
                };
                lb.Command += VerUsuario;
                

                var l = new Label
                {
                    ID = "Label" + i
                };

                var t = new TextBox
                {
                    ID = "TextBox" + i,
                    ReadOnly = true,
                    Width = Unit.Percentage(60)
                };

                var bu = new Button
                {
                    ID = "ButtonU" + i,
                    Visible = false,
                    Text = (string)GetLocalResourceObject("actualizar")
                };
                bu.Command += Update;

                var bd = new Button
                {
                    ID = "ButtonD" + i,
                    Visible = false,
                    Text = (string)GetLocalResourceObject("borrar")
                };
                bd.Command += Delete;


                users.Add(lb);
                times.Add(l);
                texts.Add(t);
                update.Add(bu);
                delete.Add(bd);

                div2.Controls.Add(lb);
                div.Controls.Add(div2);
                div.Controls.Add(l);
                div.Controls.Add(new HtmlGenericControl("br"));
                div.Controls.Add(t);
                div.Controls.Add(bu);
                div.Controls.Add(bd);

                PlaceHolder1.Controls.Add(div);
                PlaceHolder1.Controls.Add(new HtmlGenericControl("br"));
            }

            pubid = (long)Session["imagen"];
            if (!IsPostBack) pagina = 0;
            if (IsPostBack) lista = comService.VerComentarios(pubid, pagina, (int)Application["comentariosPag"]);

            if (!IsPostBack) actualizar();

            Image.ImageUrl = publiService.FindPublicacion(pubid).imagen;
        }

        private void actualizar()
        {
            lista = comService.VerComentarios(pubid, pagina, (int)Application["comentariosPag"]);
           
            for (int i = 0; i < (int)Application["comentariosPag"]; i++)
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
            int i = Int32.Parse(lb.ID.Replace("LinkButton", ""));
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
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void Update(object sender, EventArgs e)
        {
            Button lb = (Button)sender;
            int i = Int32.Parse(lb.ID.Replace("ButtonU", ""));
            comService.ActualizarComentario(lista[i].Id, lista[i].Usuario, texts[i].Text);
        }
        protected void Delete(object sender, EventArgs e)
        {
            Button lb = (Button)sender;
            int i = Int32.Parse(lb.ID.Replace("ButtonD", ""));
            comService.EliminarComentario(lista[i].Id, lista[i].Usuario);
            actualizar();
        }
    }
}