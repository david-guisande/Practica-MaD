<%@ Page Title="" Language="C#" MasterPageFile="~/Photogram.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Web.Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div style="border-style: solid double; margin-bottom: 40px; margin-top: 40px">
			<div class="field" align="center" style="font-size: large; float:left; width:75%">
				Subir Imagen</div>
			<div class="field">
			<div style='float:right; width:15%;'>
				<asp:Button ID="Subir" runat="server" OnClick="RedirigirSubir" Text="Subir"/>
			</div>
	</div>
	<div style="border-style: solid double; margin-bottom: 20px; margin-top: 20px">
			<div class="field" style="font-size: large; float:left; width:75%">
					<asp:Label runat="server" ID="nombre"></asp:Label>
			</div>
			<div style='float:right; width:25%;'>
				<asp:Button ID="Follow" runat="server" Text="Seguir Usuario" OnClick="Seguir" Visible="false"/>
			</div>
			<div style='float:left; width:25%; margin-right: 5px'>
				<asp:Button ID="Following" runat="server" Text="Ver Siguiendo" OnClick="VerSeg" Visible="false"/>
			</div>
			<div style='float:left; width:25%;'>
				<asp:Button ID="Followers" runat="server" Text="Ver Seguidores" OnClick="VerSeg" Visible="false"/>
			</div>

			<asp:ImageButton ID="Image1" runat="server" OnClick="Imagen" Visible="false" style="width:30%; margin:5px"/>
			<asp:ImageButton ID="Image2" runat="server" OnClick="Imagen" Visible="false" style="width:30%; margin:5px"/>
			<asp:ImageButton ID="Image3" runat="server" OnClick="Imagen" Visible="false" style="width:30%; margin:5px"/>
			<asp:ImageButton ID="Image4" runat="server" OnClick="Imagen" Visible="false" style="width:30%; margin:5px"/>
			<asp:ImageButton ID="Image5" runat="server" OnClick="Imagen" Visible="false" style="width:30%; margin:5px"/>
			<asp:ImageButton ID="Image6" runat="server" OnClick="Imagen" Visible="false" style="width:30%; margin:5px"/>
			<asp:ImageButton ID="Image7" runat="server" OnClick="Imagen" Visible="false" style="width:30%; margin:5px"/>
			<asp:ImageButton ID="Image8" runat="server" OnClick="Imagen" Visible="false" style="width:30%; margin:5px"/>
			<asp:ImageButton ID="Image9" runat="server" OnClick="Imagen" Visible="false" style="width:30%; margin:5px"/>
			<asp:ImageButton ID="Image10" runat="server" OnClick="Imagen" Visible="false" style="width:30%; margin:5px"/>
	</div>
	<div style="margin-bottom: 20px">
		<div class="field" align="right" style="font-size: large; float:left; width:49%">
			<asp:Button ID="Anterior" runat="server" OnClick="Prev" Text="Anterior" Visible="false"/>
		</div>
		<div class="field" align="left" style="font-size: large; float:right; width:49%">
			<asp:Button ID="Siguiente" runat="server" OnClick="Next" Text="Suiguiente" Visible="false"/>
		</div>
	</div>
</asp:Content>
