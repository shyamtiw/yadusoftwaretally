<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="emailsenddata.aspx.cs" Inherits="WebApp.emailsenddata" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
  <form id="form1" runat="server">  
      <table>
      <tbody><tr>
          <td colspan="2">
              <asp:label forecolor="Green" id="lblConfirmationMessage" runat="server">
          </asp:label></td>
      </tr>
      <tr>
          <td>
              <b>Email To</b>
          </td>
          <td>
              <asp:textbox width="300px" runat="server" id="txtEmailTo">
          </asp:textbox></td>
      </tr>
      <tr>
          <td>
              <b>Subject</b>
          </td>
          <td>
              <asp:textbox width="300px" runat="server" id="txtSubject">
          </asp:textbox></td>
      </tr>
      <tr>
          <td style="vertical-align: top;">
              <b>Message</b>
          </td>
          <td>
              <asp:textbox width="300px" height="100px" textmode="MultiLine" runat="server" id="txtEmailMessage">
          </asp:textbox></td>
      </tr>
      <tr>
          <td>
                
          </td>
          <td>
              <asp:button text="Send Email" id="btnSendEmail" runat="server" onclick="btnSendEmail_Click">
          </asp:button></td>
      </tr>
  </tbody></table>
    </form>  
</body>
</html>
