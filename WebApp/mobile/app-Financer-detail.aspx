<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="app-Financer-detail.aspx.cs" Inherits="WebApp.mobile.app_Financer_detail" %>

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

    <form runat="server" id="FinancePag1">
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
                <div>Customer Finance Detail   </div>
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
                        <div class="item">
                            <a href="#" data-bs-toggle="modal" data-bs-target="#FinancerActionSheet">
                                <strong>Bank Name</strong>
                            </a>
                        </div>

                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="Financer_Name"></asp:Literal></h3>
                    </li>
                    <li>
                        <strong>Bank Branch</strong>
                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="Financer_Branch"></asp:Literal></h3>
                    </li>
                    <li>
                        <strong>Loan Type</strong>
                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="Loan_Type"></asp:Literal></h3>
                    </li>
                    <li>
                        <a href="#" data-bs-toggle="modal" data-bs-target="#FinancerDOActionSheet">
                            <strong>DO No.</strong>
                        </a>
                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="Finance_Do_Number"></asp:Literal></h3>
                    </li>
                    <li>
                        <strong>DO Amt</strong>
                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="Finance_DO_Amount"></asp:Literal></h3>
                    </li>
                    <li>
                        <strong>PF Charges</strong>
                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="Finance_PF_Charges"></asp:Literal></h3>
                    </li>
                    <li>
                        <a href="#" data-bs-toggle="modal" data-bs-target="#PurchaseOrderActionSheet">
                            <strong>PO No</strong>
                        </a>
                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="PO_Number"></asp:Literal></h3>
                    </li>
                    <li>
                        <strong>PO Date</strong>
                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="PO_Date"></asp:Literal></h3>
                    </li>
                    <li>
                        <strong>PO Amount</strong>
                        <h3 class="m-0">
                            <asp:Literal runat="server" ID="PO_AMT"></asp:Literal></h3>
                    </li>
                </ul>
            </div>
            <div class="right">
                <button type="button" class="btn btn-primary me-1 mb-1">Update</button>
            </div>
        </div>
        <!-- * App Capsule -->

        <!-- Financer Action Sheet -->
        <div class="modal fade action-sheet" id="FinancerActionSheet" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Financer Master</h5>
                    </div>
                    <div class="modal-body">
                        <div class="action-sheet-content">
                            <form>
                                <div class="form-group basic">
                                    <div class="input-wrapper">
                                        <label class="label" for="account2d">Financer List</label>

                                        
                                        <asp:DropDownList runat="server" CssClass="form-control custom-select" ID="FinancerName">
                                    
                                    </asp:DropDownList>
                                    

                                    </div>
                                </div>
                                <div class="form-group basic">
                                    <label class="label"><strong>Financer Branch Name</strong></label>
                                    <div class="input-group mb-2">
                                      <asp:TextBox runat="server"  ID="BranchName" CssClass="form-control" placeholder="Enter Loan Branch Name"
                                            value=""/>
                                    </div>
                                </div>
                                <div class="input-wrapper">
                                    <label class="label" for="account2d">Loan Type</label>
                                    <asp:DropDownList runat="server" CssClass="form-control custom-select" ID="LoanType">
                                            <asp:ListItem Text="Inhouse" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Self" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Cash" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    
                                </div>
                                <div class="form-group basic">
                                   <asp:Button runat="server" ID="Submits" CssClass="btn btn-primary btn-block btn-lg"
                                         Text="Submit" OnClick="Submits_Click">
                                        </asp:Button>
                              
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- * Financer Action Sheet -->

        <!-- Financer DO Number Action Sheet -->
        <div class="modal fade action-sheet" id="FinancerDOActionSheet" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Financer Delivery Order Detail</h5>
                    </div>
                    <div class="modal-body">
                        <div class="action-sheet-content">
                            <form>
                                <div class="form-group basic">
                                    <label class="label"><strong>Financer DO Number</strong></label>
                                    <div class="input-group mb-2">
                                        <input type="text" class="form-control" placeholder="Enter Delivery Order Number"
                                            value="">
                                    </div>
                                </div>
                                <div class="form-group basic">
                                    <label class="label"><strong>Financer DO Amount</strong></label>
                                    <div class="input-group mb-2">
                                        <span class="input-group-text" id="basic-addonb1">Rs.</span>
                                        <input type="text" class="form-control" placeholder="Enter an amount"
                                            value="0">
                                    </div>
                                </div>
                                <div class="form-group basic">
                                    <label class="label"><strong>Delivery Order PF Amount</strong></label>
                                    <div class="input-group mb-2">
                                        <span class="input-group-text" id="basic-addonb1">Rs.</span>
                                        <input type="text" class="form-control" placeholder="Enter an amount"
                                            value="0">
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
        <!-- * Financer Action Sheet -->

        <!-- Purchase Order Number Action Sheet -->
        <div class="modal fade action-sheet" id="PurchaseOrderActionSheet" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Purchase Order Detail</h5>
                    </div>
                    <div class="modal-body">
                        <div class="action-sheet-content">
                            <form>
                                <div class="form-group basic">
                                    <label class="label"><strong>Purchase Order Number</strong></label>
                                    <div class="input-group mb-2">
                                        <input type="text" class="form-control" placeholder="Enter Purchase Order Number"
                                            value="">
                                    </div>
                                </div>
                                <div class="form-group basic">
                                    <label class="label"><strong>Purchase Order Date</strong></label>
                                    <div class="input-group mb-2">
                                        <input type="date" class="form-control" placeholder=""
                                            value="01/01/1990">
                                    </div>
                                </div>
                                <div class="form-group basic">
                                    <label class="label"><strong>Purchase Order Amount</strong></label>
                                    <div class="input-group mb-2">
                                        <span class="input-group-text" id="basic-addonb1">Rs.</span>
                                        <input type="text" class="form-control" placeholder="Enter an amount"
                                            value="0">
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
        <!-- * Purchase Order Action Sheet -->

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
