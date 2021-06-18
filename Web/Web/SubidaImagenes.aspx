<%@ Page Title="" Language="C#" MasterPageFile="~/Photogram.Master" AutoEventWireup="true" CodeBehind="SubidaImagenes.aspx.cs" Inherits="Web.SubidaImagenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<br />
	<br />
    <div style="margin-bottom: 20px; margin-top: 20px">
		<div class="field" align="center" style="font-size: large;">
				<asp:Literal runat="server" Text="<%$ Resources:Common, subirimagen%>" />
		</div>
		<div>
			<div style="margin-bottom: 20px">
				<div class="field" align="left" style="font-size: large; float:left; width:35%">
					<asp:Literal runat="server" Text="<%$ Resources:, titulo%>" />
					<asp:TextBox ID="txtTitle" runat="server" Width="195px" meta:resourcekey="txtTitleResource" style="margin-left: 10%;"/>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="<%$ Resources: , obligatorio%>" ControlToValidate="txtTitle"/>
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
				<br />
				<div class="field" style="font-size: large; margin: 5%">
					<br />
					<asp:Literal runat="server" Text="ISO" />
					<asp:TextBox ID="TextBox1" runat="server" Width="195px" meta:resourcekey="txtTitleResource" />
					<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TextBox1" Operator="DataTypeCheck" Type="Integer" ErrorMessage="<%$ Resources: , int%>" />
					<br />
					<asp:Literal runat="server" Text="<%$ Resources:, f%>" />
					<asp:TextBox ID="TextBox2" runat="server" Width="195px" meta:resourcekey="txtTitleResource"></asp:TextBox>
					<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="TextBox2" Operator="DataTypeCheck" Type="Double" ErrorMessage="<%$ Resources: , float%>" />
					<br />
					<asp:Literal runat="server" Text="<%$ Resources:, t%>" />
					<asp:TextBox ID="TextBox3" runat="server" Width="195px" meta:resourcekey="txtTitleResource"></asp:TextBox>
					<asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="TextBox3" Operator="DataTypeCheck" Type="Integer" ErrorMessage="<%$ Resources: , int%>" />
					<br />
					<asp:Literal runat="server" Text="WB" />
					<asp:TextBox ID="TextBox4" runat="server" Width="195px" meta:resourcekey="txtTitleResource"></asp:TextBox>
					<asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="TextBox4" Operator="DataTypeCheck" Type="Integer" ErrorMessage="<%$ Resources: , int%>" />
					<br />
				</div>
			<div style="margin-bottom: 120px">
				<div class="field" align="left" style="font-size: large; float:left; width:80%">
					<asp:Literal runat="server" Text="<%$ Resources:, descripcion%>" />
					<asp:TextBox ID="TextBox5" runat="server" Width="90%" Height="100px" Columns="16" meta:resourcekey="txtTitleResource" style="margin-left: 10%;"></asp:TextBox>
				</div>
			</div>
			<div style="margin-bottom: 20px">
				<div class="field" align="left" style="font-size: large; float:left; width:80%">
					<asp:FileUpload ID="FileUpload1" runat="server" accept="image/png" />
				</div>
			</div>
			<div style="margin-bottom: 20px">
				<div class="field" align="left" style="font-size: large; float:left; width:80%">
					<br />
					<br />
					<asp:Literal runat="server" Text="<%$ Resources: , etiquetas%>" />
					<asp:TextBox ID="TextBox9" runat="server" Width="90%" Height="100px" Columns="16" meta:resourcekey="txtTitleResource" style="margin-left: 10%;"></asp:TextBox>
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
