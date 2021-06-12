<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Autenticar.aspx.cs" Inherits="Web.Autenticar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="">
            Autenicarse
        </div>
        <div style="width: 80%; margin-left: 10%; margin-right: 10%">
        	<div style='float:left; width:30%; margin: 2%'>
                Login
            </div>
        	<div style='float:left; width:30%; margin: 2%'>
            	<asp:TextBox ID="login" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Obligatorio (resumen)" ControlToValidate="login">Campo Obligatorio</asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="width: 80%;  margin-left: 10%; margin-right: 10%">
        	<div style='float:left; width:30%; margin: 2%'>
                Password
            </div>
        	<div style='float:left; width:30%; margin: 2%'>
            	<asp:TextBox TextMode="Password" ID="password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo Obligatorio (resumen)" ControlToValidate="password">Campo Obligatorio</asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^[\s\S]{8,}$" ErrorMessage="RegularExpressionValidator" ControlToValidate="password"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div style="float:left; margin:5%; width:40%">
        	<asp:TextBox ID="TextoError" runat="server" Text="Las credenciales no son válidas" ReadOnly="true" Width="50%" Visible="false"/>
        </div>
        <div style="float:right; margin:5%">
        	<asp:Button ID="Button1" OnClick="BotonClick" runat="server" Text="Autenticar"/>
        </div>
        <div class="checkbox">
            <asp:CheckBox ID="checkRememberPassword" runat="server" TextAlign="Left" meta:resourcekey="checkRememberPassword" Text ="Recordar contraseña"/>
        </div>
    </form>
</body>
</html>
