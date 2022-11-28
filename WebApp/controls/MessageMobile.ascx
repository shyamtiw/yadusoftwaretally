<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageMobile.ascx.cs" Inherits="WebApp.controls.MessageMobile" %>
<asp:Label Width="400px" runat="server" Visible="false" ID="messs"></asp:Label>

<div class="alert alert-<%= MessageClass %> mb-1  messageBox"   role="alert">
    <h3 style="display:none"><asp:Literal ID="ltHeading" runat="server" /></h3>
    <p><asp:Literal ID="ltDescription" runat="server" /></p>
</div>