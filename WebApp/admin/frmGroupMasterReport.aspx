<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="frmGroupMasterReport.aspx.cs" Inherits="WebApp.admin.frmGroupMasterReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormName" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">
    <SG:Message ID="MessageBox" runat="server" />


    <div class="row">
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel box box-primary">
                        <div class="box-header with-border">
                            <h4 class="box-title">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Group Report 
                      </a>
                            </h4>
                        </div>
                        <div class="row">

                       

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Report Name</label>
                                 <asp:TextBox runat="server" ID="ReportName" CssClass="form-control"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ReportName" 
        ValidationGroup="Class" runat="server" ErrorMessage="Title is required." ForeColor="Red" />
                                </div>

                            </div>
                          
                               <div class="col-md-6">
                                <div class="form-group">
                                    <label>Group Code</label>
                                  <asp:TextBox runat="server" ID="GroupCode" CssClass="form-control"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="GroupCode" 
        ValidationGroup="Class" runat="server" ErrorMessage="Title is required." ForeColor="Red" />

                                </div>

                            </div>
                         

                         
                        </div>

                    


                        <div class="box-footer">
                            <asp:Button runat="server" ID="SaveData" Text="Submit"  ValidationGroup="Class" CssClass="btn btn-primary"  OnClick="SaveData_Click"/>
                            

                        </div>


                         <div class="row">
                        <div class="col-md-12">


                            <asp:GridView ID="GVData" runat="server" CssClass="table table-bordered table-hover table-striped GVData" AutoGenerateColumns="false" Width="98%" align="center">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Report Name">
                                        <ItemTemplate>
                                            <%# Eval("ReportName")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
        
                                        <asp:TemplateField HeaderText="Group Code">
                                        <ItemTemplate>
                                            <%# Eval("GroupCode")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>

                                       
                                        <asp:LinkButton runat="server" ID="LinkButton1" PostBackUrl='<%# Eval("GroupMasterReportId","frmGroupMasterReport.aspx?delete={0}") %>' CssClass="label label-sm label-danger" Text="Delete" OnClientClick="return confirm('Are you sure you want to Remove?');"></asp:LinkButton>

                                            <asp:LinkButton runat="server" ID="LinkButton2" PostBackUrl='<%# string.Concat("frmGroupMasterReport.aspx?GroupMasterReportId=",Eval("GroupMasterReportId")) %>' CssClass="label label-sm  label-warning" Text="Edit"></asp:LinkButton>
                                            
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

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
