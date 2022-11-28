<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MSIL_Balance_Detail.aspx.cs" Inherits="WebApp.mobile.MSIL_Balance_Detail" %>

<!doctype html>
<html lang="en">


<!-- Mirrored from finapp.bragherstudio.com/view3/component-table.html by HTTrack Website Copier/3.x [XR&CO'2014], Mon, 26 Apr 2021 10:19:57 GMT -->
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport"
        content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, viewport-fit=cover" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
    <meta name="theme-color" content="#000000">
    <title>Finapp - Mobile Template</title>
    <meta name="description" content="Finapp HTML Mobile Template">
    <meta name="keywords" content="bootstrap, wallet, banking, fintech mobile template, cordova, phonegap, mobile, html, responsive" />
    <link rel="icon" type="image/png" href="assets/img/favicon.png" sizes="32x32">
    <link rel="apple-touch-icon" sizes="180x180" href="assets/img/icon/192x192.png">
    <link rel="stylesheet" href="assets/css/style.css">
    <link rel="manifest" href="__manifest.json">
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
        <div class="pageTitle">Table</div>
        <div class="right">
        </div>
    </div>
    <!-- * App Header -->

    <!-- App Capsule -->
    <div id="appCapsule">


        <div class="section mt-2">
            <div class="section-title">Default</div>
            <div class="card">

                <div class="table-responsive">
                    <table class="table">
                        <thead>
                            <tr>
                                <th scope="col">Model Code</th>
                                <th scope="col">VIN No</th>
                                <th scope="col">Scheme Month</th>
                                <th scope="col">Dealer Code</th>
                                <th scope="col">Claim Amt</th>
                                <th scope="col">Received Amt</th>
                                <th scope="col">Reject Amt</th>
                                <th scope="col">Balance Amt</th>

                                <th scope="col" class="text-end">Remarks</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="MSIL_Claim_Detail">
                                <ItemTemplate>
                                    <tr>
                                        <th scope="row"><%# Eval("MODELCODE") %></th>
                                        <td> <%# Eval("VIN") %></td>
                                        <td> <%# Eval("SCHEMEMONTH") %></td>
                                        <td> <%# Eval("DEALERCODE") %></td>
                                        <td><%#  Eval("Claim") %></td>
                                        <td><%#  Eval("Recd")%></td>
                                        <td><%#   Eval("Reject") %></td>
                                        <td><%#  Eval("Recover") %></td>
                                        <td><%#  Eval("Balance") %></td>
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
        <a href="index.html" class="item">
            <div class="col">
                <ion-icon name="pie-chart-outline"></ion-icon>
                <strong>Overview</strong>
            </div>
        </a>
        <a href="app-pages.html" class="item">
            <div class="col">
                <ion-icon name="document-text-outline"></ion-icon>
                <strong>Pages</strong>
            </div>
        </a>
        <a href="app-components.html" class="item">
            <div class="col">
                <ion-icon name="apps-outline"></ion-icon>
                <strong>Components</strong>
            </div>
        </a>
        <a href="app-cards.html" class="item">
            <div class="col">
                <ion-icon name="card-outline"></ion-icon>
                <strong>My Cards</strong>
            </div>
        </a>
        <a href="#" class="item">
            <div class="col">
                <ion-icon name="settings-outline"></ion-icon>
                <strong>Settings</strong>
            </div>
        </a>
    </div>
    <!-- * App Bottom Menu -->



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


<!-- Mirrored from finapp.bragherstudio.com/view3/component-table.html by HTTrack Website Copier/3.x [XR&CO'2014], Mon, 26 Apr 2021 10:19:57 GMT -->
</html>
