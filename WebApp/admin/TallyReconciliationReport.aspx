<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="TallyReconciliationReport.aspx.cs" Inherits="WebApp.admin.TallyReconciliationReport" %>

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
    Tally Reconciliation Report
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FromContener" runat="server">

   
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


                                <div class="col-md-5">
                                    <label>Branch</label>
                                    <asp:ListBox ID="BranchId" runat="server" SelectionMode="Single" CssClass="form-control"></asp:ListBox>
                                </div>
                                 <div class="col-md-2">
                                    <label> From  Date </label>
                                 <asp:TextBox runat="server" ID="FromDate"  CssClass="form-control Date"></asp:TextBox>
                                </div>

                                <div class="col-md-2">
                                    <label> To Date </label>
                                 <asp:TextBox runat="server" ID="Date"  CssClass="form-control Date"></asp:TextBox>
                                </div>

                              
                                <div class="col-md-3">
                                    <label> </label>
                                    <div class="input-group">
                                      
                                        <span class="input-group-btn">
                                            
                                            <asp:LinkButton runat="server" ID="exportdata" CssClass="btn btn-primary  btn-flat" OnClick="exportdata_Click"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                                            
                                             
                                        </span>
                                    </div>

                                </div>

                                </div>


                        


                            </div>
                        </div>
                    </div>

                </div>
          


</asp:Content>

