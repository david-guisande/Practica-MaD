<%@ Page Title="" Language="C#" MasterPageFile="~/Photogram.Master" AutoEventWireup="true" CodeBehind="BusquedaImagenes.aspx.cs" Inherits="Web.BusquedaImagenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

<div style="border-style: solid double; margin-bottom: 20px; margin-top: 20px">

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
	<div style="margin-bottom: 20px; margin-top: 20px">
		<div class="field" align="right" style="font-size: large; float:left; width:49%">
			<asp:Button ID="Anterior" runat="server" OnClick="Prev" Text="<%$ Resources:Common, anterior%>"/>
		</div>
		<div class="field" align="left" style="font-size: large; float:right; width:49%">
			<asp:Button ID="Siguiente" runat="server" OnClick="Next" Text="<%$ Resources:Common, siguiente%>"/>
		</div>
	</div>
</asp:Content>
