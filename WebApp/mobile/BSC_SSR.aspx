<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BSC_SSR.aspx.cs" Inherits="WebApp.mobile.BSC_SSR" %>

<!doctype html>
<html lang="en">



<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport"
        content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, viewport-fit=cover" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
    <meta name="theme-color" content="#000000">
    <title>Navy-GEN - Service to Sales Ratio</title>
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

        <div class="pageTitle"><%= (string.IsNullOrWhiteSpace(Request.QueryString["Region"])?"Sales to Service Ratio ":"Sales to Service Ratio for Region "+Request.QueryString["Region"]+"") %></div>
        <div class="right">
        </div>
    </div>
    <!-- * App Header -->

    <!-- App Capsule -->
    <div id="appCapsule">
        <div class="section mt-2">
            <div class="section-title">Region   (AVG PMS 2021 : <asp:Label ID="pms2021" runat="server" />) (AVG PMS 2122 : <asp:Label ID="pms2122" runat="server" />) (PMS Gwt/DeGwth : <asp:Label ID="pmsgrowth" runat="server" />%)</div>
            <div class="card">
                <div class="card-body">
                    <ul class="nav nav-tabs style1" role="tablist">
                        <li class="nav-item">

                            <a href="BSC_SSR.aspx?Region=CENTRAL 1" class="nav-link active">Central 1
                            </a>
                        </li>
                        <li class="nav-item">
                            <a href="BSC_SSR.aspx?Region=CENTRAL 2" class="nav-link active">Central 2
                            </a>
                        </li>
                        <li class="nav-item">
                            <a href="BSC_SSR.aspx?Region=CENTRAL 3" class="nav-link active">Central 3
                            </a>
                        </li>
                    </ul>
                </div>
            </div>


            <div class="table-responsive">
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">Month</th>
                            <th scope="col">Base Data</th>
                            <th scope="col">Tgt 55</th>
                            <th scope="col">Tgt 45</th>
                            <th scope="col">Tgt 35</th>
                            <th scope="col">PMS Done</th>
                            <th scope="col">Bal 55</th>
                            <th scope="col">Bal 45</th>
                            <th scope="col">Bal 35</th>
                        </tr>
                    </thead>
                    <tbody class="thead-light">

                        <asp:Repeater runat="server" ID="SSRPerformance">
                            <ItemTemplate>
                                <tr>
                                    <th scope="row"><%# Eval("Month") %></th>
                                    <td><%# (int)System.Math.Ceiling((Convert.ToDecimal(Eval("Base_Data")))) %></td>
                                    <td><%# (int)System.Math.Ceiling(Convert.ToDecimal(Eval("TGT055"))) %></td>
                                    <td><%# (int)System.Math.Ceiling((Convert.ToDecimal(Eval("TGT045")))) %></td>
                                    <td><%# (int)System.Math.Ceiling((Convert.ToDecimal(Eval("TGT035")))) %></td>
                                    <td><%# (int)System.Math.Ceiling((Convert.ToDecimal(Eval("PMS_DONE")))) %></td>
                                    <td><%# (int)System.Math.Ceiling((Convert.ToDecimal(Eval("BAL055")))) %></td>
                                    <td><%# (int)System.Math.Ceiling((Convert.ToDecimal(Eval("BAL045")))) %></td>
                                    <td><%# (int)System.Math.Ceiling((Convert.ToDecimal(Eval("BAL035")))) %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <th scope="col">YTD</th>
                            <th scope="col">
                                <asp:Label ID="Base_Data" runat="server" /></th>
                            <th scope="col">
                                <asp:Label ID="TGT055" runat="server" /></th>
                            <th scope="col">
                                <asp:Label ID="TGT045" runat="server" /></th>
                            <th scope="col">
                                <asp:Label ID="TGT035" runat="server" /></th>
                            <th scope="col">
                                <asp:Label ID="PMS_DONE" runat="server" /></th>
                            <th scope="col">
                                <asp:Label ID="BAL055" runat="server" /></th>
                            <th scope="col">
                                <asp:Label ID="BAL045" runat="server" /></th>
                            <th scope="col" class="text-end">
                                <asp:Label ID="BAL035" runat="server" /></th>
                       </tr>
                    </tbody>
                </table>
            </div>

        </div>
    </div>

    <!-- * App Capsule -->

    <!-- App Bottom Menu -->
    <div class="appBottomMenu">
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
