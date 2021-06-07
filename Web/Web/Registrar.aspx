<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="Web.Registrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="">
            Registrarse
        </div>
        <div style="width: 80%; margin-left: 10%; margin-right: 10%">
        	<div style='float:left; width:30%; margin: 2%'>
                Login
            </div>
        	<div style='float:left; width:30%; margin: 2%'>
            	<asp:TextBox ID="login" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo Obligatorio (resumen)" ControlToValidate="login">Campo Obligatorio</asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="width: 80%;  margin-left: 10%; margin-right: 10%">
        	<div style='float:left; width:30%; margin: 2%'>
                Password
            </div>
        	<div style='float:left; width:30%; margin: 2%'>
            	<asp:TextBox TextMode="Password" ID="password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Obligatorio (resumen)" ControlToValidate="password">Campo Obligatorio</asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="RegExp1" runat="server" ErrorMessage="Password length must be between 7 to 10 characters" ControlToValidate="password" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{7,10}$" />
            </div>
        </div>
        <div style="width: 80%;  margin-left: 10%; margin-right: 10%"">
        	<div style='float:left; width:30%; margin: 2%'>
                Nombre
            </div>
        	<div style='float:left; width:30%; margin: 2%'>
            	<asp:TextBox ID="nombre" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo Obligatorio (resumen)" ControlToValidate="nombre">Campo Obligatorio</asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="width: 80%;  margin-left: 10%; margin-right: 10%"">
        	<div style='float:left; width:30%; margin: 2%'>
                E-Mail
            </div>
        	<div style='float:left; width:30%; margin: 2%'>
            	<asp:TextBox ID="mail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo Obligatorio (resumen)" ControlToValidate="mail">Campo Obligatorio</asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="width: 80%;  margin-left: 10%; margin-right: 10%"">
        	<div style='float:left; width:30%; margin: 2%'>
                País
            </div>
        	<div style='float:left; width:30%; margin: 2%'>
            	<asp:TextBox ID="pais" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo Obligatorio (resumen)" ControlToValidate="pais">Campo Obligatorio</asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="width: 80%;  margin-left: 10%; margin-right: 10%"">
        	<div style='float:left; width:30%; margin: 2%'>
                Idioma
            </div>
        	<div style='float:left; width:30%; margin: 2%'>
            	<asp:TextBox ID="idioma" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Campo Obligatorio (resumen)" ControlToValidate="idioma">Campo Obligatorio</asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="float:right; margin:5%">
        	<asp:Button ID="Button1" OnClick="BotonClick" runat="server" Text="Registrarse" />
        </div>
    </form>
</body>
</html>
