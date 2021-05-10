﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Photogram.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Web.Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div style="border-style: solid double; margin-bottom: 20px">
		<form id="Form2" method="post" runat="server">
			<div class="field" align="center" style="font-size: large; float:left; width:75%">
				Subir Imagen</div>
			<div class="field">
			<div style='float:right; width:15%;'>
				<asp:Button ID="Subir" runat="server" Text="Subir"/>
			</div>
		</form>
	</div>
	<div style="border-style: solid double; margin-bottom: 20px">
		<form id="Form3" method="post" runat="server">
			<div class="field" style="font-size: large; float:left; width:75%">
					Perfil de Usuario</div>
			<div style='float:right; width:25%;'>
				<asp:Button ID="Follow" runat="server" Text="Seguir Usuario"/>
			</div>
		</form>
		<form id="Form4" method="post" runat="server">
			<div style='float:left; width:25%; margin-right: 5px'>
				<asp:Button ID="Following" runat="server" Text="Ver Siguiendo"/>
			</div>
			<div style='float:left; width:25%;'>
				<asp:Button ID="Followers" runat="server" Text="Ver Seguidores"/>
			</div>
		</form>
		<form id="Form5" method="post" runat="server">

			<asp:Image ID="Image1" runat="server" style="width:30%; margin:5px"/>
			<asp:Image ID="Image2" runat="server" style="width:30%; margin:5px"/>
			<asp:Image ID="Image3" runat="server" style="width:30%; margin:5px"/>

		</form>
	</div>
</asp:Content>
