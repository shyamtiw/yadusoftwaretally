<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Exchange_Claim_Summary.aspx.cs" Inherits="WebApp.mobile.Exchange_Claim_Summary" %>

<!doctype html>
<html lang="en">

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport"
        content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, viewport-fit=cover" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
    <meta name="theme-color" content="#000000">
    <title>Navy-GEN - MSIL Receivable Detail Pag</title>
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
        <div class="pageTitle"><%= (string.IsNullOrWhiteSpace(Request.QueryString["Region"])?"Exchange Claim Summary ":"Exchange Claim Summary for Region "+Request.QueryString["Region"]+"") %> <%= (string.IsNullOrWhiteSpace(Request.QueryString["dealercodeforcode"])?"":"("+Request.QueryString["dealercodeforcode"]+")") %></div>
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
                            <asp:Repeater runat="server" ID="Repeater3">
                                <ItemTemplate>
                                    <li class="nav-item">
                                        <a href="<%# string.Concat("Exchange_Claim_Summary.aspx?Region=",Eval("Region")) %>" class="nav-link active"><%# Eval("Region")  %> </strong></a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
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
                            <th scope="col" style="color: white;">Month</th>
                            <th scope="col" style="color: white;">Accepted</th>
                            <th scope="col" style="color: white;">MSIL Submitted</th>
                            <th scope="col" style="color: white;">Clarification Submitted</th>
                            <th scope="col" style="color: white;">Clarification Required</th>
                            <th scope="col" style="color: white;">Reject</th>
                            <th scope="col" style="color: white;">Time Barred</th>
                            <th scope="col" style="color: white;">Pending for Submit</th>

                            <th scope="col" class="text-end" style="color: white;">Total Claim</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="Exchange_Claim_Data">
                            <ItemTemplate>
                                <tr>
                                    <th scope="row"><%# Eval("Month") %></th>
                                    <td>

                                        <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("Accept") ))%>
                                            
                                    </td>
                                    <td>
                                        <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("MSIl_Submitted") ))%>

                                    </td>
                                    <td>
                                        <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("Clarification_Submit") ))%>
                                    </td>
                                    <td>
                                        <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("Clarification_Req") ))%>
                                            
                                    </td>
                                    <td>
                                        <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("Reject") ))%>
                                    </td>
                                    <td>
                                        <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("Time_barred") ))%>
                                    </td>
                                    <td>
                                        <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("Pending_For_Submit") ))%>
                                    </td>

                                    <td>
                                        <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("Accept") )+WebApp.LIBS.Common.ConvertDecimal(  Eval("MSIl_Submitted") )+WebApp.LIBS.Common.ConvertDecimal(  Eval("Clarification_Submit") )+WebApp.LIBS.Common.ConvertDecimal(  Eval("Clarification_Req") )+WebApp.LIBS.Common.ConvertDecimal(  Eval("Reject") )+WebApp.LIBS.Common.ConvertDecimal(  Eval("Time_barred") )+WebApp.LIBS.Common.ConvertDecimal(  Eval("Pending_For_Submit") ))%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr class="table-primaryBlue">
                            <th scope="col" style="color: white;">YTD</th>
                            <th scope="col" style="color: white;">
                                <asp:Label ID="Accept" runat="server" /></th>
                            <th scope="col" class="text-end" style="color: white;">
                                <asp:Label ID="MSIL_Submitted" runat="server" /></th>
                            <th scope="col" style="color: white;">
                                <asp:Label ID="Clarification_Submit" runat="server" /></th>
                            <th scope="col" style="color: white;">
                                <asp:Label ID="Clarification_Req" runat="server" /></th>
                            <th scope="col" class="text-end" style="color: white;">
                                <asp:Label ID="Reject" runat="server" /></th>
                            <th scope="col" style="color: white;">
                                <asp:Label ID="Time_barred" runat="server" /></th>
                            <th scope="col" class="text-end" style="color: white;">
                                <asp:Label ID="Pending_For_Submit" runat="server" /></th>
                            <th scope="col" style="color: white;">
                                <asp:Label ID="GTExchange" runat="server" /></th>
                        </tr>
                    </tbody>
                </table>
            </div>

        </div>

    </div>


    <!-- * App Capsule -->

    <!-- App Bottom Menu -->
    <div class="appBottomMenu">
        <asp:Repeater runat="server" ID="Repeater1">
            <ItemTemplate>

                <a href="Exchange_Claim_Summary.aspx?Region=<%= Request.QueryString["Region"]  %>&&dealercodeforcode=<%# Eval("dealercodeforcode")  %>" class="item">
                    <div class="col">
                        <ion-icon name="pie-chart-outline"></ion-icon>
                        <h4 class="m-0"><%# Eval("dealercodeforcode")  %></h4>
                    </div>
                </a>
            </ItemTemplate>
        </asp:Repeater>


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
