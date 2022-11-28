<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showQRCode.aspx.cs" Inherits="WebApp.admin.showQRCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
     <asp:Image ID="imgageQRCodedata" Width="300px"
               Height="300px" runat="server"
               />
            </center>
    </div>
    </form>
</body>
</html>
