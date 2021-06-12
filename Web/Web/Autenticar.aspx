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
            <asp:Literal runat="server" Text="<%$ Resources:, autenticar%>" />
        </div>
        <div style="width: 80%; margin-left: 10%; margin-right: 10%">
        	<div style='float:left; width:30%; margin: 2%'>
                <asp:Literal runat="server" Text="<%$ Resources:, login%>" />
            </div>
        	<div style='float:left; width:30%; margin: 2%'>
            	<asp:TextBox ID="login" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="<%$ Resources:, obligatorio%>" ControlToValidate="login"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div style="width: 80%;  margin-left: 10%; margin-right: 10%">
        	<div style='float:left; width:30%; margin: 2%'>
                <asp:Literal runat="server" Text="<%$ Resources:, pasw%>" />
            </div>
        	<div style='float:left; width:30%; margin: 2%'>
            	<asp:TextBox TextMode="Password" ID="password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="<%$ Resources:, obligatorio%>" ControlToValidate="password"></asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^[\s\S]{8,}$" ErrorMessage="<%$ Resources:, longitud%>" ControlToValidate="password"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div style="float:left; margin:5%; width:40%">
        	<asp:TextBox ID="TextoError" runat="server" Text="<%$ Resources:, credenciales%>" ReadOnly="true" Width="50%" Visible="false"/>
        </div>
        <div style="float:right; margin:5%">
        	<asp:Button ID="Button1" OnClick="BotonClick" runat="server" Text="<%$ Resources:, autenticar%>"/>
        </div>
        <div class="checkbox">
            <asp:CheckBox ID="checkRememberPassword" runat="server" TextAlign="Left" meta:resourcekey="checkRememberPassword" Text ="<%$ Resources:, recordar%>"/>
        </div>
    </form>
</body>
</html>
