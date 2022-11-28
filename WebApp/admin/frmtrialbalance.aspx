<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="frmtrialbalance.aspx.cs" Inherits="WebApp.admin.frmtrialbalance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .t01 th, td {
            border: 1px solid black;
            border-collapse: collapse;
            padding: 12px !important;
            font-size: 15px;
        }

        .t02 th {
            background-color: navy;
            color: white;
        }

        .disn {
            display: none;
        }

        .disy {
            display: block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormName" runat="server">
   Trial Balance
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">

        <ContentTemplate>

            <div class="row">
                <SG:Message runat="server" ID="MessageBox" />


                <div class="col-md-12">

                    <!-- general form elements disabled -->
                    <div class="box box-success box-solid" style="border: 3px solid #0b0336!important;">
                        <div class="box-header with-border" style="background: #0b0336!important; background-color: #0b0336!important;">
                            <h3 class="box-title">Data List</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">



                            <div class="row">


                                <div class="col-md-6">
                                    <label>Branch</label>
                                    <asp:ListBox ID="BranchId" runat="server" SelectionMode="Multiple" CssClass="form-control"></asp:ListBox>
                                </div>
                                <div class="col-md-3">
                                    <label>From Date</label>

                                    <asp:TextBox runat="server" ID="FromDate" CssClass="form-control Date"></asp:TextBox>

                                </div>
                                <div class="col-md-3">
                                    <label>To Date</label>
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="ToDate" CssClass="form-control Date"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton runat="server" ID="btnsearchdata" CssClass="btn btn-warning btn-flat" OnClick="btnsearchdata_Click"><i class="fa fa-fw fa-search"></i></asp:LinkButton>

                                        </span>
                                    </div>

                                </div>



                                <hr />
                                <hr />
                                <hr />

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="width:95%;" style="padding-left: 10px">
                                            <div style="overflow-x: auto;">
                                                <table class="t01 t02" style="width: 99%">
                                                    <tr>
                                                        <table class="t01 t02" style="width: 99%">
                                                            <tbody>
                                                                
                                                                <asp:Literal runat="server" ID="MulticompData"></asp:Literal>
                                                            </tbody>
                                                        </table>
                                                        
                                                    </tr>


                                                </table>
                                            </div>
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
    <script type="text/javascript">  
        $(function () {
            $('[id*=BranchId]').multiselect({
                includeSelectAllOption: true
            });
        });
    </script>
</asp:Content>

