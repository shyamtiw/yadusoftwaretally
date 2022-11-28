<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navigations.ascx.cs" Inherits="WebApp.controls.Navigations" %>
<asp:Repeater ID="rptParentMenu" runat="server" OnItemDataBound="rptParentMenu_ItemDataBound">
    <ItemTemplate>
          <li class="dropdown">

              <a href="#"  class="dropdown-toggle" data-toggle="dropdown">
                           
                            <%# Eval("DisplayName")%>
                            <span class="caret"></span>
                        </a>

              <ul class="dropdown-menu" role="menu">
                       <asp:Repeater ID="rptSubMenu" runat="server">
                <HeaderTemplate>
            
                </HeaderTemplate>
                <ItemTemplate>
                    <li><a href='<%# Eval("PageRedirectLink")%>'><i class="fa fa-play"></i></i> <%# Eval("DisplayName")%></a></li>
                    
                </ItemTemplate>
                
                <FooterTemplate>
                    
                    
                </FooterTemplate>
            </asp:Repeater>

                   </ul>
                      
                    </li>



    </ItemTemplate>
    <FooterTemplate>


    </FooterTemplate>
</asp:Repeater>

           <asp:Repeater ID="alonemenu" runat="server">
                <HeaderTemplate>
            
                </HeaderTemplate>
                <ItemTemplate>
                    <li><a href='<%# Eval("PageRedirectLink")%>' ><%# Eval("DisplayName")%></a></li>
                    
                </ItemTemplate>
                
                <FooterTemplate>
                    
                    
                </FooterTemplate>
            </asp:Repeater>