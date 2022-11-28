<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Message.ascx.cs" Inherits="WebApp.controls.Message" %>
<asp:Label Width="400px" runat="server" Visible="false" ID="messs"></asp:Label>
<link href="../css/message.css" rel="stylesheet" type="text/css" />
<div class="<%= MessageClass %> messageBox">
    <h3><asp:Literal ID="ltHeading" runat="server" /></h3>
    <p><asp:Literal ID="ltDescription" runat="server" /></p>
</div>