<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="readcheck.aspx.cs" Inherits="WebApp.admin.readcheck" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:ScriptManager runat="server" ID="ss"></asp:ScriptManager>
    <div>
    
                    <asp:FileUpload ID="FileUpload1" runat="server" />

<asp:Button ID="btnUpload" runat="server" Text="Upload"

            OnClick="btnUpload_Click" />

        <asp:Button ID="cacls" runat="server" Text="Upsssload"

            OnClick="cacls_Click" />


<br />

<asp:Label ID="Label1" runat="server" Text="Has Header ?" />

<asp:RadioButtonList ID="rbHDR" runat="server">

    <asp:ListItem Text = "Yes" Value = "Yes" Selected = "True" >

    </asp:ListItem>

    <asp:ListItem Text = "No" Value = "No"></asp:ListItem>

</asp:RadioButtonList>

<asp:GridView ID="GridView1" runat="server">

</asp:GridView>
   </div>
    </form>
</body>
</html>
