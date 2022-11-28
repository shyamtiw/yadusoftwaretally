<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Dashbaord.aspx.cs" Inherits="WebApp.mobile.Admin_Dashbaord" %>


<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport"
        content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, viewport-fit=cover" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
    <meta name="theme-color" content="#000000">
    <title>ADMIN Portal</title>
    <meta name="description" content="">
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
            <a href="#" class="headerButton">
                <ion-icon class="icon" name="notifications-outline"></ion-icon>
                <span class="badge badge-danger"></span>
            </a>
            <a href="#" class="headerButton">
                
                <span class="badge badge-danger"></span>
            </a>
        </div>
    </div>
    <!-- * App Header -->


    <!-- App Capsule -->
    <div id="appCapsule">

        <!-- Wallet Card -->
        <div class="section wallet-card-section pt-1">
            <div class="wallet-card">
                <!-- Balance -->
                <div class="balance">
                    <div class="left">
                        <span class="title">Total Retail</span>
                        <h1 class="total">150</h1>
                    </div>
                </div>
                <!-- * Balance -->
            </div>
        </div>

        <!-- Stats -->
        <div class="section">
            <div class="row mt-2">
                <div class="col-6">

                    <a href="app-Employee-Master.aspx">

                        <div class="stat-box">
                            <div class="title">Create</div>
                            <div class="value text-success">Employee</div>
                        </div>
                    </a>
                </div>

                <div class="col-6">
                    <a href="Edit-Employee.aspx">
                        <div class="stat-box">
                            <div class="title">Edit</div>
                            <div class="value text-success">Employee</div>
                        </div>
                    </a>

                </div>
            </div>
            <div class="row mt-2">
                <div class="col-6">
                    <a href="app-User-Master.aspx">
                        <div class="stat-box">
                            <div class="title">Create</div>
                            <div class="value text-primary">User</div>
                        </div>
                    </a>
                </div>
                <div class="col-6">
                    <a href="app-User-Master.aspx">
                        <div class="stat-box">
                            <div class="title">Edit</div>
                            <div class="value text-primary">User</div>
                        </div>
                    </a>
                </div>
            </div>
            <div class="row mt-2">
                <div class="col-6">
                    <a href="app-User-Master.aspx">
                        <div class="stat-box">
                            <div class="title">Create</div>
                            <div class="value text-warning">Location</div>
                        </div>
                    </a>
                </div>
                <div class="col-6">
                    <a href="app-User-Master.aspx">
                        <div class="stat-box">
                            <div class="title">Edit</div>
                            <div class="value text-warning">Location</div>
                        </div>
                    </a>
                </div>
            </div>

            <div class="row mt-2">
                <div class="col-6">
                    <a href="app-User-Master.aspx">
                        <div class="stat-box">
                            <div class="title">Disable</div>
                            <div class="value text-danger">User</div>

                        </div>
                    </a>
                </div>
                <div class="col-6">
                    <a href="Change_DSE.aspx">
                        <div class="stat-box">
                            <div class="title">Change</div>
                            <div class="value text-danger">DSE</div>
                        </div>
                    </a>
                </div>
            </div>
        </div>
    </div>
    <!-- * Stats -->

    <!-- app footer -->

   
    <!-- * app footer -->

 
    <!-- * App Capsule -->
    <!-- App Sidebar -->
    <div class="modal fade panelbox panelbox-left" id="sidebarPanel" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-body p-0">
                    <!-- profile box -->
                    <div class="profileBox pt-2 pb-2">
                        <div class="image-wrapper">
                       
                        </div>
                        <div class="in">
                            <strong>
                                <asp:Literal runat="server" ID="username"></asp:Literal></strong>
                            <div class="text-muted">
                                <asp:Literal runat="server" ID="MSPIN"></asp:Literal>
                            </div>
                            <div class="text-muted">
                                <asp:Literal runat="server" ID="Email"></asp:Literal>
                            </div>
                        </div>
                        <a href="#" class="btn btn-link btn-icon sidebar-close" data-bs-dismiss="modal">
                            <ion-icon name="close-outline"></ion-icon>
                        </a>
                    </div>
                    <!-- * profile box -->
                    <!-- menu -->
                    <div class="listview-title mt-1">Menu</div>
                    <ul class="listview flush transparent no-line image-listview">
                        <li>
                            <a href="app-Employee-Master.aspx" class="item">
                                <div class="icon-box bg-primary">
                                    <ion-icon name="pie-chart-outline"></ion-icon>
                                </div>
                                <div class="in">
                                    Create Employee
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="app-User-Master.aspx" class="item">
                                <div class="icon-box bg-primary">
                                    <ion-icon name="document-text-outline"></ion-icon>
                                </div>
                                <div class="in">
                                    Create User
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="Edit-Employee.aspx" class="item">
                                <div class="icon-box bg-primary">
                                    <ion-icon name="apps-outline"></ion-icon>
                                </div>
                                <div class="in">
                                    Edit Employee
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="app-User-Master.aspx" class="item">
                                <div class="icon-box bg-primary">
                                    <ion-icon name="card-outline"></ion-icon>
                                </div>
                                <div class="in">
                                    Edit User
                                        <span class="badge badge-primary">
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="app-User-Master.aspx" class="item">
                                <div class="icon-box bg-primary">
                                    <ion-icon name="card-outline"></ion-icon>
                                </div>
                                <div class="in">
                                    Disable User
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="Change_DSE.aspx" class="item">
                                <div class="icon-box bg-primary">
                                    <ion-icon name="card-outline"></ion-icon>
                                </div>
                                <div class="in">
                                    Change Booking DSE 
                                </div>
                            </a>
                        </li>
                        <li>
                            <a href="Pending_Booking.aspx" class="item">
                                <div class="icon-box bg-primary">
                                    <ion-icon name="card-outline"></ion-icon>
                                </div>
                                <div class="in">
                                    Import Booking Register
                                </div>
                            </a>
                        </li>

                          <li>
                         <form runat="server" id="ccv">
                           <asp:LinkButton runat="server"  CssClass="item"  ID="ExportData" OnClick="ExportData_Click">
                                <div class="icon-box bg-primary">
                                    <ion-icon name="card-outline"></ion-icon>
                                </div>
                                <div class="in">
                                    Export Excel
                                        <span class="badge badge-primary"> </span>
                                </div>
                            </asp:LinkButton>
                         </form>
                        </li>
                    </ul>
                    <!-- * menu -->

                    <!-- others -->
                    <div class="listview-title mt-1">Others</div>
                    <ul class="listview flush transparent no-line image-listview">
                        <li>
                            <a href="index.aspx" class="item">
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
                            Install <strong>Navy-GEN</strong> on your iPhone's home screen.
                       
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

     <div class="appFooter" style="position:absolute!important; width: 100%;bottom:0px;">
        <div class="footer-title">
            Copyright © Navy-GEN 2021. All Rights Reserved.
        </div>
    </div>

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
