<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MSIL_Statement_Summary.aspx.cs" Inherits="WebApp.mobile.MSIL_Statement_Summary" %>

<!doctype html>
<html lang="en">

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport"
        content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, viewport-fit=cover" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
    <meta name="theme-color" content="#000000">
    <title>Navy-GEN - MSIL Statement</title>
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
         <div class="pageTitle"><%= (string.IsNullOrWhiteSpace(Request.QueryString["Type"])?"Maruti Statement ":"Maruti Statement for "+Request.QueryString["Type"]+"") %> <%= (string.IsNullOrWhiteSpace(Request.QueryString["Account"])?"":"("+Request.QueryString["Account"]+")") %></div>
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
                                        <a href="<%# string.Concat("MSIL_Statement_Summary.aspx?Type=",Eval("Type")) %>" class="nav-link active"><strong><%# Eval("Type")  %> </strong></a>
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
                            <th scope="col" style="color: white;">Location</th>
                            <th scope="col" style="color: white;">Opening</th>
                            <th scope="col" style="color: white;">Debit</th>
                            <th scope="col" style="color: white;">Credit</th>
                            <th scope="col" class="text-end" style="color: white;">Closing</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="MSIL_Statement_Data">
                            <ItemTemplate>
                                <tr>
                                    <th scope="row"> 
                                     <a href="MSIL_Statement_Detail.aspx?Type=<%= Request.QueryString["Type"]  %>&&DealerCode=<%# Eval("Location")  %>&&Account=<%# Request.QueryString["Account"] %>"  class="item"><%# Eval("Location") %>
                                       </a></th>

                                    <td>
                                        <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("Opening") ))%>
                                    </td>
                                    <td>
                                        <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("Debit") ))%>
                                    </td>
                                    <td>
                                        <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("Credit") ))%>
                                    </td>
                                    <td>
                                        <%#  String.Format(new System.Globalization.CultureInfo("hi-IN"), "{0:c}",  WebApp.LIBS.Common.ConvertDecimal(  Eval("Closing") ))%>
                                    </td>
                               </tr>
                            </ItemTemplate>
                        </asp:Repeater>
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

                <a href="MSIL_Statement_Summary.aspx?Account=<%# Eval("Account") %>&&Type=<%# Request.QueryString["Type"]%>" class="item">
                    <div class="col">
                        <ion-icon name="pie-chart-outline"></ion-icon>
                        <h4 class="m-0"><%# Eval("Account")  %></h4>
                    </div>
                </a>
            </ItemTemplate>
        </asp:Repeater>

        <a href="Accounts_Home.aspx" class="item">
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
