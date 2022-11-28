<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="app-transaction-detail.aspx.cs" Inherits="WebApp.mobile.app_transaction_detail" %>

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
                <div>BKG No : - <asp:Literal runat="server" ID="Trans_Id"></asp:Literal>  </div>
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
                        <h5 class="m-0">
                            <asp:Literal runat="server" ID="Ledg_name"></asp:Literal>
                        </h5>
                    </li>
                    <li>
                      
                        <table>
                            <tr>
                                <td><strong style="padding-right:100px">Address</strong></td>
                                <td><h5><asp:Literal runat="server" ID="Address"></asp:Literal></h5></td>
                            </tr>

                        </table>
                       
                       
                    </li>
                    <li>
                        <strong>City</strong>
                        <h5 class="m-0">
                            <asp:Literal runat="server" ID="City"></asp:Literal></h5>
                    </li>
                    <li>
                        <strong>State</strong>
                        <h5 class="m-0">
                            <asp:Literal runat="server" ID="State"></asp:Literal></h5>
                    </li>
                    <li>
                        <strong>Mobile No</strong>
                        <h5 class="m-0">
                            <asp:Literal runat="server" ID="Mobile_No"></asp:Literal></h5>
                    </li>
                    <li>
                        <strong>Email Id</strong>
                        <h5 class="m-0">
                            <asp:Literal runat="server" ID="Email_Id"></asp:Literal></h5>
                    </li>
                    <li>
                        <strong>Customer Type</strong>
                        <h5 class="m-0">
                            <asp:Literal runat="server" ID="Customer_Type"></asp:Literal></h5>
                    </li>
                    <li>
                        <strong>Pin Code</strong>
                        <h5 class="m-0">
                            <asp:Literal runat="server" ID="Pin_Code"></asp:Literal></h5>
                    </li>
                    <li>
                        <strong>PAN No</strong>
                        <h5 class="m-0">
                            <asp:Literal runat="server" ID="Pan_No"></asp:Literal></h5>
                    </li>
                    <li>
                        <strong>GST NO</strong>
                        <h5 class="m-0">
                            <asp:Literal runat="server" ID="GST_NO"></asp:Literal></h5>
                    </li>
                </ul>
            </div>

        </div>
        <!-- * App Capsule -->

        <!-- App Bottom Menu -->
        <div class="appBottomMenu">
            <a href="app-Cost-detail.aspx?loc_code=<%= Request.QueryString["Loc_CD"] %>&&SOB_No=<%=  Request.QueryString["Loc_CD"] %>" class="item">
                <div class="col">
                    <ion-icon name="apps-outline"></ion-icon>
                    <h4 class="m-0">Cost</h4>
                </div>
            </a>
            <a href="app-Vehicle-detail.aspx?loc_code=<%= Request.QueryString["Loc_CD"] %>&&SOB_No=<%=  Request.QueryString["Loc_CD"] %>" class="item">
                <div class="col">
                    <ion-icon name="apps-outline"></ion-icon>
                    <h4 class="m-0">Vehicle</h4>
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
