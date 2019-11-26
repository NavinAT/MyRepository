<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BlazorCompWebFormDemo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Form Demo</title>
    <script>
        function Increment()
        {
            var IncrementCount = document.getElementById("IncrementBox").value;
            IncrementCount++;

            document.getElementById("IncrementBox").value = IncrementCount;
        }
    </script>
    <link rel="stylesheet" href="BootStrap/TextBoxStyle.css"/>
    <link rel="stylesheet" href="BootStrap/bootstrap.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 20px">
             
            <label style="color: darkcyan; font-size: 35px; font-weight: bolder">Counter</label><br/><br/>
            <asp:TextBox ID="IncrementBox" runat="server" autocomplete="off"></asp:TextBox> <br/><br/>
            <button class="btn btn-primary" onclick="Increment()">Click Me</button>
        </div>
    </form>
</body>
</html>
