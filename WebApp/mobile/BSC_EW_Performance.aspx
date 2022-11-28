<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BSC_EW_Performance.aspx.cs" Inherits="WebApp.mobile.BSC_EW_Performance" %>

<!doctype html>
<html lang="en">



<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport"
        content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, viewport-fit=cover" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
    <meta name="theme-color" content="#000000">
    <title>Navy-GEN - Wholesale Performance</title>
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
        <div class="pageTitle"><%= (string.IsNullOrWhiteSpace(Request.QueryString["Region"])?"Extended Warranty Performance ":"Extended Warranty Performance for Region "+Request.QueryString["Region"]+"") %></div>
        <div class="right">
        </div>
    </div>
    <!-- * App Header -->

    <!-- App Capsule -->
    <div id="appCapsule">
        <div class="section mt-2">
            <div class="section-title">Region</div>
            <div class="card">
                <div class="card-body">
                    <ul class="nav nav-tabs style1" role="tablist">
                        <li class="nav-item">

                            <a href="BSC_EW_Performance.aspx?Region=CENTRAL 1" class="nav-link active">Central 1
                            </a>
                        </li>
                        <li class="nav-item">
                            <a href="BSC_EW_Performance.aspx?Region=CENTRAL 2" class="nav-link active">Central 2
                            </a>
                        </li>
                        <li class="nav-item">
                            <a href="BSC_EW_Performance.aspx?Region=CENTRAL 3" class="nav-link active">Central 3
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
                            <th scope="col">Retail</th>
                            <th scope="col">WKS EW Tgt</th>
                            <th scope="col">WKS EW Ach</th>
                            <th scope="col">WKS EW Bal</th>
                            <th scope="col">%Ach</th>
                            <th scope="col">Access 70% </th>
                            <th scope="col">80% EW Pen</th>

                        </tr>
                    </thead>
                    <tbody class="thead-light">

                        <asp:Repeater runat="server" ID="EWWKSPerformance">
                            <ItemTemplate>
                                <tr>
                                    <th scope="row"><%# Eval("Tran_month") %></th>
                                    <td><%# (int)System.Math.Ceiling((Convert.ToDecimal(Eval("Region_Retail")))) %></td>
                                    <td><%# (int)System.Math.Ceiling(Convert.ToDecimal(Eval("Region_Retail"))*0.06m) %></td>
                                    <td><%# (int)System.Math.Ceiling((Convert.ToDecimal(Eval("EWWKS")))) %></td>
                                    <td><%# (int)System.Math.Ceiling(((Convert.ToDecimal(Eval("Region_Retail"))*0.06m)-Convert.ToDecimal(Eval("EWWKS")))) %></td>
                                    <td><%# (double)System.Math.Ceiling(Convert.ToDecimal(Eval("EWWKS"))*100m/(Convert.ToDecimal(Eval("Region_Retail"))*0.06m)) %>%</td>
                                    <td><%# (int)System.Math.Ceiling(Convert.ToDecimal(Eval("EW70PERC"))/Convert.ToDecimal(Eval("Region_Retail"))*100m) %>%</td>
                                    <td><%# (int)System.Math.Ceiling(Convert.ToDecimal(Eval("EW80PERC"))/Convert.ToDecimal(Eval("Region_Retail"))*100m) %>%</td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <th scope="col">YTD</th>
                            <th scope="col">
                                <asp:Label ID="Base2021" runat="server" /></th>
                            <th scope="col">
                                <asp:Label ID="Tgt2122" runat="server" /></th>
                            <th scope="col">
                                <asp:Label ID="Achieved" runat="server" /></th>
                            <th scope="col">
                                <asp:Label ID="Balance" runat="server" /></th>
                            <th scope="col">
                                <asp:Label ID="ageAch" runat="server" />%</th>
                            <th scope="col">
                                <asp:Label ID="EW70PERC" runat="server" />%</th>
                            <th scope="col" class="text-end">
                                <asp:Label ID="EW80PERC" runat="server" />%</th>
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
