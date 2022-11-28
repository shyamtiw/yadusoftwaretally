<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Part_Performance.aspx.cs" Inherits="WebApp.mobile.Part_Performance" %>

<!doctype html>
<html lang="en">



<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport"
        content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, viewport-fit=cover" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
    <meta name="theme-color" content="#000000">
    <title>Navy-GEN - Part Performance</title>
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

        <div class="pageTitle"><%= (string.IsNullOrWhiteSpace(Request.QueryString["Region"])?"Service Part Performance":"Service Part Performance "+Request.QueryString["Region"]+"") %> Location :-  <%= (string.IsNullOrWhiteSpace(Request.QueryString["DealerCode"])?"":"("+Request.QueryString["DealerCode"]+")") %></div>
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
                            <a href="Part_Performance.aspx?Region=CENTRAL 2" class="nav-link active">Central 2
                            </a>
                        </li>
                        <li class="nav-item">
                            <a href="Part_Performance.aspx?Region=CENTRAL 3" class="nav-link active">Central 3
                            </a>
                        </li>
                        <li class="nav-item">
                            <div class="dropdown">
                                <button class="btn btn-primary dropdown-toggle" type="button" data-bs-toggle="dropdown">
                                    Servie Type
                       
                                </button>
                                <div class="dropdown-menu">
                                    <a href="Part_Performance.aspx?Region=CENTRAL 2&&SerType=FREE" class="nav-link active">Free</a>
                                    <a href="Part_Performance.aspx?Region=CENTRAL 2&&SerType=PAID" class="nav-link active">Paid</a>
                                    <a href="Part_Performance.aspx?Region=CENTRAL 2&&SerType=RUNING" class="nav-link active">Running</a>
                                    <a href="Part_Performance.aspx?Region=CENTRAL 2&&SerType=OTHER" class="nav-link active">Other</a>
                                    <div class="dropdown-divider"></div>
                                    <a href="Part_Performance.aspx?Region=CENTRAL 2&&SerType=BANDP" class="nav-link active">Bodyshop</a>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>


            <div class="table-responsive">
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">Month</th>
                            <th scope="col">1920</th>
                            <th scope="col">2021</th>
                            <th scope="col">2122</th>
                            <th scope="col">2122 On 1920</th>
                            <th scope="col">2122 On 2021</th>
                            <th scope="col">2021 On 1920</th>
                            <th scope="col">2122 Per veh</th>
                            <th scope="col">2021 Per veh</th>
                            <th scope="col">1920 Per veh</th>
                        </tr>
                    </thead>
                    <tbody class="thead-light">

                        <asp:Repeater runat="server" ID="ServicePerformance">
                            <ItemTemplate>
                                <tr>
                                    <th scope="row"><%# Eval("Month") %></th>
                                    <td><%# (int)System.Math.Ceiling((Convert.ToDecimal(Eval("PART1920")))) %></td>
                                    <td><%# (int)System.Math.Ceiling(Convert.ToDecimal(Eval("PART2021"))) %></td>
                                    <td><%# (int)System.Math.Ceiling((Convert.ToDecimal(Eval("PART2122")))) %></td>
                                    <td><%# (decimal)System.Math.Ceiling(((Convert.ToDecimal(Eval("PART2122"))-Convert.ToDecimal(Eval("PART1920")))/(Convert.ToDecimal(Eval("PART1920"))>0?Convert.ToDecimal(Eval("PART1920")):1))*100) %>%</td>
                                    <td><%# (decimal)System.Math.Ceiling(((Convert.ToDecimal(Eval("PART2122"))-Convert.ToDecimal(Eval("PART2021")))/(Convert.ToDecimal(Eval("PART2021"))>0?Convert.ToDecimal(Eval("PART2021")):1))*100) %>%</td>
                                    <td><%# (decimal)System.Math.Ceiling(((Convert.ToDecimal(Eval("PART2021"))-Convert.ToDecimal(Eval("PART1920")))/(Convert.ToDecimal(Eval("PART1920"))>0?Convert.ToDecimal(Eval("PART1920")):1))*100) %>%</td>
                                    <td><%# (decimal)System.Math.Ceiling((Convert.ToDecimal(Eval("PART2122"))/(Convert.ToDecimal(Eval("Load2122"))>0?Convert.ToDecimal(Eval("Load2122")):1))) %></td>
                                    <td><%# (decimal)System.Math.Ceiling((Convert.ToDecimal(Eval("PART2021"))/(Convert.ToDecimal(Eval("Load2021"))>0?Convert.ToDecimal(Eval("Load2021")):1))) %></td>
                                    <td><%# (decimal)System.Math.Ceiling((Convert.ToDecimal(Eval("PART1920"))/(Convert.ToDecimal(Eval("Load1920"))>0?Convert.ToDecimal(Eval("Load1920")):1))) %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <th scope="col">YTD</th>
                            <th scope="col">
                                <asp:Label ID="Load1920" runat="server" /></th>
                            <th scope="col">
                                <asp:Label ID="Load2021" runat="server" /></th>
                            <th scope="col">
                                <asp:Label ID="Load2122" runat="server" /></th>
                            <th scope="col">
                                <asp:Label ID="Growth2122Over1920" runat="server" />%</th>
                            <th scope="col">
                                <asp:Label ID="Growth2122Over2021" runat="server" />%</th>
                            <th scope="col">
                                <asp:Label ID="Growth2021Over1920" runat="server" />%</th>
                            <th scope="col">
                                <asp:Label ID="Perveh21" runat="server" /></th>
                            <th scope="col">
                                <asp:Label ID="Perveh20" runat="server" /></th>
                            <th scope="col">
                                <asp:Label ID="Perveh19" runat="server" /></th>
                        </tr>
                    </tbody>
                </table>
            </div>

        </div>
    </div>

    <!-- * App Capsule -->

    <!-- App Bottom Menu -->
    <div class="appBottomMenu">

        <asp:Repeater runat="server" ID="Repeater1">
            <ItemTemplate>
                <a href="Part_Performance.aspx?Region=<%= Request.QueryString["Region"]  %>&&DealerCode=<%# Eval("Locationcode")  %>" class="item">
                    <div class="col">
                        <ion-icon name="pie-chart-outline"></ion-icon>
                        <h4 class="m-0"><%# Eval("Locationcode")  %></h4>
                    </div>
                </a>
            </ItemTemplate>
        </asp:Repeater>

         <a href="Service_performance.aspx" class="item">
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
