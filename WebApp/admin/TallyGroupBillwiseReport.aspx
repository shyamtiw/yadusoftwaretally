<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="TallyGroupBillwiseReport.aspx.cs" Inherits="WebApp.admin.TallyGroupBillwiseReport" %>

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
    Tally Group Outstanding Bill Wise
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


                        <div class="col-md-4">
                            <label>Branch</label>
                            <asp:ListBox ID="BranchId" runat="server" SelectionMode="Multiple" CssClass="form-control"></asp:ListBox>
                        </div>
                        <div class="col-md-2">
                            <label>From  Date </label>
                            <asp:TextBox runat="server" ID="FromDate" CssClass="form-control Date"></asp:TextBox>
                        </div>

                        <div class="col-md-2">
                            <label>To Date </label>
                            <asp:TextBox runat="server" ID="Date" CssClass="form-control Date"></asp:TextBox>
                        </div>

                        <div class="col-md-3">
                            <label>Group Name </label>
                            <asp:DropDownList runat="server" ID="GroupNames" CssClass="form-control">
                                <asp:ListItem Value="NavyGEN-Debtors New Car">NavyGEN-Debtors New Car</asp:ListItem>
                                <asp:ListItem Value="NavyGEN-Debtors Service">NavyGEN-Debtors Service</asp:ListItem>
                                <asp:ListItem Value="NavyGEN-Debtors Bodyshop">NavyGEN-Debtors Bodyshop</asp:ListItem>
                                <asp:ListItem Value="NavyGEN-Debtors Counter Sale">NavyGEN-Debtors Counter Sale</asp:ListItem>
                                <asp:ListItem Value="NavyGEN-Debtors Co-Dealer">NavyGEN-Debtors Co-Dealer</asp:ListItem>
                                <asp:ListItem Value="NavyGEN-Debtors FSC">NavyGEN-Debtors FSC</asp:ListItem>
                                <asp:ListItem Value="NavyGEN-Debtors MSIL Receivable">NavyGEN-Debtors MSIL Receivable</asp:ListItem>
                                <asp:ListItem Value="NavyGEN-Debtors Used Car">NavyGEN-Debtors Used Car</asp:ListItem>
                                <asp:ListItem Value="NavyGEN-Bank Accounts">NavyGEN-Bank Accounts</asp:ListItem>
                                <asp:ListItem Value="NavyGEN-Cash In Hand">NavyGEN-Cash In Hand</asp:ListItem>
                                <asp:ListItem Value="NavyGEN-Debtors CSD">NavyGEN-Debtors CSD</asp:ListItem>
                                <asp:ListItem Value="NavyGEN-Debtors Corporate">NavyGEN-Debtors Corporate</asp:ListItem>
                                <asp:ListItem Value="NavyGEN-Debtors Insurance Renewal">NavyGEN-Debtors Insurance Renewal</asp:ListItem>
                                <asp:ListItem Value="NavyGEN-Debtors Others">NavyGEN-Debtors Others</asp:ListItem>
                                <asp:ListItem Value="NavyGEN-Debtors MDS">NavyGEN-Debtors MDS</asp:ListItem>
                                <asp:ListItem Value="NavyGEN-Debtors Finance Payout">NavyGEN-Debtors Finance Payout</asp:ListItem>

                            </asp:DropDownList>
                        </div>



                        <div class="col-md-1">
                            <label></label>
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

<asp:Content ID="Content4" ContentPlaceHolderID="Script" runat="server">

    <link rel="stylesheet" href="css/smolist.css" />

    <!-- Latest compiled and minified JavaScript -->
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery.sumoselect/3.1.6/jquery.sumoselect.min.js"></script>
    <script type="text/javascript">  
        $(document).ready(function () {
            $("#<%=BranchId.ClientID%>").SumoSelect();
        });
    </script>

</asp:Content>
