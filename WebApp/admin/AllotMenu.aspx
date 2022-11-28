<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="AllotMenu.aspx.cs" Inherits="WebApp.admin.AllotMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormName" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">

        <ContentTemplate>

            <div class="row">
                <SG:Message runat="server" ID="MessageBox" />


                <div class="col-md-8" style="float: none; margin: auto;">

                    <!-- general form elements disabled -->
                    <div class="box box-success box-solid" style="border: 3px solid #0b0336!important;">
                        <div class="box-header with-border" style="background: #0b0336!important; background-color: #0b0336!important;">
                            <h3 class="box-title">Allot/Menu/Option</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">





                            <div class="form-group">
                                <label>Select Allot To</label>


                                <asp:DropDownList runat="server" ID="ddlAccountCategory" AutoPostBack="true" OnSelectedIndexChanged="ddlAccountCategory_SelectedIndexChanged" CssClass="form-control">
                                </asp:DropDownList>

                            </div>
                            <div class="box-footer">
                                <asp:Button runat="server" Text="Save" OnClick="saveAccountHead_Click" ID="saveAccountHead" ValidationGroup="head" CssClass="btn btn-primary" />
                            </div>
                        
                        <div class="row">
                            <div class="col-md-6">
                                  <h4>Menu Allot</h4>
                                <div class="box-body table-responsive">
                                    <asp:GridView ID="gvDistrict" runat="server" AllowSorting="true" CssClass="table table-bordered table-striped addedfeature" AutoGenerateColumns="false" Width="98%" align="center">
                                        <Columns>
                                            <asp:TemplateField HeaderText="#">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Select">
                                                <ItemTemplate>
                                                    <asp:CheckBox runat="server" ID="ck" Checked='<%# Convert.ToBoolean( Eval("Select"))%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Name">
                                                <ItemTemplate>
                                                    <asp:HiddenField runat="server" ID="IDs" Value='<%# Convert.ToInt32( Eval("AllotMenuId"))%>' />
                                                    <asp:HiddenField runat="server" ID="MenuId" Value='<%# Convert.ToInt32( Eval("MenuId"))%>' />
                                                    <%# Eval("DisplayName")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            No Record Exists
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </div>

                          
                            <div class="col-md-6">
                                  <h4>Option Allot</h4>
                                <div class="box-body table-responsive">
                                      <asp:GridView ID="gvoption" runat="server" AllowSorting="true" CssClass="table table-bordered table-striped addedfeature" AutoGenerateColumns="false" Width="98%" align="center">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="ck" Checked='<%# Convert.ToBoolean( Eval("Select"))%>' />
                                        </ItemTemplate> 
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:HiddenField runat="server" ID="IDs" Value='<%# Convert.ToInt32( Eval("AllotMenuId"))%>' />
                                            <asp:HiddenField runat="server" ID="MenuId" Value='<%# Convert.ToInt32( Eval("MenuId"))%>' />
                                            <%# Eval("DisplayName")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    No Record Exists
                                </EmptyDataTemplate>
                            </asp:GridView>
                                </div>
                            </div>



                        </div>
                    </div>
                </div>
                </div>
            </div>






            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true">
        <ProgressTemplate>
            <div style="z-index: 10001;" class="windowbackground">
                <div class="progressbar breadcrumb">
                    <img alt="Loading..." src="img/ajax-loader.gif"><br>
                    Please Wait...
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

</asp:Content>
