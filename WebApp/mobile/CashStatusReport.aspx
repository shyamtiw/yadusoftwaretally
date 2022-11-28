<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashStatusReport.aspx.cs" Inherits="WebApp.mobile.CashStatusReport" %>

<!doctype html>
<html lang="en">

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport"
        content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, viewport-fit=cover" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
    <meta name="theme-color" content="#000000">
    <title>Navy-GEN - Cash Status Report</title>
    <meta name="description" content="Finapp HTML Mobile Template">
    <meta name="keywords" content="bootstrap, wallet, banking, fintech mobile template, cordova, phonegap, mobile, html, responsive" />
    <link rel="icon" type="image/png" href="assets/img/favicon.png" sizes="32x32">
    <link rel="apple-touch-icon" sizes="180x180" href="assets/img/icon/192x192.png">
    <link rel="stylesheet" href="assets/css/style.css">
    <link rel="manifest" href="__manifest.json">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&display=swap" rel="stylesheet">
    <style>
        .table-primaryBlue, .table-primaryBlue > td, .table-primaryBlue > th {
            background-color: navy;
        }

        th, td {
            color: black;
        }
    </style>

</head>

<body>

    <!-- loader -->
    <div id="loader">
        <img src="assets/img/logo-icon.png" alt="icon" class="loading-icon">
    </div>
    <!-- * loader -->

    <!-- App Header -->
    <div class="appHeader">
        <div class="left">
            <a href="javascript:;" class="headerButton goBack">
                <ion-icon name="chevron-back-outline"></ion-icon>
            </a>
        </div>
        <div class="pageTitle">Cash Balance Report as on :- </div>
        <div class="right">
        </div>
    </div>
    <!-- * App Header -->

    <!-- App Capsule -->
    <div id="appCapsule">

        <div class="section mt-2">
            <div class="section mt-1">
                <div class="card">
                    <div class="card-body">
                        <ul class="nav nav-tabs style1" role="tablist">
                                    <li class="nav-item">
                                        <a href="<%# string.Concat("CashStatusReport.aspx?Date=1") %>" class="nav-link active"><strong>17/05/2021</strong></a>
                                    </li>
                                    <li class="nav-item">
                                        <a href="<%# string.Concat("CashStatusReport.aspx?Date=2") %>" class="nav-link active"><strong>16/05/2021</strong></a>
                                    </li>
                                    <li class="nav-item">
                                        <a href="<%# string.Concat("CashStatusReport.aspx?Date=3") %>" class="nav-link active"><strong>15/05/2021</strong></a>
                                    </li>
                              <li class="nav-item">
                                        <a href="<%# string.Concat("CashStatusReport.aspx?Date=4") %>" class="nav-link active"><strong>14/05/2021</strong></a>
                                    </li>
                              <li class="nav-item">
                                        <a href="<%# string.Concat("CashStatusReport.aspx?Date=5") %>" class="nav-link active"><strong>13/05/2021</strong></a>
                                    </li>
                              <li class="nav-item">
                                        <a href="<%# string.Concat("CashStatusReport.aspx?Date=6") %>" class="nav-link active"><strong>12/05/2021</strong></a>
                                    </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>



        <div class="card">
            <div class="table-responsive">
                <table class="table">
                    <thead>
                        <tr class="table-primaryBlue">
                            <th scope="col" style="color: white;">Cash ledger</th>
                            <th scope="col" style="color: white;">Branch Name</th>
                            <th scope="col" style="color: white;">Op. Cash</th>
                            <th scope="col" style="color: white;">Recd From Bank/Cash</th>
                            <th scope="col" style="color: white;">DMS Receipt</th>
                            <th scope="col" style="color: white;">Other Receipt</th>
                            <th scope="col" style="color: white;">Bak Deposit</th>
                            <th scope="col" style="color: white;">DMS Rct Cancel</th>
                            <th scope="col" style="color: white;">Other Pmt</th>
                            <th scope="col" style="color: white;">Closing Cash</th>
                            <th scope="col" style="color: white;">Physical Cash</th>
                            <th scope="col" class="text-end" style="color: white;">Difference</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="Cash_Status_Report">
                            <ItemTemplate>
                                <tr>
                                    <th scope="row"><%# Eval("Ledg_Name") %></th>
                                    <th scope="row"><%# Eval("BranchName") %></th>

                                    <td>

                                        <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("OpeningCash") ))%>
                                            
                                    </td>
                                    <td>
                                        <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("ContraReceipt") ))%>

                                    </td>
                                    <td>
                                        <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("DMSReceipt") ))%>
                                    </td>
                                    <td>
                                        <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("OtherReceipt") ))%>
                                            
                                    </td>
                                    <td>
                                        <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("BankDeposit") ))%>
                                    </td>
                                    <td>
                                        <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("DMSRcptCancelled") ))%>
                                    </td>
                                    <td>
                                        <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("OtherPayment") ))%>
                                    </td>
                                    <td>
                                        <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("ClosingCash") ))%>
                                    </td>
                                    <td>
                                        <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("PhysicalCash") ))%>
                                    </td>
                                    <td>
                                        <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("Difference") ))%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr class="table-primaryBlue">
                            <th scope="col" style="color: white;">YTD</th>
                            <th scope="col" style="color: white;"></th>
                            <th scope="col" style="color: white;">
                                <asp:Label ID="OpeningCash" runat="server" /></th>
                            <th scope="col" class="text-end" style="color: white;">
                                <asp:Label ID="ContraReceipt" runat="server" /></th>
                            <th scope="col" style="color: white;">
                                <asp:Label ID="DMSReceipt" runat="server" /></th>
                            <th scope="col" style="color: white;">
                                <asp:Label ID="OtherReceipt" runat="server" /></th>
                            <th scope="col" class="text-end" style="color: white;">
                                <asp:Label ID="BankDeposit" runat="server" /></th>
                            <th scope="col" style="color: white;">
                                <asp:Label ID="DMSRcptCancelled" runat="server" /></th>
                            <th scope="col" class="text-end" style="color: white;">
                                <asp:Label ID="OtherPayment" runat="server" /></th>
                            <th scope="col" style="color: white;">
                                <asp:Label ID="ClosingCash" runat="server" /></th>
                            <th scope="col" style="color: white;">
                                <asp:Label ID="PhysicalCash" runat="server" /></th>
                            <th scope="col" style="color: white;">
                                <asp:Label ID="CashDifference" runat="server" /></th>

                        </tr>
                    </tbody>
                </table>
            </div>

        </div>

    </div>


    <!-- * App Capsule -->

    <!-- App Bottom Menu -->
    <div class="appBottomMenu">
        <%--        <asp:Repeater runat="server" ID="Repeater1">
            <ItemTemplate>

                <a href="Exchange_Claim_Summary.aspx?Region=<%= Request.QueryString["Region"]  %>&&dealercodeforcode=<%# Eval("dealercodeforcode")  %>" class="item">
                    <div class="col">
                        <ion-icon name="pie-chart-outline"></ion-icon>
                        <h4 class="m-0"><%# Eval("dealercodeforcode")  %></h4>
                    </div>
                </a>
            </ItemTemplate>
        </asp:Repeater>--%>


        <a href="Mobile_Home.aspx" class="item">
            <div class="col">
                <ion-icon name="document-text-outline"></ion-icon>
                <h4 class="m-0">Back to Home</h4>
            </div>
        </a>
    </div>
    <!-- App Bottom Menu -->
    <!-- app footer -->
    <div class="appFooter">
        <div class="footer-title">
            Copyright © Navy-GEN 2021. All Rights Reserved.
        </div>
    </div>


    <!-- ========= JS Files =========  -->

    <!-- Android Add to Home Action Sheet -->

    <script src="assets/js/lib/jquery-3.4.1.min.js"></script>
    <!-- Bootstrap-->
    <script src="assets/js/lib/popper.min.js"></script>
    <script src="assets/js/lib/bootstrap.bundle.min.js"></script>
    <!-- Ionicons -->
    <script src="https://unpkg.com/ionicons@5.4.0/dist/ionicons.js"></script>
    <%--<script src="https://unpkg.com/ionicons@4.5.10-0/dist/ionicons.js"></script>--%>
    <!-- Splide -->
    <script src="assets/js/plugins/splide/splide.min.js"></script>
    <!-- Base Js File -->
    <script src="assets/js/base.js"></script>
</body>



</html>
