<%@ Page Title="" Language="C#" MasterPageFile="~/Photogram.Master" AutoEventWireup="true" CodeBehind="Comentarios.aspx.cs" Inherits="Web.Comentarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 20%">
        <asp:TextBox ID="Comentario" runat="server" Width=80%></asp:TextBox>
        <asp:Button ID="Comentar" runat="server" OnClick="Coment" Text="<%$ Resources:, comentar%>"></asp:Button>
    </div>
    <br />
    <br />
    <div style="margin-left: 20%">
        <div style="margin-right: 20px; float:left"><asp:LinkButton ID="LinkButton1" runat="server" OnClick="VerUsuario"></asp:LinkButton></div>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true" Width=60%></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Update" Visible="false" Text="<%$ Resources:, actualizar%>"></asp:Button>
        <asp:Button ID="Button2" runat="server" OnClick="Delete" Visible="false" Text="<%$ Resources:, borrar%>"></asp:Button>
    </div>
    <br />
    <div style="margin-left: 20%">
        <div style="margin-right: 20px; float:left"><asp:LinkButton ID="LinkButton2" runat="server" OnClick="VerUsuario"></asp:LinkButton></div>
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" ReadOnly="true" Width=60%></asp:TextBox>
        <asp:Button ID="Button3" runat="server" OnClick="Update" Visible="false" Text="<%$ Resources:, actualizar%>"></asp:Button>
        <asp:Button ID="Button4" runat="server" OnClick="Delete" Visible="false" Text="<%$ Resources:, borrar%>"></asp:Button>
    </div>
    <br />
    <div style="margin-left: 20%">
        <div style="margin-right: 20px; float:left"><asp:LinkButton ID="LinkButton3" runat="server" OnClick="VerUsuario"></asp:LinkButton></div>
        <asp:Label ID="Label3" runat="server"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox3" runat="server" ReadOnly="true" Width=60%></asp:TextBox>
        <asp:Button ID="Button5" runat="server" OnClick="Update" Visible="false" Text="<%$ Resources:, actualizar%>"></asp:Button>
        <asp:Button ID="Button6" runat="server" OnClick="Delete" Visible="false" Text="<%$ Resources:, borrar%>"></asp:Button>
    </div>
    <br />
    <div style="margin-left: 20%">
        <div style="margin-right: 20px; float:left"><asp:LinkButton ID="LinkButton4" runat="server" OnClick="VerUsuario"></asp:LinkButton></div>
        <asp:Label ID="Label4" runat="server"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox4" runat="server" ReadOnly="true" Width=60%></asp:TextBox>
        <asp:Button ID="Button7" runat="server" OnClick="Update" Visible="false" Text="<%$ Resources:, actualizar%>"></asp:Button>
        <asp:Button ID="Button8" runat="server" OnClick="Delete" Visible="false" Text="<%$ Resources:, borrar%>"></asp:Button>
    </div>
    <br />
    <div style="margin-left: 20%">
        <div style="margin-right: 20px; float:left"><asp:LinkButton ID="LinkButton5" runat="server" OnClick="VerUsuario"></asp:LinkButton></div>
        <asp:Label ID="Label5" runat="server"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox5" runat="server" ReadOnly="true" Width=60%></asp:TextBox>
        <asp:Button ID="Button9" runat="server" OnClick="Update" Visible="false" Text="<%$ Resources:, actualizar%>"></asp:Button>
        <asp:Button ID="Button10" runat="server" OnClick="Delete" Visible="false" Text="<%$ Resources:, borrar%>"></asp:Button>
    </div>
    <br />
    <div style="margin-left: 20%">
        <div style="margin-right: 20px; float:left"><asp:LinkButton ID="LinkButton6" runat="server" OnClick="VerUsuario"></asp:LinkButton></div>
        <asp:Label ID="Label6" runat="server"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox6" runat="server" ReadOnly="true" Width=60%></asp:TextBox>
        <asp:Button ID="Button11" runat="server" OnClick="Update" Visible="false" Text="<%$ Resources:, actualizar%>"></asp:Button>
        <asp:Button ID="Button12" runat="server" OnClick="Delete" Visible="false" Text="<%$ Resources:, borrar%>"></asp:Button>
    </div>
    <br />
    <div style="margin-left: 20%">
        <div style="margin-right: 20px; float:left"><asp:LinkButton ID="LinkButton7" runat="server" OnClick="VerUsuario"></asp:LinkButton></div>
        <asp:Label ID="Label7" runat="server"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox7" runat="server" ReadOnly="true" Width=60%></asp:TextBox>
        <asp:Button ID="Button13" runat="server" OnClick="Update" Visible="false" Text="<%$ Resources:, actualizar%>"></asp:Button>
        <asp:Button ID="Button14" runat="server" OnClick="Delete" Visible="false" Text="<%$ Resources:, borrar%>"></asp:Button>
    </div>
    <br />
    <div style="margin-left: 20%">
        <div style="margin-right: 20px; float:left"><asp:LinkButton ID="LinkButton8" runat="server" OnClick="VerUsuario"></asp:LinkButton></div>
        <asp:Label ID="Label8" runat="server"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox8" runat="server" ReadOnly="true" Width=60%></asp:TextBox>
        <asp:Button ID="Button15" runat="server" OnClick="Update" Visible="false" Text="<%$ Resources:, actualizar%>"></asp:Button>
        <asp:Button ID="Button16" runat="server" OnClick="Delete" Visible="false" Text="<%$ Resources:, borrar%>"></asp:Button>
    </div>
    <br />
    <div style="margin-left: 20%">
        <div style="margin-right: 20px; float:left"><asp:LinkButton ID="LinkButton9" runat="server" OnClick="VerUsuario"></asp:LinkButton></div>
        <asp:Label ID="Label9" runat="server"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox9" runat="server" ReadOnly="true" Width=60%></asp:TextBox>
        <asp:Button ID="Button17" runat="server" OnClick="Update" Visible="false" Text="<%$ Resources:, actualizar%>"></asp:Button>
        <asp:Button ID="Button18" runat="server" OnClick="Delete" Visible="false" Text="<%$ Resources:, borrar%>"></asp:Button>
    </div>
    <br />
    <div style="margin-left: 20%">
        <div style="margin-right: 20px; float:left"><asp:LinkButton ID="LinkButton10" runat="server" OnClick="VerUsuario"></asp:LinkButton></div>
        <asp:Label ID="Label10" runat="server"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox10" runat="server" ReadOnly="true" Width=60%></asp:TextBox>
        <asp:Button ID="Button19" runat="server" OnClick="Update" Visible="false" Text="<%$ Resources:, actualizar%>"></asp:Button>
        <asp:Button ID="Button20" runat="server" OnClick="Delete" Visible="false" Text="<%$ Resources:, borrar%>"></asp:Button>
    </div>
    <div style="margin-bottom: 20px; margin-top: 20px">
		<div class="field" align="right" style="font-size: large; float:left; width:49%">
			<asp:Button ID="Anterior" runat="server" OnClick="Prev" Text="<%$ Resources:Common, anterior%>"/>
		</div>
		<div class="field" align="left" style="font-size: large; float:right; width:49%">
			<asp:Button ID="Siguiente" runat="server" OnClick="Next" Text="<%$ Resources:Common, siguiente%>"/>
		</div>
	</div>
</asp:Content>
