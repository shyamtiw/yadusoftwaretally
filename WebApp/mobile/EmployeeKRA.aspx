<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeKRA.aspx.cs" Inherits="WebApp.mobile.EmployeeKRA" %>

<!doctype html>
<html lang="en">


<!-- Mirrored from finapp.bragherstudio.com/view3/component-listview.html by HTTrack Website Copier/3.x [XR&CO'2014], Mon, 26 Apr 2021 10:19:57 GMT -->
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport"
        content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, viewport-fit=cover" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
    <meta name="theme-color" content="#000000">
    <title>HRMS - KRA Page</title>
    <meta name="description" content="Finapp HTML Mobile Template">
    <meta name="keywords" content="bootstrap, wallet, banking, fintech mobile template, cordova, phonegap, mobile, html, responsive" />
    <link rel="icon" type="image/png" href="assets/img/favicon.png" sizes="32x32">
    <link rel="apple-touch-icon" sizes="180x180" href="assets/img/icon/192x192.png">
    <link rel="stylesheet" href="assets/css/style.css">
    <link rel="manifest" href="__manifest.json">
</head>

<body>
    <form runat="server" id="EmployeeKRA">
        <!-- loader -->
        <div id="loader">
            <img src="assets/img/logo-icon.png" alt="icon" class="loading-icon">
        </div>
        <!-- * loader -->

        <!-- App Header -->
        <div class="appHeader">
            <div class="left">
                <a href="javascript:;" class="headerButton goBack">
                    <ion-icon name="chevron-back-outline"> </ion-icon>
                </a>
            </div>
            <div class="pageTitle">
                Job Title :-
            <asp:Label ID="jobtitle" runat="server" />
                Reporting To :-
            <asp:Label ID="reportto" runat="server" />
            </div>
            <div class="right">
            </div>
        </div>
        <!-- * App Header -->

        <!-- App Capsule -->
        <div id="appCapsule">

            <div class="listview-title mt-2">Job purpose</div>
            <ul class="listview simple-listview">

                <li>
                    <div class="item">
                        <a href="#" data-bs-toggle="modal" data-bs-target="#KRAJobPurpose">
                            <strong>
                                <asp:Label ID="jobpurpose" runat="server" /></strong>
                        </a>
                    </div>
                </li>
            </ul>

            <div class="listview-title mt-2">Duties and responsibilities</div>
            <ul class="listview simple-listview inset">
                <asp:Repeater runat="server" ID="EmployeeKRA1">
                    <ItemTemplate>
                        <li>
                            <a href="#" data-bs-toggle="modal" data-bs-target="#KRADuties">
                                <strong><%# Eval("Duties")  %></strong>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div class="section mt-2">
                <div class="card">

                    <div class="table-responsive">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th scope="col"></th>
                                    <th scope="col">HOD</th>
                                    <th scope="col" class="text-end">GM-HR</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <th scope="row">Approved By : </th>
                                    <td><%# Eval("ApprovedbyHOD")  %></td>
                                    <td class="text-end text-primary"><%# Eval("ApprovedbyHR")  %></td>
                                </tr>
                                <tr>
                                    <th scope="row">Date of Approved</th>
                                    <td><%# Eval("Approvedatehod")  %></td>
                                    <td class="text-end text-primary"><%# Eval("Approvedatehr")  %></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>

                </div>
            </div>

            <div class="section mt-2">
                <div class="card">

                    <div class="table-responsive">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th scope="col">I read and understood my job description as mentioned above. I am committed to follow it     with my best efforts.</th>
                                </tr>
                            </thead>
                        </table>
                    </div>

                </div>
            </div>
            <div class="section mt-1">
                <!-- do not forget to delete me-1 and mb-1 when copy / paste codes -->
                <button type="button" class="btn btn-primary me-1 mb-1">Accepted</button>
                <button type="button" class="btn btn-primary me-1 mb-1">Not Accepted</button>
                <button type="button" class="btn btn-primary me-1 mb-1">
               
                     <a href="#" data-bs-toggle="modal" data-bs-target="#KRADutiesAdd"> 
                         Add new Duty
                            </a>
                    </button>
            </div>


        </div>
        <!-- * App Capsule -->

        <!-- App Bottom Menu -->
        <!-- Job Purpose Action Sheet -->
        <div class="modal fade action-sheet" id="KRAJobPurpose" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Edit Job Purpose</h5>
                    </div>
                    <div class="modal-body">
                        <div class="action-sheet-content">
                            <form>
                                <div class="form-group basic">
                                    <label class="label"><strong>Job Purpose</strong></label>
                                    <div class="input-group mb-2">
                                        <asp:TextBox runat="server" ID="BranchName" CssClass="form-control" placeholder="Enter Job Purpose"
                                            value="" />
                                    </div>
                                </div>
                                <div class="form-group basic">
                                    <asp:Button runat="server" ID="Submits" CssClass="btn btn-primary btn-block btn-lg"
                                        Text="Update" OnClick="Submits_Click"></asp:Button>
                                    <asp:Button runat="server" ID="Delete" CssClass="btn btn-primary btn-block btn-lg"
                                        Text="Delete" OnClick="Deletes_Click"></asp:Button>

                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- * Job Purpose Action Sheet -->
        <!-- EMployee Edit Duties Action Sheet -->
        <div class="modal fade action-sheet" id="KRADuties" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Edit Duties & Responsibiities</h5>
                    </div>
                    <div class="modal-body">
                        <div class="action-sheet-content">
                            <form>
                                <div class="form-group basic">
                                    <label class="label"><strong>Duties & Responsibility</strong></label>
                                    <div class="input-group mb-2">
                                        <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" placeholder="Enter New Duty / Responsibility"
                                            value="" />
                                    </div>
                                </div>
                                <div class="form-group basic">
                                    <asp:Button runat="server" ID="Button1" CssClass="btn btn-primary btn-block btn-lg"
                                        Text="Update" OnClick="Submits_Click"></asp:Button>
                                    <asp:Button runat="server" ID="Button2" CssClass="btn btn-primary btn-block btn-lg"
                                        Text="Delete" OnClick="Deletes_Click"></asp:Button>

                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- * Employee Edit Duties Action Sheet 
         <!-- EMployee Add Duties Action Sheet -->
        <div class="modal fade action-sheet" id="KRADutiesAdd" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Add Duties & Responsibiities</h5>
                    </div>
                    <div class="modal-body">
                        <div class="action-sheet-content">
                            <form>
                                <div class="form-group basic">
                                    <label class="label"><strong>Duties & Responsibility</strong></label>
                                    <div class="input-group mb-2">
                                        <asp:TextBox runat="server" ID="TextBox2" CssClass="form-control" placeholder="Enter New Duty / Responsibility"
                                            value="" />
                                    </div>
                                </div>
                                <div class="form-group basic">
                                    <asp:Button runat="server" ID="Button3" CssClass="btn btn-primary btn-block btn-lg"
                                        Text="Update" OnClick="Submits_Click"></asp:Button>
                                    <asp:Button runat="server" ID="Button4" CssClass="btn btn-primary btn-block btn-lg"
                                        Text="Delete" OnClick="Deletes_Click"></asp:Button>

                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- * Employee Add Duties Action Sheet -->
        <!-- * App Bottom Menu -->

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
                                <strong>Sebastian Doe</strong>
                                <div class="text-muted">4029209</div>
                            </div>
                            <a href="#" class="btn btn-link btn-icon sidebar-close" data-bs-dismiss="modal">
                                <ion-icon name="close-outline"></ion-icon>
                            </a>
                        </div>
                        <!-- * profile box -->
                        <!-- balance -->
                        <div class="sidebar-balance">
                            <div class="listview-title">Balance</div>
                            <div class="in">
                                <h1 class="amount">$ 2,562.50</h1>
                            </div>
                        </div>
                        <!-- * balance -->

                        <!-- action group -->
                        <div class="action-group">
                            <a href="index.html" class="action-button">
                                <div class="in">
                                    <div class="iconbox">
                                        <ion-icon name="add-outline"></ion-icon>
                                    </div>
                                    Deposit
                                </div>
                            </a>
                            <a href="index.html" class="action-button">
                                <div class="in">
                                    <div class="iconbox">
                                        <ion-icon name="arrow-down-outline"></ion-icon>
                                    </div>
                                    Withdraw
                                </div>
                            </a>
                            <a href="index.html" class="action-button">
                                <div class="in">
                                    <div class="iconbox">
                                        <ion-icon name="arrow-forward-outline"></ion-icon>
                                    </div>
                                    Send
                                </div>
                            </a>
                            <a href="app-cards.html" class="action-button">
                                <div class="in">
                                    <div class="iconbox">
                                        <ion-icon name="card-outline"></ion-icon>
                                    </div>
                                    My Cards
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
                                        Overview
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
                                        Pages
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="app-components.html" class="item">
                                    <div class="icon-box bg-primary">
                                        <ion-icon name="apps-outline"></ion-icon>
                                    </div>
                                    <div class="in">
                                        Components
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="app-cards.html" class="item">
                                    <div class="icon-box bg-primary">
                                        <ion-icon name="card-outline"></ion-icon>
                                    </div>
                                    <div class="in">
                                        My Cards
                                    </div>
                                </a>
                            </li>
                        </ul>
                        <!-- * menu -->

                        <!-- others -->
                        <div class="listview-title mt-1">Others</div>
                        <ul class="listview flush transparent no-line image-listview">
                            <li>
                                <a href="#" class="item">
                                    <div class="icon-box bg-primary">
                                        <ion-icon name="settings-outline"></ion-icon>
                                    </div>
                                    <div class="in">
                                        Settings
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="component-messages.html" class="item">
                                    <div class="icon-box bg-primary">
                                        <ion-icon name="chatbubble-outline"></ion-icon>
                                    </div>
                                    <div class="in">
                                        Support
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

                        <!-- send money -->
                        <div class="listview-title mt-1">Send Money</div>
                        <ul class="listview image-listview flush transparent no-line">
                            <li>
                                <a href="#" class="item">
                                    <img src="assets/img/sample/avatar/avatar2.jpg" alt="image" class="image">
                                    <div class="in">
                                        <div>Artem Sazonov</div>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="#" class="item">
                                    <img src="assets/img/sample/avatar/avatar4.jpg" alt="image" class="image">
                                    <div class="in">
                                        <div>Sophie Asveld</div>
                                    </div>
                                </a>
                            </li>
                            <li>
                                <a href="#" class="item">
                                    <img src="assets/img/sample/avatar/avatar3.jpg" alt="image" class="image">
                                    <div class="in">
                                        <div>Kobus van de Vegte</div>
                                    </div>
                                </a>
                            </li>
                        </ul>
                        <!-- * send money -->

                    </div>
                </div>
            </div>
        </div>
    </form>
    <!-- * App Sidebar -->


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


<!-- Mirrored from finapp.bragherstudio.com/view3/component-listview.html by HTTrack Website Copier/3.x [XR&CO'2014], Mon, 26 Apr 2021 10:19:57 GMT -->
</html>
