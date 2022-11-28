<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="exportdaybookdump.aspx.cs" Inherits="WebApp.admin.exportdaybookdump" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormName" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">

        <ContentTemplate>

            <div class="row">
                <SG:Message runat="server" ID="MessageBox" />


                <div class="col-md-6">

                    <!-- general form elements disabled -->
                    <div class="box box-success box-solid" style="border: 3px solid #0b0336!important;">
                        <div class="box-header with-border" style="background: #0b0336!important; background-color: #0b0336!important;">
                            <h3 class="box-title">Export Day Book Dump</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">


                            <div class="row">

                              
                                   <div class="col-md-6">
                                    <div class="form-group">
                                        <label>From Date</label>

                                      <asp:TextBox runat="server" ID="FromDate" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                    <div class="col-md-6">
                                    <div class="form-group">
                                        <label>To Date</label>

                                      <asp:TextBox runat="server" ID="ToDate" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                
                            <div class="row">
                                   <div class="col-md-12">
                                       <asp:Literal runat="server" ID="ErrorNote"></asp:Literal>
                                       </div>
                                </div>
                            </div>
                            <div class="box-footer">
                                <asp:Button runat="server" Text="Export" OnClick="saveAccountHead_Click" ID="saveAccountHead" ValidationGroup="head" CssClass="btn btn-primary" />
                            </div>
                        </div>

                    </div>
                </div>

            </div>


        </ContentTemplate>
        
 
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
<asp:Content ID="Content4" ContentPlaceHolderID="Script" runat="server">
    
   

</asp:Content>
