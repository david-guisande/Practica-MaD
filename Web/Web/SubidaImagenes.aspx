<%@ Page Title="" Language="C#" MasterPageFile="~/Photogram.Master" AutoEventWireup="true" CodeBehind="SubidaImagenes.aspx.cs" Inherits="Web.SubidaImagenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div style="border-style: solid double; margin-bottom: 20px; margin-top: 20px">
		<div class="field" align="center" style="font-size: large; width:75%">
				Subida de Imagen
		</div>
		<div>
			<div style="margin-bottom: 20px">
				<div class="field" align="left" style="font-size: large; float:left; width:35%">
					<asp:TextBox ID="txtTitle" runat="server" Width="195px" Columns="16" meta:resourcekey="txtTitleResource" style="margin-left: 10%;">Titulo</asp:TextBox>
				</div>
				<div align="left" style='float:left; width:15%;'>
					<asp:DropDownList ID="DropDownList2" runat="server" style="margin-left: 10%;">
					</asp:DropDownList>
				</div>
			</div>
			<div style="margin-bottom: 20px">
				<div class="field" align="left" style="font-size: large; float:left">
					<asp:TextBox ID="TextBox1" runat="server" Width="195px" Columns="16" meta:resourcekey="txtTitleResource" style="margin-left: 10%;">ISO</asp:TextBox>
			    </div>
				<div class="field" align="left" style="font-size: large; float:left">
					<asp:TextBox ID="TextBox2" runat="server" Width="195px" Columns="16" meta:resourcekey="txtTitleResource" style="margin-left: 10%;">Diafragma</asp:TextBox>
				</div>
				<div class="field" align="left" style="font-size: large; float:left">
					<asp:TextBox ID="TextBox3" runat="server" Width="195px" Columns="16" meta:resourcekey="txtTitleResource" style="margin-left: 10%;">T. exposición</asp:TextBox>
				</div>
				<div class="field" align="left" style="font-size: large; float:left">
					<asp:TextBox ID="TextBox4" runat="server" Width="195px" Columns="16" meta:resourcekey="txtTitleResource" style="margin-left: 10%;">WB</asp:TextBox>
				</div>
			</div>
			<div style="margin-bottom: 120px">
				<div class="field" align="left" style="font-size: large; float:left; width:80%">
					<asp:TextBox ID="TextBox5" runat="server" Width="90%" Height="100px" Columns="16" meta:resourcekey="txtTitleResource" style="margin-left: 10%;">Descripción</asp:TextBox>
				</div>
			</div>
			<div style="margin-bottom: 20px">
				<div class="field" align="left" style="font-size: large; float:left; width:80%">
					<asp:FileUpload ID="FileUpload1" runat="server" />
				</div>
			</div>
			<div style="margin-bottom: 20px">
				<div class="field" align="left" style="font-size: large; float:left; width:80%">
					ETIQUETAS
				</div>
			</div>
			<div style="margin-bottom: 20px">
				<div class="field" align="center" style="font-size: large; float:left; width:80%">
					<asp:Button ID="UploadImg" runat="server" OnClick="Subir" Text="Subir Imagen"/>
				</div>
			</div>
		</div>
	</div>
</asp:Content>
