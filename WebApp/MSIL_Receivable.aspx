<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MSIL_Receivable.aspx.cs" Inherits="WebApp.mobile.MSIL_Receivable" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport"
        content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, viewport-fit=cover" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
    <meta name="theme-color" content="#000000">
    <title>AutoVYN - Finance Portal</title>
    <meta name="description" content="Finapp HTML Mobile Template">
    <meta name="keywords"
        content="bootstrap, wallet, banking, fintech mobile template, cordova, phonegap, mobile, html, responsive" />
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
    <div class="appHeader bg-primary text-light">
        <div class="left">
            <a href="#" class="headerButton" data-bs-toggle="modal" data-bs-target="#sidebarPanel">
               <ion-icon name="menu-outline"></ion-icon>
            </a>

        </div>
        <div class="pageTitle">
            <img src="assets/img/logo.png" alt="logo" class="logo">
        </div>
        <div class="right">
            <a href="app-notifications.html" class="headerButton">
                <ion-icon class="icon" name="notifications-outline"></ion-icon>
                <span class="badge badge-danger">4</span>
            </a>
            <a href="app-settings.html" class="headerButton">
                <img src="assets/img/sample/avatar/avatar1.jpg" alt="image" class="imaged w32">
                <span class="badge badge-danger">6</span>
            </a>
        </div>
    </div>
    <!-- * App Header -->

    <form runat="server" id="DataFroms">
        <asp:ScriptManager  runat="server" ID="ssdsd" EnablePageMethods="true"></asp:ScriptManager>
    <!-- App Capsule -->
      <div id="appCapsule">

        <!-- Wallet Card -->
        <div class="section wallet-card-section pt-1">
            <div class="wallet-card">
                <!-- Balance -->
                <div class="balance">
                    <div class="left">
                        <span class="title">Total Receivable</span>
                        <strong style="color: black">
                            <asp:Label ID="Claim" runat="server" /></strong>
                    </div>
                    <div class="left">
                        <span class="title">Received Amount</span>
                        <strong style="color: black">
                            <asp:Label ID="Recd" runat="server" /></strong>
                    </div>
                    <div class="left">
                        <span class="title">Rejected Amount</span>
                        <strong style="color: black">
                            <asp:Label ID="Reject" runat="server" /></strong>
                    </div>
                    <div class="left">
                        <span class="title">Recovered Amount</span>
                        <strong style="color: black">
                            <asp:Label ID="Recover" runat="server" /></strong>
                    </div>
                    <div class="left">
                        <span class="title">Balance Amount</span>
                        <strong style="color: black">
                            <asp:Label ID="Bal" runat="server" /></strong>
                    </div>

                    <div class="right">
                        <a href="#" class="button" data-bs-toggle="modal" data-bs-target="#depositActionSheet">
                            <ion-icon name="add-outline"></ion-icon>
                        </a>
                    </div>
                </div>
            
        <!-- * Balance -->
        <!-- Wallet Footer -->
            <div class="wallet-footer">

            <asp:Repeater runat="server" ID="Repeater3">
                <ItemTemplate>

                    <div class="item">
                        <a href="Receivable_Detail_Page.aspx" class="item">
                            <div class="icon-wrapper bg-<%# Container.ItemIndex%3==0?"danger":Container.ItemIndex%2==0?"success":"warning" %>">
                                <ion-icon name="arrow-down-outline"></ion-icon>
                            </div>
                            <strong><%# Eval("Region")  %> </strong>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <!-- * Wallet Footer -->
            </div>
        <!-- Stats -->
        <div class="section">
            <div class="row">

                <asp:Repeater runat="server" ID="Repeater2">
                    <ItemTemplate>
                        <div class="col-md-6" style="padding-bottom: 5px!important">
                            <a href="Receivable_Detail_Page.aspx" class="item">
                                <div class="stat-box">
                                    <div class="value text-success"><%# Eval("SchemeName")  %></div>
                                    <div><strong>Receivable : <%# Eval("Claim")  %> </strong></div>
                                    <div><strong>Received   : <%# Eval("Recd")  %></strong></div>
                                    <div><strong>Rejected   :  <%# Eval("Reject")  %></strong></div>
                                    <div><strong>Recovered  :  <%# Eval("Recover")  %></strong></div>
                                    <div><strong>Balance    : <%# Eval("Bal")  %></strong></div>
                                </div>
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <!-- * Transactions -->
            </div>
        <!-- app footer -->
        <div class="appFooter">
            <div class="footer-title">
                Copyright © AutoVYN 2021. All Rights Reserved.
           
            </div>
        </div>

    </div>
    <!-- * App Capsule -->
    <!-- App Sidebar -->
    <div class="modal fade panelbox panelbox-left" id="sidebarPanel" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-body p-0">
                    <!-- profile box -->
                    <div class="profileBox pt-2 pb-2">
                        <div class="image-wrapper">
                            <img src="assets/img/sample/avatar/avatar1.jpg" alt="image" class="imaged  w36">
                        </div>
                        <div class="in">
                            <strong><%= WebApp.LIBS.SiteSession.StringUserName %></strong>
                            
                        </div>
                        <a href="#" class="btn btn-link btn-icon sidebar-close" data-bs-dismiss="modal">
                            <ion-icon name="close-outline"></ion-icon>
                        </a>
                    </div>
                    <!-- * profile box -->

                    <!-- action group -->
                    <div class="action-group">
                        <a href="index.html" class="action-button">
                            <div class="in">
                                <div class="iconbox">
                                    <ion-icon name="add-outline"></ion-icon>
                                </div>
                                Central-1
                           
                            </div>
                        </a>
                        <a href="index.html" class="action-button">
                            <div class="in">
                                <div class="iconbox">
                                    <ion-icon name="arrow-down-outline"></ion-icon>
                                </div>
                                Central-2
                           
                            </div>
                        </a>
                        <a href="index.html" class="action-button">
                            <div class="in">
                                <div class="iconbox">
                                    <ion-icon name="arrow-forward-outline"></ion-icon>
                                </div>
                                Central-3
                           
                            </div>
                        </a>
                        <a href="app-cards.html" class="action-button">
                            <div class="in">
                                <div class="iconbox">
                                    <ion-icon name="card-outline"></ion-icon>
                                </div>
                                Central-4
                           
                            </div>
                        </a>
                    </div>
                    <!-- * action group -->

                    <!-- menu -->
                    <div class="listview-title mt-1">Menu</div>
                    <ul class="listview flush transparent no-line image-listview">
                        <li>
                            <a href="index.html" class="item">
                                <div class="icon-box bg-primary">
                                    <ion-icon name="pie-chart-outline"></ion-icon>
                                </div>
                                <div class="in">
                                    Sales Performance
                                   
                                    <span class="badge badge-primary">10</span>
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="app-pages.html" class="item">
                                <div class="icon-box bg-primary">
                                    <ion-icon name="document-text-outline"></ion-icon>
                                </div>
                                <div class="in">
                                    Service Performance
                               
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="MSIL_Receivable.aspx" class="item">
                                <div class="icon-box bg-primary">
                                    <ion-icon name="apps-outline"></ion-icon>
                                </div>
                                <div class="in">
                                    Maruti Claims
                               
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="BSC_NSC_Dashboard.aspx" class="item">
                                <div class="icon-box bg-primary">
                                    <ion-icon name="card-outline"></ion-icon>
                                </div>
                                <div class="in">
                                    Balance Score Card 
                               
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="BSC_NSC_Dashboard.aspx" class="item">
                                <div class="icon-box bg-primary">
                                    <ion-icon name="card-outline"></ion-icon>
                                </div>
                                <div class="in">
                                    Nexa Score Card
                               
                                </div>
                            </a>
                        </li>
                    </ul>
                    <!-- * menu -->

                    <!-- others -->
                    <div class="listview-title mt-1">Others</div>
                    <ul class="listview flush transparent no-line image-listview">
                        <li>
                            <a href="app-settings.html" class="item">
                                <div class="icon-box bg-primary">
                                    <ion-icon name="settings-outline"></ion-icon>
                                </div>
                                <div class="in">
                                    Insurance
                               
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="component-messages.html" class="item">
                                <div class="icon-box bg-primary">
                                    <ion-icon name="chatbubble-outline"></ion-icon>
                                </div>
                                <div class="in">
                                    Bodyshop Claims
                               
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="component-add-to-home.aspx" class="item">
                                <div class="icon-box bg-primary">
                                    <ion-icon name="log-out-outline"></ion-icon>
                                </div>
                                <div class="in">
                                    Add to Home Screen
                               
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="app-login.html" class="item">
                                <div class="icon-box bg-primary">
                                    <ion-icon name="log-out-outline"></ion-icon>
                                </div>
                                <div class="in">
                                    Log out
                               
                                </div>
                            </a>
                        </li>


                    </ul>
                    <!-- * others -->

                </div>
            </div>
        </div>
    </div>
    <!-- * App Sidebar -->
    <!-- iOS Add to Home Action Sheet -->
    <div class="modal inset fade action-sheet ios-add-to-home" id="ios-add-to-home-screen" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Add to Home Screen</h5>
                    <a href="#" class="close-button" data-bs-dismiss="modal">
                        <ion-icon name="close"></ion-icon>
                    </a>
                </div>
                <div class="modal-body">
                    <div class="action-sheet-content text-center">
                        <div class="mb-1">
                            <img src="assets/img/icon/192x192.png" alt="image" class="imaged w64 mb-2">
                        </div>
                        <div>
                            Install <strong>AutoVYN</strong> on your iPhone's home screen.
                       
                        </div>
                        <div>
                            Tap
                            <ion-icon name="share-outline"></ion-icon>
                            and Add to homescreen.
                       
                        </div>
                        <div class="mt-2">
                            <button class="btn btn-primary btn-block" data-bs-dismiss="modal">CLOSE</button>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <!-- * iOS Add to Home Action Sheet -->

        </form>
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
