<%@ Page Title="" Language="C#" MasterPageFile="~/admin/popup.Master" AutoEventWireup="true" CodeBehind="salesoutstadingupdateRemark.aspx.cs" Inherits="WebApp.admin.salesoutstadingupdateRemark" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .t01 th, td {
            border: 1px solid black;
            border-collapse: collapse;
        }

        .t02 th {
            background-color: #3c8dbc;
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formahndler" runat="server">
    <SG:Message ID="MessageBox" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">

        <ContentTemplate>

            <div class="content-wrapper" style="background-color: white;">
                <!-- Content Header (Page header) -->

                <section class="content-header">
                    <h1>Update Remark
                    </h1>
                    <ol class="breadcrumb">

                        <li><a href="#">Home<i class="fa fa-dashboard"></i></a></li>





                    </ol>
                </section>

                <section class="content">




                    <div class="row">
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-12">
                                    <!-- general form elements disabled -->
                                    <div class="box box-success box-solid" style="border: 3px solid #0b0336!important;">
                                        <div class="box-header with-border" style="background: #0b0336!important; background-color: #0b0336!important;">
                                            <h4 class="box-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Update Remark
                      </a>
                                            </h4>
                                        </div>
                                        <div class="row">
                                            

                                            

                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label>Remark</label>
                                                    <asp:TextBox runat="server" ID="Remark" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="Remark" runat="server" ForeColor="Red"
                                                        ErrorMessage="Please enter remark" Display="Dynamic"
                                                        ValidationGroup="ok"></asp:RequiredFieldValidator>
                                                </div>

                                            </div>
                                            
                                        </div>

                                         <div class="box-footer">
                                <asp:Button runat="server" Text="Upload" OnClick="Upload" ID="savelocation" ValidationGroup="head" CssClass="btn btn-primary" />
                            </div>

                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="gvlocation" runat="server" CssClass="t01 t02" AutoGenerateColumns="false" Width="98%" align="center">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sr.No">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Insert/Modify Name">
                                                                    <ItemTemplate>
                                                                        <%# Eval("UserName")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                              
                                                                <asp:TemplateField HeaderText="Date">
                                                                    <ItemTemplate>
                                                                        <%# Convert.ToDateTime( Eval("Date")).ToString("dd/MM/yyyy")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Remark">
                                                                    <ItemTemplate>
                                                                        <%# Eval("Remark")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="PendingAmt">
                                                                    <ItemTemplate>
                                                                        <%# Eval("PendingAmt")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Action">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton runat="server" ID="Editfamily" PostBackUrl='<%# Eval("SalesOutstatingRemarkID","salesoutstadingupdateRemark.aspx?SalesOutstatingRemarkID={0}&&Ledg_Ac="+Request.QueryString["Ledg_Ac"]+"&&PendingAmt="+Request.QueryString["PendingAmt"]+"") %>' CssClass="label label-sm label-warning" Text="Edit"></asp:LinkButton>

                                                                

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
                    </div>
                </section>
            </div>

        </ContentTemplate>

        <Triggers>
            <asp:PostBackTrigger ControlID="savelocation" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div style="z-index: 10001;" class="windowbackground">
                <div class="progressbar breadcrumb">
                    <img alt="Loading..." src="../images/ajax-loader.gif"><br>
                    Please Wait...
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
