<%@ Page Title="" Language="C#" MasterPageFile="~/Photogram.Master" AutoEventWireup="true" CodeBehind="VerSeg.aspx.cs" Inherits="Web.VerSeg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="field" align="left" style="font-size: large; float:left; width:35%">
		<asp:LinkButton ID="LinkButton1" runat="server" Width="180px" style="text-align: center; margin-left: 30%;" OnClick="VerUsuario">Usuario</asp:LinkButton>
		<asp:LinkButton ID="LinkButton2" runat="server" Width="180px" style="text-align: center; margin-left: 30%;" OnClick="VerUsuario">Usuario</asp:LinkButton>
		<asp:LinkButton ID="LinkButton3" runat="server" Width="180px" style="text-align: center; margin-left: 30%;" OnClick="VerUsuario">Usuario</asp:LinkButton>
		<asp:LinkButton ID="LinkButton4" runat="server" Width="180px" style="text-align: center; margin-left: 30%;" OnClick="VerUsuario">Usuario</asp:LinkButton>
		<asp:LinkButton ID="LinkButton5" runat="server" Width="180px" style="text-align: center; margin-left: 30%;" OnClick="VerUsuario">Usuario</asp:LinkButton>
		<asp:LinkButton ID="LinkButton6" runat="server" Width="180px" style="text-align: center; margin-left: 30%;" OnClick="VerUsuario">Usuario</asp:LinkButton>
		<asp:LinkButton ID="LinkButton7" runat="server" Width="180px" style="text-align: center; margin-left: 30%;" OnClick="VerUsuario">Usuario</asp:LinkButton>
		<asp:LinkButton ID="LinkButton8" runat="server" Width="180px" style="text-align: center; margin-left: 30%;" OnClick="VerUsuario">Usuario</asp:LinkButton>
		<asp:LinkButton ID="LinkButton9" runat="server" Width="180px" style="text-align: center; margin-left: 30%;" OnClick="VerUsuario">Usuario</asp:LinkButton>
		<asp:LinkButton ID="LinkButton10" runat="server" Width="180px" style="text-align: center; margin-left: 30%;" OnClick="VerUsuario">Usuario</asp:LinkButton>
	</div>
	<div class="field" style="margin-top: 250px" align="center">
			<asp:Button ID="Anterior" runat="server" OnClick="Prev" Text="Anterior" Visible="false"/>
			<asp:Button ID="Siguiente" runat="server" OnClick="Next" Text="Suiguiente" Visible="false"/>
	</div>
</asp:Content>
