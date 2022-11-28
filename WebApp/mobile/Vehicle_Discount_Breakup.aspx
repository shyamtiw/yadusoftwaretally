<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vehicle_Discount_Breakup.aspx.cs" Inherits="WebApp.mobile.Vehicle_Discount_Breakup" %>

<!doctype html>
<html lang="en">



<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport"
        content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, viewport-fit=cover" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
    <meta name="theme-color" content="#000000">
    <title>Navy-GEN - Vehicle Discount Breakup</title>
    <meta name="description" content="Finapp HTML Mobile Template">
    <meta name="keywords" content="bootstrap, wallet, banking, fintech mobile template, cordova, phonegap, mobile, html, responsive" />
    <link rel="icon" type="image/png" href="assets/img/favicon.png" sizes="32x32">
    <link rel="apple-touch-icon" sizes="180x180" href="assets/img/icon/192x192.png">
    <link rel="stylesheet" href="assets/css/style.css">
    <link rel="manifest" href="__manifest.json">
</head>

<body class="bg-white">

    <!-- loader -->

    <form runat="server" id="dsadsad">
        <div id="loader">
            <img src="assets/img/logo-icon.png" alt="icon" class="loading-icon">
        </div>
        <!-- * loader -->

        <!-- App Header -->
        <div class="appHeader">
            <div class="left">
                <a href="#" class="headerButton goBack">
                    <ion-icon name="chevron-back-outline"></ion-icon>
                </a>
            </div>
            <div class="pageTitle">
                <div>Customer Transaction </div>
                <div>Invoice No : -  <%=Request.QueryString["InvNo"] %>  </div>
            </div>
        </div>

        <!-- * App Header -->

        <!-- App Capsule -->
        <div id="appCapsule" class="full-height">

            <div class="section mt-2 mb-2">

                <ul class="listview flush transparent simple-listview no-space mt-3">
                    <li>
                        <strong>Dealer Location</strong>
                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="Locationcode"></asp:Literal>
                        </h3>
                    </li>
                    <li>
                        <strong>Customer Name</strong>
                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="Ledg_name"></asp:Literal>
                        </h3>
                    </li>
                    <li>
                        <strong>Invoice No</strong>
                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="InvNo"></asp:Literal></h3>
                    </li>
                    <li>
                        <strong>Invoice Date</strong>
                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="InvDt"></asp:Literal></h3>
                    </li>
                    <li>
                        <strong>DSE</strong>
                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="DSE"></asp:Literal></h3>
                    </li>
                     <li>
                        <strong>Variant Name</strong>
                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="variantdesc"></asp:Literal></h3>
                    </li>
                    <li>
                        <strong>COnsumer Offer Given</strong>
                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="offer_given"></asp:Literal></h3>
                    </li>
                    <li>
                        <strong>MSIL Consumer offer</strong>
                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="msilconsoffer"></asp:Literal></h3>
                    </li>
                    <li>
                        <strong>MSIL Rips 1</strong>
                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="msilrips1"></asp:Literal></h3>
                    </li>
                    <li>
                        <strong>Msil Rips 2</strong>
                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="msilrips2"></asp:Literal></h3>
                    </li>
                    <li>
                        <strong>Msil Rips 3</strong>
                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="msilrips3"></asp:Literal></h3>
                    </li>
                    <li>
                        <strong>MSSF Offer</strong>
                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="mssfoffer"></asp:Literal></h3>
                    </li>
                    <li>
                        <strong>CSD Price Difference</strong>
                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="CSD_PRICE_DIFFERENCE"></asp:Literal></h3>
                    </li>
                    <li>
                        <strong>Post Sales Discount</strong>
                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="Post_Sale_Discount"></asp:Literal></h3>
                    </li>
                    <li>
                        <strong>Offer Difference</strong>
                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="offerdifference"></asp:Literal></h3>
                    </li>
                    <li>
                        <strong>Mi Date</strong>
                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="midate"></asp:Literal></h3>
                    </li>
                </ul>
            </div>

        </div>
        <!-- * App Capsule -->
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
