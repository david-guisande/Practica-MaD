<%@ Page Title="" Language="C#" MasterPageFile="~/Photogram.Master" AutoEventWireup="true" CodeBehind="DetalleImagen.aspx.cs" Inherits="Web.DetalleImagen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="border-style: solid double; margin-bottom: 20px; margin-top: 20px">
		<div class="field" align="center" style="font-size: large; width:75%">
			Detalle de Imagen
		</div>
		<div style="margin-bottom: 20px">
			<asp:Image ID="Image1" runat="server" style="width:90%; margin:5px"/>
		</div>
		<div>
			<div style="margin-bottom: 20px">
				<div class="field" align="left" style="font-size: large; float:left; width:35%">
					<asp:LinkButton ID="UserLink" runat="server" Width="180px" style="margin-left: 30%;" OnClick="VerUsuario">-</asp:LinkButton>
				</div>
				<div align="left" style='float:left; width:15%;'>
					<asp:Button ID="Favs" runat="server" Width="195px" Columns="16" Text="Likes 0" style="margin-left: 10%;" OnClick="DarMegusta"></asp:Button>
				</div>
			</div>

			<div style="margin-bottom: 20px">
				<div class="field" align="left" style="font-size: large; float:left; width:35%">
					<asp:TextBox ID="txtTitle" runat="server" Width="195px" ReadOnly="true" Columns="16" meta:resourcekey="txtTitleResource" style="margin-left: 10%;">Titulo</asp:TextBox>
				</div>
				<div align="left" style='float:left; width:15%;'>
					<asp:TextBox ID="TextBox6" runat="server" Width="195px" ReadOnly="true" Columns="16" meta:resourcekey="txtTitleResource" style="margin-left: 10%;">Categoría</asp:TextBox>
				</div>
				<div align="left" style='float:left; width:15%;'>
					<asp:TextBox ID="TextBox7" runat="server" Width="195px" ReadOnly="true" Columns="16" meta:resourcekey="txtTitleResource" style="margin-left: 10%;">Fecha</asp:TextBox>
				</div>
			</div>
			<div style="margin-bottom: 20px">
				<div class="field" align="left" style="font-size: large; float:left">
					<asp:TextBox ID="TextBox1" runat="server" ReadOnly="true" Width="195px" Columns="16" meta:resourcekey="txtTitleResource" style="margin-left: 10%;">ISO</asp:TextBox>
			    </div>
				<div class="field" align="left" style="font-size: large; float:left">
					<asp:TextBox ID="TextBox2" runat="server" ReadOnly="true" Width="195px" Columns="16" meta:resourcekey="txtTitleResource" style="margin-left: 10%;">Diafragma</asp:TextBox>
				</div>
				<div class="field" align="left" style="font-size: large; float:left">
					<asp:TextBox ID="TextBox3" runat="server" ReadOnly="true" Width="195px" Columns="16" meta:resourcekey="txtTitleResource" style="margin-left: 10%;">T. exposición</asp:TextBox>
				</div>
				<div class="field" align="left" style="font-size: large; float:left">
					<asp:TextBox ID="TextBox4" runat="server" ReadOnly="true" Width="195px" Columns="16" meta:resourcekey="txtTitleResource" style="margin-left: 10%;">WB</asp:TextBox>
				</div>
			</div>
			<div style="margin-bottom: 120px">
				<div class="field" align="left" style="font-size: large; float:left; width:80%">
					<asp:TextBox ID="TextBox5" runat="server" ReadOnly="true" Width="90%" Height="100px" Columns="16" meta:resourcekey="txtTitleResource" style="margin-left: 10%;">Descripción</asp:TextBox>
				</div>
			</div>
			<div style="margin-bottom: 20px">
				<div class="field" align="left" style="font-size: large; float:left; width:80%">
					ETIQUETAS
				</div>
			</div>
		</div>
	</div>
</asp:Content>
