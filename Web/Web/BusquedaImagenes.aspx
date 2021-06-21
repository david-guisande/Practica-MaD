<%@ Page Title="" Language="C#" MasterPageFile="~/Photogram.Master" AutoEventWireup="true" CodeBehind="BusquedaImagenes.aspx.cs" Inherits="Web.BusquedaImagenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
	<div style="border-style: solid double; margin-bottom: 20px; margin-top: 20px">
		<asp:PlaceHolder runat="server" ID="PlaceHolder1"></asp:PlaceHolder>
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
