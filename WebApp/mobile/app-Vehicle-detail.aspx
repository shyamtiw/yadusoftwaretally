<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="app-Vehicle-detail.aspx.cs" Inherits="WebApp.mobile.app_Vehicle_detail" %>

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
             <div>Vehicle Detail</div>
                <div>BKG No : - <asp:Literal runat="server" ID="Trans_Id"></asp:Literal>  </div>
        </div>
        <div class="right">
            <a href="javascript:;" class="headerButton" data-bs-toggle="modal" data-bs-target="#DialogBasic">
                <ion-icon name="trash-outline"></ion-icon>
            </a>
        </div>
    </div>
    <!-- * App Header -->


    <!-- App Capsule -->
    <div id="appCapsule" class="full-height">

        <div class="section mt-2 mb-2">

            <ul class="listview flush transparent simple-listview no-space mt-3">
                <li>
                    <strong>Vehicle Group</strong>
                    <h4 class="m-0">
                        <asp:Literal runat="server" ID="Vehicle_Group"></asp:Literal></h4>
                </li>
                <li>
                    <strong>Variant Code</strong>
                    <h4 class="m-0">
                        <asp:Literal runat="server" ID="Variant_Code"></asp:Literal></h4>
                </li>
                <li>
                    <strong>Variant Name</strong>
                    <h4 class="m-0">
                        <asp:Literal runat="server" ID="Variant_Name"></asp:Literal></h4>
                </li>
                <li>
                    <strong>Color Code</strong>
                    <h4 class="m-0">
                        <asp:Literal runat="server" ID="Color_Code"></asp:Literal></h4>
                </li>
                <li>
                    <strong>Color Name</strong>
                    <h4 class="m-0">
                        <asp:Literal runat="server" ID="Color_Name"></asp:Literal></h4>
                </li>
                <li>
                        <strong>DSE Name</strong>
                    <h4 class="m-0">
                        <asp:Literal runat="server" ID="DMS_DSE"></asp:Literal></h4>
                </li>
                <li>
                    <strong>TL Name</strong>
                    <h4 class="m-0">
                        <asp:Literal runat="server" ID="DMS_TL"></asp:Literal></h4>
                </li>
            </ul>
        </div>

    </div>
    <!-- * App Capsule -->
    <!-- DSE TL Action Sheet -->
    <div class="modal fade action-sheet" id="DSETLActionSheet" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">DSE / TL Master</h5>
                </div>
                <div class="modal-body">
                    <div class="action-sheet-content">
                        <form>
                            <div class="form-group basic">
                                <div class="input-wrapper">
                                    <label class="label" for="account2d">DSE List</label>
                                    <select class="form-control custom-select" id="account2d">
                                        <option value="0">Vikas Yadav (10234)</option>
                                        <option value="1">Vikram Yadav (17987)</option>
                                        <option value="2">Narendra Arora (12304)</option>
                                    </select>
                                </div>
                            </div>
                            <div class="form-group basic">
                                <div class="input-wrapper">
                                    <label class="label" for="account2d">Team Leader List</label>
                                    <select class="form-control custom-select" id="account2d">
                                        <option value="0">Vikas Yadav (10234)</option>
                                        <option value="1">Vikram Yadav (17987)</option>
                                        <option value="2">Narendra Arora (12304)</option>
                                    </select>
                                </div>
                            </div>
                            <div class="form-group basic">
                                <button type="button" class="btn btn-primary btn-block btn-lg"
                                    data-bs-dismiss="modal">
                                    Submit</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- * DSE TL Action Sheet -->

  <!-- App Bottom Menu -->
        <div class="appBottomMenu">
             <a href="app-transaction-detail.aspx?BookingId=<%= WebApp.LIBS.SiteSession.SalesDataTable.Rows[0]["BookingId"].ToString() %>&&SOB_No=<%= Request.QueryString["Loc_CD"] %>" class="item">
                <div class="col">
                    <ion-icon name="pie-chart-outline"></ion-icon>
                    <h4 class="m-0">Customer Detail</h4>
                </div>
            </a>
             <a href="app-Cost-detail.aspx?loc_code=<%= Request.QueryString["Loc_CD"] %>&&SOB_No=<%=  Request.QueryString["Loc_CD"] %>" class="item">
                <div class="col">
                    <ion-icon name="apps-outline"></ion-icon>
                    <h4 class="m-0">Cost</h4>
                </div>
            </a>
            <a href="app-Discount_Approval.aspx<%= WebApp.LIBS.Common.ConvertInt(WebApp.LIBS.SiteSession.SalesDataTable.Rows[0]["BookingId"])>0?"?BookingId="+WebApp.LIBS.SiteSession.SalesDataTable.Rows[0]["BookingId"].ToString():"?BookingApprovalHistoryId="+WebApp.LIBS.SiteSession.SalesDataTable.Rows[0]["BookingApprovalHistoryId"].ToString() %>" class="item">
                <div class="col">
                    <ion-icon name="settings-outline"></ion-icon>
                    <h4 class="m-0">Approval</h4>
                </div>
            </a>
             <a href="<%= WebApp.LIBS.SiteSession.DesignationId >= 22 ? "Approver_Dashbaord.aspx" : "Booking_Dashbaord.aspx" %>" class="item">
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
