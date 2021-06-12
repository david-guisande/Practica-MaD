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
            <asp:Literal runat="server" Text="<%$ Resources:, registrar%>" />
        </div>
        <div style="width: 80%; margin-left: 10%; margin-right: 10%">
        	<div style='float:left; width:30%; margin: 2%'>
                <asp:Literal runat="server" Text="<%$ Resources:, login%>" />
            </div>
        	<div style='float:left; width:30%; margin: 2%'>
            	<asp:TextBox ID="login" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="<%$ Resources:, obligatorio%>" ControlToValidate="login"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="width: 80%;  margin-left: 10%; margin-right: 10%">
        	<div style='float:left; width:30%; margin: 2%'>
                <asp:Literal runat="server" Text="<%$ Resources:, pasw%>" />
            </div>
        	<div style='float:left; width:30%; margin: 2%'>
            	<asp:TextBox TextMode="Password" ID="password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="<%$ Resources:, obligatorio%>" ControlToValidate="password"></asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="RegExp1" runat="server" ErrorMessage="<%$ Resources:, longitud%>" ControlToValidate="password" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{7,10}$" />
            </div>
        </div>
        <div style="width: 80%;  margin-left: 10%; margin-right: 10%"">
        	<div style='float:left; width:30%; margin: 2%'>
                <asp:Literal runat="server" Text="<%$ Resources:, name%>" />
            </div>
        	<div style='float:left; width:30%; margin: 2%'>
            	<asp:TextBox ID="nombre" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="<%$ Resources:, obligatorio%>" ControlToValidate="nombre"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="width: 80%;  margin-left: 10%; margin-right: 10%"">
        	<div style='float:left; width:30%; margin: 2%'>
                <asp:Literal runat="server" Text="<%$ Resources:, email%>" />
            </div>
        	<div style='float:left; width:30%; margin: 2%'>
            	<asp:TextBox ID="mail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="<%$ Resources:, obligatorio%>" ControlToValidate="mail"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="width: 80%;  margin-left: 10%; margin-right: 10%"">
        	<div style='float:left; width:30%; margin: 2%'>
                <asp:Literal runat="server" Text="<%$ Resources:, pais%>" />
            </div>
        	<div style='float:left; width:30%; margin: 2%'>
            	<asp:TextBox ID="pais" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="<%$ Resources:, obligatorio%>" ControlToValidate="pais"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="width: 80%;  margin-left: 10%; margin-right: 10%"">
        	<div style='float:left; width:30%; margin: 2%'>
                <asp:Literal runat="server" Text="<%$ Resources:, idioma%>" />
            </div>
        	<div style='float:left; width:30%; margin: 2%'>
            	<asp:TextBox ID="idioma" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="<%$ Resources:, obligatorio%>" ControlToValidate="idioma"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="float:right; margin:5%">
        	<asp:Button ID="Button1" OnClick="BotonClick" runat="server" Text="<%$ Resources:, registrar%>" />
        </div>
    </form>
</body>
</html>
