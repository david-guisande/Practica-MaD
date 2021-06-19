<%@ Page Title="" Language="C#" MasterPageFile="~/Photogram.Master" AutoEventWireup="true" CodeBehind="Comentarios.aspx.cs" Inherits="Web.Comentarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 20%">
        <asp:TextBox ID="Comentario" runat="server" Width=80%></asp:TextBox>
        <asp:Button ID="Comentar" runat="server" OnClick="Coment" Text="<%$ Resources:, comentar%>"></asp:Button>
    </div>
    <br />
    <br />
    
    <asp:PlaceHolder runat="server" ID="PlaceHolder1"></asp:PlaceHolder>
    
    <div style="margin-bottom: 20px; margin-top: 20px">
		<div class="field" align="right" style="font-size: large; float:left; width:49%">
			<asp:Button ID="Anterior" runat="server" OnClick="Prev" Text="<%$ Resources:Common, anterior%>"/>
		</div>
		<div class="field" align="left" style="font-size: large; float:right; width:49%">
			<asp:Button ID="Siguiente" runat="server" OnClick="Next" Text="<%$ Resources:Common, siguiente%>"/>
		</div>
	</div>
</asp:Content>
