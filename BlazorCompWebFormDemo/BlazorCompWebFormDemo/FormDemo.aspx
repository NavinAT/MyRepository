<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormDemo.aspx.cs" Inherits="BlazorCompWebFormDemo.FormDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Form Demo</title>
    <link rel="stylesheet" href="BootStrap/bootstrap.min.css"/>
    <link rel="stylesheet" href="BootStrap/TextBoxStyle.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 20px">
            <label style="color: darkcyan; font-size: 35px; font-weight: bolder">Counter</label><br/><br/>
            <asp:TextBox ID="IncrementBox" runat="server"></asp:TextBox><br/><br/>
            <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Click Me" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
