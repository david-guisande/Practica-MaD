<%@ Page Title="" Language="C#" MasterPageFile="~/Photogram.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Web.Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="border-style: solid double; margin-bottom: 40px; margin-top: 40px">
			<div class="field" align="center" style="font-size: large; float:left; width:75%">
				<asp:Literal runat="server" Text="<%$ Resources:Common, subirimagen%>" />
			</div>
			<div style='float:right; width:15%;'>
				<asp:Button ID="Subir" runat="server" OnClick="RedirigirSubir" Text="<%$ Resources:Common, subir%>"/>
			</div>
	</div>
	<div style="border-style: solid double; margin-bottom: 20px; margin-top: 20px">
			<div class="field" style="font-size: large; float:left; width:75%">
					<asp:Label runat="server" ID="nombre"></asp:Label>
			</div>
			<div style='float:left; width:25%; margin-right: 5px'>
				<asp:Button ID="Following" runat="server" Text="<%$ Resources:, following%>" OnClick="VerSeg" Visible="false"/>
			</div>
			<div style='float:left; width:25%;'>
				<asp:Button ID="Followers" runat="server" Text="<%$ Resources:, followers%>" OnClick="VerSeg" Visible="false"/>
			</div>
			<div style='float:right; width:25%;'>
				<asp:Button ID="Follow" runat="server" Text="<%$ Resources:, follow%>" OnClick="Seguir" Visible="false"/>
			</div>
			<br />
			<asp:PlaceHolder runat="server" ID="PlaceHolder1"></asp:PlaceHolder>
	</div>
	<div style="margin-bottom: 20px">
		<div class="field" align="right" style="font-size: large; float:left; width:49%">
			<asp:Button ID="Anterior" runat="server" OnClick="Prev" Text="<%$ Resources:Common, anterior%>" Visible="false"/>
		</div>
		<div class="field" align="left" style="font-size: large; float:right; width:49%">
			<asp:Button ID="Siguiente" runat="server" OnClick="Next" Text="<%$ Resources:Common, siguiente%>" Visible="false"/>
		</div>
	</div>
</asp:Content>
