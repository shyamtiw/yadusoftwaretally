<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ISL_Claim_Detail.aspx.cs" Inherits="WebApp.mobile.ISL_Claim_Detail" %>

<!doctype html>
<html lang="en">

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport"
        content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, viewport-fit=cover" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
    <meta name="theme-color" content="#000000">
    <title>Navy-GEN - ISL_RMK Claim Detail</title>
    <meta name="description" content="Finapp HTML Mobile Template">
    <meta name="keywords" content="bootstrap, wallet, banking, fintech mobile template, cordova, phonegap, mobile, html, responsive" />
    <link rel="icon" type="image/png" href="assets/img/favicon.png" sizes="32x32">
    <link rel="apple-touch-icon" sizes="180x180" href="assets/img/icon/192x192.png">
    <link rel="stylesheet" href="assets/css/style.css">
    <link rel="manifest" href="__manifest.json">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&display=swap" rel="stylesheet">
    <style>
        .table-primaryBlue, .table-primaryBlue > td, .table-primaryBlue > th {
            background-color: navy;
        }

        th, td {
            color: black;
        }
    </style>

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
        <div class="pageTitle"><%= (string.IsNullOrWhiteSpace(Request.QueryString["Region"])?"ISL Claim Summary ":"ISL Claim Summary for Region "+Request.QueryString["Region"]+"") %> <%= (string.IsNullOrWhiteSpace(Request.QueryString["dealercodeforcode"])?"":"("+Request.QueryString["dealercodeforcode"]+")") %></div>
        <div class="right">
        </div>
    </div>
    <!-- * App Header -->

    <!-- App Capsule -->
    <div id="appCapsule">
        <div class="section mt-2">
            <div class="section mt-1">
                <div class="card">
                    <div class="card-body">
                        <ul class="nav nav-tabs style1" role="tablist">
                            <asp:Repeater runat="server" ID="Repeater3">
                                <ItemTemplate>
                                    <li class="nav-item">
                                        <a href="<%# string.Concat("ISLRMK_Claim_Detail.aspx?Region=",Eval("Region")) %>" class="nav-link active"><strong><%# Eval("Region")  %> </strong></a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <div class="card">
            <div class="table-responsive">
                <table class="table">
                    <thead>
                        <tr class="table-primaryBlue">
                            <th scope="col" style="color: white;">Dealer Code</th>
                            <th scope="col" style="color: white;">Customer Name</th>
                            <th scope="col" style="color: white;">Invoice No</th>
                            <th scope="col" style="color: white;">Invoice Date</th>
                            <th scope="col" style="color: white;">Model</th>
                            <th scope="col" style="color: white;">VIN no</th>
                            <th scope="col" style="color: white;">Claim Amt</th>
                            <th scope="col" style="color: white;">Status</th>
                            <th scope="col" class="text-end" style="color: white;">Reason</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="ISLRMK_Claim_Detail">
                            <ItemTemplate>
                                <tr>
                                    <th scope="row"><%# Eval("DealerCodeForCode") %></th>
                                    <th scope="row"><%# Eval("NewCarOwnerDMS") %></th>
                                    <th scope="row"><%# Eval("NewCarInvoiceNo") %></th>
                                    <th scope="row"><%# Convert.ToDateTime( Eval("NewCarInvoiceDate")).ToString("dd/MM/yyyy")%></th>

                                    <th scope="row"><%# Eval("NewCarModel") %></th>
                                    <th scope="row"><a href="#" data-bs-toggle="modal" data-bs-target="#ISLRMKVINActionSheet"><strong><%# Eval("NewCarVin") %></strong></a></th>
                                    <td>
                                        <%#  Eval("MSILShare")%>

                                    </td>
                                    <th scope="row"><%# Eval("Status") %></th>
                                    <th scope="row"><%# Eval("Reason") %></th>

                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>

        </div>

    </div>

    <!-- * App Capsule -->
    <!-- Ref  Cost Detail Sheet -->
    <div class="modal fade action-sheet" id="ISLRMKVINActionSheet" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">ISL Claim Remark for VIN No :- <%# Eval("NewCarVin") %></h5>
                </div>
                <div class="modal-body">
                    <div class="action-sheet-content">
                        <form>
                            <div class="form-group basic">
                                <label class="label"><strong>Remarks By Process head</strong></label>
                                <div class="input-group mb-2">
                                    <span class="input-group-text" id="basic-addonb1"></span>
                                    <input type="text" class="form-control" placeholder="Enter Remarks"
                                        value="">
                                </div>
                            </div>
                            <div class="form-group basic">
                                <button type="button" class="btn btn-primary btn-block btn-lg"
                                    data-bs-dismiss="modal">
                                    Submit Remarks</button>

                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- * Ref Cost Detail Sheet -->
    <!-- App Bottom Menu -->
    <div class="appBottomMenu">
        <asp:Repeater runat="server" ID="Repeater1">
            <ItemTemplate>

                <a href="ISLRMK_Claim_Summary.aspx?Region=<%= Request.QueryString["Region"]  %>&&dealercodeforcode=<%# Eval("dealercodeforcode")  %>" class="item">
                    <div class="col">
                        <ion-icon name="pie-chart-outline"></ion-icon>
                        <h4 class="m-0"><%# Eval("dealercodeforcode")  %></h4>
                    </div>
                </a>
            </ItemTemplate>
        </asp:Repeater>


        <a href="ISLRMK_Claim_Summary.aspx" class="item">
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
