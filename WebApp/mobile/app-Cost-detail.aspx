<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="app-Cost-detail.aspx.cs" Inherits="WebApp.mobile.app_Cost_detail" %>

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
    <form id="dsa" runat="server">
        <asp:ScriptManager runat="server" ID="sd" EnablePageMethods="true"></asp:ScriptManager>

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
                <div>Cost Detail</div>
                <div>
                    BKG No : -
                <asp:Literal runat="server" ID="Trans_Id"></asp:Literal>
                </div>
            </div>
        </div>
        <!-- * App Header -->


        <!-- App Capsule -->
        <div id="appCapsule" class="full-height">
            <SG:MessageMobile runat="server" ID="Message"></SG:MessageMobile>
            <div class="section mt-2 mb-2">

                <ul class="listview flush transparent simple-listview no-space mt-3">
                    <li>
                        <a href="#" data-bs-toggle="modal" data-bs-target="#InsurancActionSheet">
                            <strong>Insurance Type  </strong>
                        </a>
                        <h4 class="m-0">
                            <asp:Literal runat="server" ID="Insu_Typex"></asp:Literal>
                        </h4>
                         <h4 class="m-0">
                            <asp:Literal runat="server" ID="InsuCompName"></asp:Literal></h4>
                        <h4 class="m-0">
                            <asp:Literal runat="server" ID="Insu_Amt"></asp:Literal></h4>
                       
                    </li>

                    <li>
                        <a href="#" data-bs-toggle="modal" data-bs-target="#EWActionSheet">
                            <strong>Extended Warranty</strong>
                        </a>
                        <h4 class="m-0">
                            <asp:Literal runat="server" ID="EW_Type"></asp:Literal></h4>
                        <h4 class="m-0">
                            <asp:Literal runat="server" ID="EW_Amt"></asp:Literal></h4>
                    </li>
                    <li>
                        <a href="#" data-bs-toggle="modal" data-bs-target="#RTOActionSheet">
                            <strong>Road Tax</strong>
                        </a>
                        <h4 class="m-0">
                            <asp:Literal runat="server" ID="RTO_Type"></asp:Literal></h4>
                        <h4 class="m-0">
                            <asp:Literal runat="server" ID="RTO_Amt"></asp:Literal></h4>
                    </li>
                    <li>
                        <a href="#" data-bs-toggle="modal" data-bs-target="#MSGASalesActionSheet">
                            <strong>MSGA/GNA</strong>
                        </a>
                        <h4 class="m-0">
                            <asp:Literal runat="server" ID="MSGA_AMT"></asp:Literal></h4>
                    </li>
                    <li>
                        <a href="#" data-bs-toggle="modal" data-bs-target="#MSRActionSheet">
                            <strong>Maruti Suzuki Reward</strong>
                        </a>
                        <h4 class="m-0">
                            <asp:Literal runat="server" ID="MSR_AMT"></asp:Literal></h4>
                    </li>
                    <li>
                        <a href="#" data-bs-toggle="modal" data-bs-target="#FastagActionSheet">
                            <strong>Fasttag </strong>
                        </a>
                        <h4 class="m-0">
                            <asp:Literal runat="server" ID="FasTag_Amt"></asp:Literal></h4>
                    </li>
                </ul>


            </div>

        </div>
        <!-- * App Capsule -->

        <!-- offer Action Sheet -->
        <div class="modal fade action-sheet" id="offerActionSheet" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Discount Breakup</h5>
                    </div>
                    <div class="modal-body">
                        <div class="action-sheet-content">

                            <div class="form-group basic">
                                <label class="label"><strong>Consumer Offer</strong></label>
                                <div class="input-group mb-2">
                                    <span class="input-group-text" id="basic-addonb1">Rs.</span>
                                    <input type="text" class="form-control" placeholder="Enter an amount"
                                        value="0">
                                </div>
                            </div>
                            <div class="form-group basic">
                                <label class="label"><strong>RIPS Support 1</strong></label>
                                <div class="input-group mb-2">
                                    <span class="input-group-text" id="basic-addonb1">Rs.</span>
                                    <input type="text" class="form-control" placeholder="Enter an amount"
                                        value="0">
                                </div>
                            </div>
                            <div class="form-group basic">
                                <label class="label"><strong>RIPS Support 2</strong></label>
                                <div class="input-group mb-2">
                                    <span class="input-group-text" id="basic-addonb1">Rs.</span>
                                    <input type="text" class="form-control" placeholder="Enter an amount"
                                        value="0">
                                </div>
                            </div>
                            <div class="form-group basic">
                                <label class="label"><strong>RIPS Support 3</strong></label>
                                <div class="input-group mb-2">
                                    <span class="input-group-text" id="basic-addonb1">Rs.</span>
                                    <input type="text" class="form-control" placeholder="Enter an amount"
                                        value="0">
                                </div>
                            </div>
                            <div class="form-group basic">
                                <label class="label"><strong>MSSF Offer</strong></label>
                                <div class="input-group mb-2">
                                    <span class="input-group-text" id="basic-addonb1">Rs.</span>
                                    <input type="text" class="form-control" placeholder="Enter an amount"
                                        value="0">
                                </div>
                            </div>
                            <div class="form-group basic">
                                <label class="label"><strong>MDS Offer</strong></label>
                                <div class="input-group mb-2">
                                    <span class="input-group-text" id="basic-addonb1">Rs.</span>
                                    <input type="text" class="form-control" placeholder="Enter an amount"
                                        value="0">
                                </div>
                            </div>
                            <div class="form-group basic">
                                <label class="label"><strong>Buffer Offer</strong></label>
                                <div class="input-group mb-2">
                                    <span class="input-group-text" id="basic-addonb1">Rs.</span>
                                    <input type="text" class="form-control" placeholder="Enter an amount"
                                        value="0">
                                </div>
                            </div>
                            <div class="form-group basic">
                                <label class="label"><strong>Maruti Employee Offer</strong></label>
                                <div class="input-group mb-2">
                                    <span class="input-group-text" id="basic-addonb1">Rs.</span>
                                    <input type="text" class="form-control" placeholder="Enter an amount"
                                        value="0">
                                </div>
                            </div>
                            <div class="form-group basic">
                                <label class="label"><strong>Additiona Discount</strong></label>
                                <div class="input-group mb-2">
                                    <span class="input-group-text" id="basic-addonb1">Rs.</span>
                                    <input type="text" class="form-control" placeholder="Enter an amount"
                                        value="0">
                                </div>
                            </div>
                            <div class="form-group basic">
                                <button type="button" class="btn btn-primary btn-block btn-lg"
                                    data-bs-dismiss="modal">
                                    Submit Breakup</button>
                            </div>


                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- * Offer Action Sheet -->

        <!-- Post Sales Discount Sheet -->
        <div class="modal fade action-sheet" id="PostSalesActionSheet" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Post Sales Discount</h5>
                    </div>
                    <div class="modal-body">
                        <div class="action-sheet-content">

                            <div class="form-group basic">
                                <label class="label"><strong>Post Sales Discount Amt</strong></label>
                                <div class="input-group mb-2">
                                    <span class="input-group-text" id="basic-addonb1">Rs.</span>
                                    <input type="text" class="form-control" placeholder="Enter an amount"
                                        value="0">
                                </div>
                                <div class="form-group basic">
                                    <button type="button" class="btn btn-primary btn-block btn-lg"
                                        data-bs-dismiss="modal">
                                        Submit Breakup</button>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- * Post Sales Discount Sheet -->

        <!-- Insurance  Breakup Sheet -->
        <div class="modal fade action-sheet" id="InsurancActionSheet" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Insurance Breakup</h5>
                    </div>
                    <div class="modal-body">
                        <div class="action-sheet-content">

                            <div class="form-group basic">
                                <div class="input-wrapper">
                                    <label class="label" for="account2d">Insurance Type</label>
                                    <asp:DropDownList runat="server" ID="ddlInsu_type" CssClass="form-control custom-select">
                                    </asp:DropDownList>
                                </div>
                            </div>
                              <div class="form-group basic">
                                <div class="input-wrapper">
                                    <label class="label" for="account2d">Insurance Compnay Name</label>
                                    <asp:DropDownList runat="server" ID="ddlInsuCompName" CssClass="form-control custom-select">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group basic">
                                <label class="label"><strong>Insurance Amt</strong></label>
                                <div class="input-group mb-2">
                                    <span class="input-group-text" id="basicdddaddonb1s">Rs.</span>

                                    <asp:TextBox runat="server" ID="TXTInsu_Amt" CssClass="form-control" placeholder="Enter an amount"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group basic">
                                <asp:LinkButton runat="server" ID="btnInsurancActionSheet" class="btn btn-primary btn-block btn-lg"
                                    OnClick="btnInsurancActionSheet_Click"> Submit Breakup</asp:LinkButton>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- * Insurance  Breakup Sheet -->

        <!-- Extended Warranty  Breakup Sheet -->
        <div class="modal fade action-sheet" id="EWActionSheet" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Extended Warranty Breakup</h5>
                    </div>
                    <div class="modal-body">
                        <div class="action-sheet-content">
                            <div class="form-group basic">
                                <div class="input-wrapper">
                                    <label class="label" for="account2d">Extended Warranty Type</label>
                                    <asp:DropDownList runat="server" ID="ddlEW_Type" CssClass="form-control custom-select">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group basic">
                                <label class="label"><strong>Extended Warranty Amt</strong></label>
                                <div class="input-group mb-2">
                                    <span class="input-group-text">Rs.</span>
                                    <asp:TextBox runat="server" ID="TxtEW_Amt" CssClass="form-control" placeholder="Enter an amount"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group basic">
                                <asp:LinkButton runat="server" ID="btnEW" class="btn btn-primary btn-block btn-lg"
                                    OnClick="btnEW_Click"> Submit Breakup</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- * Extended Warranty  Breakup Sheet -->

        <!-- Road Tax  Breakup Sheet -->
        <div class="modal fade action-sheet" id="RTOActionSheet" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Road Tax Breakup</h5>
                    </div>
                    <div class="modal-body">
                        <div class="action-sheet-content">

                            <div class="form-group basic">
                                <div class="input-wrapper">
                                    <label class="label" for="account2d">RTO Type</label>
                                    <asp:DropDownList runat="server" ID="ddlRTO_Type" CssClass="form-control custom-select" onchange="trpchargeschange()">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group basic">
                                <label class="label"><strong>Road Tax Amt</strong></label>
                                <div class="input-group mb-2">
                                    <span class="input-group-text">Rs.</span>
                                    <asp:TextBox runat="server" ID="TxtRTO_Amt" CssClass="form-control" placeholder="Enter an amount"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group basic">
                                <label class="label"><strong>TRC Amt</strong></label>
                                <div class="input-group mb-2">
                                    <span class="input-group-text">Rs.</span>

                                    <asp:TextBox runat="server" ID="TxtTRC_Amt" CssClass="form-control" placeholder="Enter an amount"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group basic">
                                <asp:LinkButton runat="server" ID="btnRTO" class="btn btn-primary btn-block btn-lg"
                                    OnClick="btnRTO_Click"> Submit Breakup</asp:LinkButton>
                            </div>



                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- * Road Tax  Breakup Sheet -->

        <!-- MSGA/GNA Sales Discount Sheet -->
        <div class="modal fade action-sheet" id="MSGASalesActionSheet" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">MSGA/GNA Amount</h5>
                    </div>
                    <div class="modal-body">
                        <div class="action-sheet-content">

                            <div class="form-group basic">
                                <label class="label"><strong>MSGA/GNA Amountt</strong></label>
                                <div class="input-group mb-2">
                                    <span class="input-group-text">Rs.</span>

                                    <asp:TextBox runat="server" ID="TxtMSGA_AMT" CssClass="form-control" placeholder="Enter an amount"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group basic">
                                <asp:LinkButton runat="server" ID="btnMSGA" class="btn btn-primary btn-block btn-lg"
                                    OnClick="btnMSGA_Click"> Submit Breakup</asp:LinkButton>
                            </div>


                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- * MSGA/GNA Sales  Sheet -->

        <!-- MSR  Breakup Sheet -->
        <div class="modal fade action-sheet" id="MSRActionSheet" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Maruti Suzuki Reward</h5>
                    </div>
                    <div class="modal-body">
                        <div class="action-sheet-content">

                            <div class="form-group basic">
                                <div class="input-wrapper">
                                    <label class="label" for="account2d">MSR Status</label>
                                    <asp:DropDownList runat="server" ID="ddlMSR" CssClass="form-control custom-select">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group basic">
                                <asp:LinkButton runat="server" ID="btnMSR" class="btn btn-primary btn-block btn-lg"
                                    OnClick="btnMSR_Click"> Submit Breakup</asp:LinkButton>
                            </div>
                        </div>


                    </div>
                </div>
            </div>
        </div>

        <!-- * MSR  Breakup Sheet -->

        <!-- Fastag  Breakup Sheet -->
        <div class="modal fade action-sheet" id="FastagActionSheet" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Fastag Detail</h5>
                    </div>
                    <div class="modal-body">
                        <div class="action-sheet-content">

                            <div class="form-group basic">
                                <div class="input-wrapper">
                                    <label class="label" for="account2d">Fastag Status</label>
                                    <asp:DropDownList runat="server" ID="ddlFasTag" CssClass="form-control custom-select">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group basic">
                                <asp:LinkButton runat="server" ID="btnFasTag" class="btn btn-primary btn-block btn-lg"
                                    OnClick="btnFasTag_Click"> Submit Breakup</asp:LinkButton>
                            </div>
                        </div>

                    </div>


                </div>
            </div>
        </div>

        <!-- * Fastag  Breakup Sheet -->

        <!-- Non MGA Sales Discount Sheet -->
        <div class="modal fade action-sheet" id="NonMGAActionSheet" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Non MGA Amount</h5>
                    </div>
                    <div class="modal-body">
                        <div class="action-sheet-content">

                            <div class="form-group basic">
                                <label class="label"><strong>Non MGA Amount</strong></label>
                                <div class="input-group mb-2">
                                    <span class="input-group-text" id="basic-addonb1">Rs.</span>
                                    <input type="text" class="form-control" placeholder="Enter an amount"
                                        value="0">
                                </div>
                                <div class="form-group basic">
                                    <button type="button" class="btn btn-primary btn-block btn-lg"
                                        data-bs-dismiss="modal">
                                        Submit Breakup</button>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- * MSGA/GNA Sales  Sheet -->

        <!-- App Bottom Menu -->
        <div class="appBottomMenu">
            <a href="app-transaction-detail.aspx?BookingId=<%= WebApp.LIBS.SiteSession.SalesDataTable.Rows[0]["BookingId"].ToString() %>&&SOB_No=<%= Request.QueryString["Loc_CD"] %>" class="item">
                <div class="col">
                    <ion-icon name="pie-chart-outline"></ion-icon>
                    <h4 class="m-0">Customer Detail</h4>
                </div>
            </a>
            <a href="app-Vehicle-detail.aspx?loc_code=<%= Request.QueryString["Loc_CD"] %>&&SOB_No=<%=  Request.QueryString["Loc_CD"] %>" class="item">
                <div class="col">
                    <ion-icon name="apps-outline"></ion-icon>
                    <h4 class="m-0">Vehicle</h4>
                </div>
            </a>
            <a href="app-Discount_Approval.aspx?BookingId=<%= WebApp.LIBS.SiteSession.SalesDataTable.Rows[0]["BookingId"].ToString() %>" class="item">
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

    <script type="text/javascript">

        function trpchargeschange() {

            if ($("#<%=ddlRTO_Type.ClientID%>").val() == "36") {
                $("#<%=TxtTRC_Amt.ClientID%>").val("1000");
            }
        }

        Sys.Application.add_load(BindEventsto);

        function BindEventsto() {

            debugger;
            $("div.messageBox").delay(5000).slideUp();
        }
    </script>

</body>

</html>
