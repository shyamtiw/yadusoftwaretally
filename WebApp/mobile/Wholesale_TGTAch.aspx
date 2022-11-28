<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Wholesale_TGTAch.aspx.cs" Inherits="WebApp.mobile.Wholesale_TGTAch" %>

<!doctype html>
<html lang="en">



<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport"
        content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, viewport-fit=cover" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
    <meta name="theme-color" content="#000000">
    <title>Navy-GEN - Wholesale Target Vs Achievement</title>
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
        <div class="pageTitle">Wholesale Tgt Vs Ach (21-22)</div>
        <div class="right">
        </div>
    </div>
    <!-- * App Header -->

    <!-- App Capsule -->
    <div id="appCapsule">
      <div class="section mt-2">
             <div class="section-title">Region</div>
             <div class="card">
                <div class="card-body pb-1">
                    <!-- do not forget to delete me-1 and mb-1 when copy / paste codes -->
                    <button type="button" class="btn btn-primary me-1 mb-1">CENTRAL 1</button>
                    <button type="button" class="btn btn-secondary me-1 mb-1">CENTRAL 2</button>
                    <button type="button" class="btn btn-danger me-1 mb-1">CENTRAL 3</button>
                </div>
                  </div>

                  <asp:Repeater runat="server" ID="WSPerformance">
                    <ItemTemplate>
                        <div class="col-md-6" style="padding-bottom:5px!important">
                        <a href="Wholesale_Performance.aspx" class="item">
                             <div class="stat-box">
                                 <p>Data Capturing : <%# Eval("Dealer_Code") %></p>
                            </div>
                        </a>
                       </div>
                    </ItemTemplate>
                  </asp:Repeater>

                <div class="table-responsive">
                    <table class="table">
                        <thead>
                            <tr class="table-primary">
                                <th scope="col">Month</th>
                                <th scope="col">Tgt</th>
                                <th scope="col">Ach</th>
                                <th scope="col">Bal</th>
                                <th scope="col" class="text-end">%age Ach.</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <th scope="row">Apr</th>
                                <td>1000</td>
                                <td>1026</td>
                                <td>-26</td>
                               <td class="text-end text-primary">103%</td>

                            </tr>
                            <tr>
                                <th scope="row">May</th>
                                  <td>0</td>
                                <td>0</td>
                                <td>0</td>
                               <td class="text-end text-primary">0%</td>
                            </tr>
                            <tr>
                                <th scope="row">Jun</th>
                                 <td>0</td>
                                <td>0</td>
                                <td>0</td>
                               <td class="text-end text-primary">0%</td>
                            </tr>
                             <tr class="table-danger">
                                <th scope="row">Qtr1</th>
                                  <td>1000</td>
                                <td>1026</td>
                                <td>-26</td>
                               <td class="text-end text-primary">103%</td>
                            </tr>
                            <tr>
                                <th scope="row">Jul</th>
                                  <td>0</td>
                                <td>0</td>
                                <td>0</td>
                               <td class="text-end text-primary">0%</td>
                            </tr>
                            <tr>
                                <th scope="row">Aug</th>
                                 <td>0</td>
                                <td>0</td>
                                <td>0</td>
                               <td class="text-end text-primary">0%</td>
                            </tr>
                            <tr>
                                <th scope="row">Sep</th>
                                 <td>0</td>
                                <td>0</td>
                                <td>0</td>
                               <td class="text-end text-primary">0%</td>
                            </tr>
                             <tr class="table-danger">
                                <th scope="row">Qtr2</th>
                                  <td>0</td>
                                <td>0</td>
                                <td>0</td>
                               <td class="text-end text-primary">0%</td>
                            </tr>
                            <tr>
                                <th scope="row">Oct</th>
                                  <td>0</td>
                                <td>0</td>
                                <td>0</td>
                               <td class="text-end text-primary">0%</td>
                            </tr>
                            <tr>
                                <th scope="row">Nov</th>
                                 <td>0</td>
                                <td>0</td>
                                <td>0</td>
                               <td class="text-end text-primary">0%</td>
                            </tr>
                            <tr>
                                <th scope="row">Dec</th>
                                  <td>0</td>
                                <td>0</td>
                                <td>0</td>
                               <td class="text-end text-primary">0%</td>
                            </tr>
                             <tr class="table-danger">
                                <th scope="row">Qtr3</th>
                                  <td>0</td>
                                <td>0</td>
                                <td>0</td>
                               <td class="text-end text-primary">0%</td>
                            </tr>
                            <tr>
                                <th scope="row">Jan</th>
                                 <td>0</td>
                                <td>0</td>
                                <td>0</td>
                               <td class="text-end text-primary">0%</td>
                            </tr>
                            <tr>
                                <th scope="row">Feb</th>
                                  <td>0</td>
                                <td>0</td>
                                <td>0</td>
                               <td class="text-end text-primary">0%</td>
                            </tr>
                            <tr>
                                <th scope="row">Mar</th>
                                <td>0</td>
                                <td>0</td>
                                <td>0</td>
                               <td class="text-end text-primary">0%</td>
                            </tr>
                            <tr class="table-danger">
                                <th scope="row">Qtr4</th>
                                 <td>0</td>
                                <td>0</td>
                                <td>0</td>
                               <td class="text-end text-primary">0%</td>
                            </tr>

                             <tr class="table-info">
                                <th scope="row">YTD</th>
                                 <td>0</td>
                                <td>0</td>
                                <td>0</td>
                               <td class="text-end text-primary">0%</td>
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
        <a href="Wholesale_Performance.aspx?Region=CENTRAL 1" class="item">
            <div class="col">
                <ion-icon name="pie-chart-outline"></ion-icon>
				<h4 class="m-0">Wholesale Performance</h4>
            </div>
        </a>
        <a href="Wholesale_TGTAch.aspx" class="item">
            <div class="col">
                <ion-icon name="document-text-outline"></ion-icon>
				<h4 class="m-0">Wholesale Tgt Vs Achievement</h4>
            </div>
        </a>
         <a href="BSC_NSC_Parameter_Page.aspx" class="item">
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