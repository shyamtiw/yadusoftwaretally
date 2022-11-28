<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="insertdata.aspx.cs" Inherits="WebApp.insertdata" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload runat="server" ID="file" />
    <asp:Button runat="server" ID="InsertData"  OnClick="InsertData_Click" Text="InsetData"/>
         <asp:Button runat="server" ID="insertdaa"  OnClick="insertdaa_Click" Text="dsdsd"/>
        <asp:GridView runat="server" ID="gvdata">

        </asp:GridView>
    </div>
    </form>
</body>
</html>
