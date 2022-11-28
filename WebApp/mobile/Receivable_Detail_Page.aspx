<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Receivable_Detail_Page.aspx.cs" Inherits="WebApp.mobile.Receivable_Detail_Page" %>

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
        <div class="pageTitle"><%=Request.QueryString["Region"] %> - <%=Request.QueryString["Schemename"] %> <%= (string.IsNullOrWhiteSpace(Request.QueryString["dealercode"])?"":"("+Request.QueryString["dealercode"]+")") %></div>
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
                                        <a href="<%# string.Concat("Receivable_Detail_Page.aspx?SchemeName=",Request.QueryString["Schemename"],"&&Region=",Eval("Region")) %>" class="nav-link active"><strong><%# Eval("Region")  %> </strong></a>
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
                            <th scope="col" style="color: white;">Claim Amt</th>
                            <th scope="col" style="color: white;">Recd Amt</th>
                            <th scope="col" style="color: white;">Reject Amt</th>
                            <th scope="col" style="color: white;">Recover Amt</th>
                            <th scope="col" class="text-end" style="color: white;">Bal Amt</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="BSC_Data">
                            <ItemTemplate>
                                <tr>
                                    <th scope="row"><%# Eval("Month") %></th>
                                    <td>
                                        <a href="<%# string.IsNullOrWhiteSpace(Request.QueryString["dealercode"])?
                                                string.Concat("MSIL_Balance_Detail.aspx?Status=Claim&&Month=", WebApp.LIBS.Common.DateConvert( Eval("Month","01-{0}-2021").ToString(),"dd-MMMM-yyyy").ToString("MM"),"&&Region=",Request.QueryString["Region"].ToString(),"&&Schemename=",Request.QueryString["SchemeName"].ToString()):
                                                string.Concat("MSIL_Balance_Detail.aspx?Status=Claim&&Month=", WebApp.LIBS.Common.DateConvert( Eval("Month","01-{0}-2021").ToString(),"dd-MMMM-yyyy").ToString("MM"),"&&dealercode=",Request.QueryString["dealercode"].ToString(),"&&Region=",Request.QueryString["Region"].ToString(),"&&Schemename=",Request.QueryString["SchemeName"].ToString())
                                                %>">


                                            <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("Claim") ))%>
                                        </a>
                                    </td>
                                    <td>
                                        <a href="<%# string.IsNullOrWhiteSpace(Request.QueryString["dealercode"])?
                                                string.Concat("MSIL_Balance_Detail.aspx?Status=Recd&&Month=", WebApp.LIBS.Common.DateConvert( Eval("Month","01-{0}-2021").ToString(),"dd-MMMM-yyyy").ToString("MM"),"&&Region=",Request.QueryString["Region"].ToString(),"&&Schemename=",Request.QueryString["SchemeName"].ToString()):
                                                string.Concat("MSIL_Balance_Detail.aspx?Status=Recd&&Month=", WebApp.LIBS.Common.DateConvert( Eval("Month","01-{0}-2021").ToString(),"dd-MMMM-yyyy").ToString("MM"),"&&dealercode=",Request.QueryString["dealercode"].ToString(),"&&Region=",Request.QueryString["Region"].ToString(),"&&Schemename=",Request.QueryString["SchemeName"].ToString())
                                                %>">


                                            <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("Recd") ))%>
                                        </a>
                                    </td>
                                    <td>
                                        <a href="<%# string.IsNullOrWhiteSpace(Request.QueryString["dealercode"])?
                                                string.Concat("MSIL_Balance_Detail.aspx?Status=Reject&&Month=", WebApp.LIBS.Common.DateConvert( Eval("Month","01-{0}-2021").ToString(),"dd-MMMM-yyyy").ToString("MM"),"&&Region=",Request.QueryString["Region"].ToString(),"&&Schemename=",Request.QueryString["SchemeName"].ToString()):
                                                string.Concat("MSIL_Balance_Detail.aspx?Status=Reject&&Month=", WebApp.LIBS.Common.DateConvert( Eval("Month","01-{0}-2021").ToString(),"dd-MMMM-yyyy").ToString("MM"),"&&dealercode=",Request.QueryString["dealercode"].ToString(),"&&Region=",Request.QueryString["Region"].ToString(),"&&Schemename=",Request.QueryString["SchemeName"].ToString())
                                                %>">


                                            <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("Reject") ))%>
                                        </a>
                                    </td>
                                    <td>
                                        <a href="<%# string.IsNullOrWhiteSpace(Request.QueryString["dealercode"])?
                                                string.Concat("MSIL_Balance_Detail.aspx?Status=Recover&&Month=", WebApp.LIBS.Common.DateConvert( Eval("Month","01-{0}-2021").ToString(),"dd-MMMM-yyyy").ToString("MM"),"&&Region=",Request.QueryString["Region"].ToString(),"&&Schemename=",Request.QueryString["SchemeName"].ToString()):
                                                string.Concat("MSIL_Balance_Detail.aspx?Status=Recover&&Month=", WebApp.LIBS.Common.DateConvert( Eval("Month","01-{0}-2021").ToString(),"dd-MMMM-yyyy").ToString("MM"),"&&dealercode=",Request.QueryString["dealercode"].ToString(),"&&Region=",Request.QueryString["Region"].ToString(),"&&Schemename=",Request.QueryString["SchemeName"].ToString())
                                                %>">


                                            <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("Recover") ))%>
                                        </a>
                                    </td>
                                <td>
                                    <a href="<%# string.IsNullOrWhiteSpace(Request.QueryString["dealercode"])?
                                                string.Concat("MSIL_Balance_Detail.aspx?Status=Bal&&Month=", WebApp.LIBS.Common.DateConvert( Eval("Month","01-{0}-2021").ToString(),"dd-MMMM-yyyy").ToString("MM"),"&&Region=",Request.QueryString["Region"].ToString(),"&&Schemename=",Request.QueryString["SchemeName"].ToString()):
                                                string.Concat("MSIL_Balance_Detail.aspx?Status=Bal&&Month=", WebApp.LIBS.Common.DateConvert( Eval("Month","01-{0}-2021").ToString(),"dd-MMMM-yyyy").ToString("MM"),"&&dealercode=",Request.QueryString["dealercode"].ToString(),"&&Region=",Request.QueryString["Region"].ToString(),"&&Schemename=",Request.QueryString["SchemeName"].ToString())
                                                %>">
                                        <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("Bal") ))%>
                                    </a>
                                </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr class="table-primaryBlue">
                            <th scope="col" style="color: white;">YTD</th>
                            <th scope="col" style="color: white;">
                                <asp:Label ID="Claim" runat="server" /></th>
                            <th scope="col" style="color: white;">
                                <asp:Label ID="Recd" runat="server" /></th>
                            <th scope="col" style="color: white;">
                                <asp:Label ID="Reject" runat="server" /></th>
                            <th scope="col" style="color: white;">
                                <asp:Label ID="Recover" runat="server" /></th>
                            <th scope="col" class="text-end" style="color: white;">
                                <asp:Label ID="Bal" runat="server" /></th>
                        </tr>
                    </tbody>
                </table>
            </div>

        </div>

    </div>
    </div>

    <!-- * App Capsule -->

    <!-- App Bottom Menu -->
    <div class="appBottomMenu">
        <asp:Repeater runat="server" ID="Repeater1">
            <ItemTemplate>

                <a href="Receivable_Detail_Page.aspx?dealercode=<%# Eval("dealercode")  %>&&Schemename=<%= Request.QueryString["Schemename"]  %>&&Region=<%= Request.QueryString["Region"]  %>" class="item">
                    <div class="col">
                        <ion-icon name="pie-chart-outline"></ion-icon>
                        <h4 class="m-0"><%# Eval("dealercode")  %></h4>
                    </div>
                </a>
            </ItemTemplate>
        </asp:Repeater>


        <a href="MSIL_Receivable.aspx?Region=<%= Request.QueryString["Region"]  %>" class="item">
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
