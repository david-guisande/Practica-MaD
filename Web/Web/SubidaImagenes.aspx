<%@ Page Title="" Language="C#" MasterPageFile="~/Photogram.Master" AutoEventWireup="true" CodeBehind="SubidaImagenes.aspx.cs" Inherits="Web.SubidaImagenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="border-style: solid double; margin-bottom: 20px; margin-top: 20px">
		<div class="field" align="center" style="font-size: large; width:75%">
				<asp:Literal runat="server" Text="<%$ Resources:Common, subirimagen%>" />
		</div>
		<div>
			<div style="margin-bottom: 20px">
				<div class="field" align="left" style="font-size: large; float:left; width:35%">
					<asp:TextBox ID="txtTitle" runat="server" Width="195px" Text="<%$ Resources:, titulo%>" Columns="16" meta:resourcekey="txtTitleResource" style="margin-left: 10%;"/>
				</div>
				<div align="left" style='float:left; width:15%;'>
					<asp:DropDownList ID="DropDownList2" runat="server" style="margin-left: 10%;" AutoPostBack="True">
                            <asp:ListItem Selected="True" Value="Paisaje" Text="<%$ Resources:Common, paisaje%>">
                            </asp:ListItem> 
                            <asp:ListItem Value="Retrato" Text="<%$ Resources:Common, retrato%>">
                            </asp:ListItem> 
                            <asp:ListItem Value="Comida" Text="<%$ Resources:Common, comida%>">
                            </asp:ListItem> 
                            <asp:ListItem Value="Fiestas" Text="<%$ Resources:Common, fiestas%>">
                            </asp:ListItem> 
                            <asp:ListItem Value="Arte" Text="<%$ Resources:Common, arte%>">
                            </asp:ListItem>
                            <asp:ListItem Value="Otros" Text="<%$ Resources:Common, otros%>">
                            </asp:ListItem>
						</asp:DropDownList>
				</div>
			</div>
			<div style="margin-bottom: 20px">
				<div class="field" align="left" style="font-size: large; float:left">
					<asp:TextBox ID="TextBox1" runat="server" Width="195px" Columns="16" meta:resourcekey="txtTitleResource" style="margin-left: 10%;">ISO</asp:TextBox>
			    </div>
				<div class="field" align="left" style="font-size: large; float:left">
					<asp:TextBox ID="TextBox2" runat="server" Width="195px" Columns="16" meta:resourcekey="txtTitleResource" Text="<%$ Resources:, f%>" style="margin-left: 10%;"></asp:TextBox>
				</div>
				<div class="field" align="left" style="font-size: large; float:left">
					<asp:TextBox ID="TextBox3" runat="server" Width="195px" Columns="16" meta:resourcekey="txtTitleResource" Text="<%$ Resources:, t%>" style="margin-left: 10%;"></asp:TextBox>
				</div>
				<div class="field" align="left" style="font-size: large; float:left">
					<asp:TextBox ID="TextBox4" runat="server" Width="195px" Columns="16" meta:resourcekey="txtTitleResource" style="margin-left: 10%;">WB</asp:TextBox>
				</div>
			</div>
			<div style="margin-bottom: 120px">
				<div class="field" align="left" style="font-size: large; float:left; width:80%">
					<asp:TextBox ID="TextBox5" runat="server" Width="90%" Height="100px" Columns="16" meta:resourcekey="txtTitleResource" Text="<%$ Resources:, descripcion%>" style="margin-left: 10%;"></asp:TextBox>
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
					<asp:Button ID="UploadImg" runat="server" OnClick="Subir" Text="<%$ Resources:Common, subirimagen%>"/>
				</div>
			</div>
		</div>
	</div>
</asp:Content>
