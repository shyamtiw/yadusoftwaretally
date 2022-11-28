<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="validText.ascx.cs" Inherits="WebApp.controls.validText" %>
<asp:TextBox ID="txtdata" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RFV" runat="server" ControlToValidate="txtdata"  ForeColor="Red" CssClass="has-error" ErrorMessage="Required Field Is Empty" Display="Dynamic" Enabled="false"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="REV" runat="server" ControlToValidate="txtdata" ForeColor="Red" CssClass="has-error" ErrorMessage="Invalid Value" Display="Dynamic" Enabled="false"></asp:RegularExpressionValidator>
<asp:CompareValidator ID="CV" runat="server" ControlToValidate="txtdata" ForeColor="Red" CssClass="has-error" ValueToCompare="txtdata" Operator="DataTypeCheck" ErrorMessage="Invalid Date of Birth" Display="Dynamic" Enabled="false" Type="Date"></asp:CompareValidator>
