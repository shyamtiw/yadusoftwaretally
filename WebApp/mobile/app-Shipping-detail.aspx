<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="app-Shipping-detail.aspx.cs" Inherits="WebApp.mobile.app_Shipping_detail" %>

<!doctype html>
<html lang="en">



<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport"
        content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, viewport-fit=cover" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
    <meta name="theme-color" content="#000000">
    <title>Navy-GEN - Pre Sales Module</title>
    <meta name="description" content="Finapp HTML Mobile Template">
    <meta name="keywords" content="bootstrap, wallet, banking, fintech mobile template, cordova, phonegap, mobile, html, responsive" />
    <link rel="icon" type="image/png" href="assets/img/favicon.png" sizes="32x32">
    <link rel="apple-touch-icon" sizes="180x180" href="assets/img/icon/192x192.png">
    <link rel="stylesheet" href="assets/css/style.css">
    <link rel="manifest" href="__manifest.json">
</head>

<body class="bg-white">

    <!-- loader -->
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
          <div>Shipping Detail</div>
                <div>BKG No : - <asp:Literal runat="server" ID="Trans_Id"></asp:Literal>  </div>
        </div>
        <div class="right">
            <a href="javascript:;" class="headerButton" data-bs-toggle="modal" data-bs-target="#DialogBasic">
                <ion-icon name="trash-outline"></ion-icon>
            </a>
        </div>
    </div>
    <!-- * App Header -->

    <!-- Dialog Basic -->
    <div class="modal fade dialogbox" id="DialogBasic" data-bs-backdrop="static" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Delete</h5>
                </div>
                <div class="modal-body">
                    Are you sure?
                </div>
                <div class="modal-footer">
                    <div class="btn-inline">
                        <a href="#" class="btn btn-text-secondary" data-bs-dismiss="modal">CANCEL</a>
                        <a href="#" class="btn btn-text-primary" data-bs-dismiss="modal">DELETE</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- * Dialog Basic -->

    <!-- App Capsule -->
    <div id="appCapsule" class="full-height">

        <div class="section mt-2 mb-2">

            <ul class="listview flush transparent simple-listview no-space mt-3">
                <li>
                    <strong>Customer Name</strong>
                    <h3 class="m-0"><asp:Literal runat="server" ID="Ship_Customer_Name"></asp:Literal></h3>
                </li>
				<li>
                    <strong>Address</strong>
                    <h3 class="m-0"><asp:Literal runat="server" ID="Ship_Address"></asp:Literal></h3>
                </li>
				<li>
                    <strong>City</strong>
                    <h3 class="m-0"><asp:Literal runat="server" ID="Ship_City"></asp:Literal></h3>
                </li>
				<li>
                    <strong>State</strong>
                    <h3 class="m-0"><asp:Literal runat="server" ID="Ship_State"></asp:Literal></h3>
                </li>
				<li>
                    <strong>PIN Code</strong>
                    <h3 class="m-0"><asp:Literal runat="server" ID="Ship_Pincode"></asp:Literal></h3>
                </li>
                <li>
                    <strong>GST No</strong>
                    <h3 class="m-0"><asp:Literal runat="server" ID="Ship_GST_NUM"></asp:Literal></h3>
                </li>
				<li>
                    <strong>Pan No</strong>
                    <h3 class="m-0"><asp:Literal runat="server" ID="Ship_PAN"></asp:Literal></h3>
                </li>
			
				<li>
                    <strong>PAN No</strong>
                    <h3 class="m-0"><asp:Literal runat="server" ID="Ship_Panno"></asp:Literal></h3>
                </li>
				<li>
                    <strong>GST NO</strong>
                    <h3 class="m-0"><asp:Literal runat="server" ID="Ship_GSTno"></asp:Literal></h3>
                </li>
            </ul>


        </div>

    </div>
    <!-- * App Capsule -->


   <!-- App Bottom Menu -->
    <div class="appBottomMenu">
        <a href="app-transaction-detail.aspx" class="item">
            <div class="col">
                <ion-icon name="pie-chart-outline"></ion-icon>
				<h4 class="m-0">Customer Detail</h4>
            </div>
        </a>
        <a href="app-Financer-detail.aspx" class="item">
            <div class="col">
                <ion-icon name="document-text-outline"></ion-icon>
				<h4 class="m-0">Finance</h4>
            </div>
        </a>
        <a href="app-Vehicle-detail.aspx" class="item">
            <div class="col">
                <ion-icon name="apps-outline"></ion-icon>
				<h4 class="m-0">Vehicle</h4>
            </div>
        </a>
        <a href="app-Cost-detail.aspx" class="item">
            <div class="col">
                <ion-icon name="card-outline"></ion-icon>
				<h4 class="m-0">Costing</h4>
            </div>
        </a>
        <a href="app-Exchange-detail.aspx" class="item">
            <div class="col">
                <ion-icon name="settings-outline"></ion-icon>
				<h4 class="m-0">Exchange</h4>
            </div>
        </a>
		 <a href="app-Shipping-detail.aspx" class="item">
            <div class="col">
                <ion-icon name="settings-outline"></ion-icon>
                <h4 class="m-0">Shipping</h4>
            </div>
        </a>
		 <a href="app-Discount_Approval.aspx" class="item">
            <div class="col">
                <ion-icon name="settings-outline"></ion-icon>
				<h4 class="m-0">Approval</h4>
            </div>
        </a>
		 <a href="index.aspx" class="item">
            <div class="col">
                <ion-icon name="pie-chart-outline"></ion-icon>
				<h4 class="m-0">Home</h4>
            </div>
        </a>
    </div>


    <!-- * App Bottom Menu -->

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
